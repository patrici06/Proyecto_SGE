namespace Repositorios;

using System.Collections.Generic;
using Aplicacion;

public class TramitesRepositorio(ExpedienteRepositorio e, EspecificacionCambioEstado cambio) : ITramiteRepositorio
{
    public void AgregarRegistro(Tramite tramite)
    {
       using (var db  = new DataContext()){
        db.Tramites.Add(tramite); 
        db.SaveChanges();
        Expediente? ex = e.ConsultaPorId(tramite.ExpedienteId); 
        if (ex != null)
        {
           ex = cambio.CambioEstado(ex, tramite);
           e.ModificarExpediente(ex, tramite.IdUsuario);
        }
       }
    }

    public List<Tramite> ConsultaPorEtiqueta(EstadoTramite estado)
    {
       using (var db = new DataContext()){ 
       List<Tramite> tramites = db.Tramites.Where(t => t.EstadoTramite == estado).ToList();
       if(tramites == null) throw new RepositorioException($"No se encontro tramites con la Etiqueda{estado}");
       return tramites;
    }
    }

    public Tramite? ConsultaPorId(int idTramite)
    {
        using (var db = new DataContext()){ 
        return db.Tramites.Where(t => t.Id == idTramite).SingleOrDefault();
        }
    }

    public void ElimiarRegistro(int idTramite, int idUsuario)
    {
        using (var db = new DataContext()){ 
        Tramite? tramite = db.Tramites.Where(t => t.Id == idTramite).SingleOrDefault();
        if(tramite == null) throw new RepositorioException($"No se encontro Tramite id{idTramite}"); 
        List<Tramite> tramitesDelExpediente = db.Tramites.Where(t=> t.ExpedienteId == tramite.ExpedienteId)
                                                .OrderByDescending(t => t.FechaHoraUltimaModificacion)
                                                .ToList();
        if (tramitesDelExpediente.Count >= 1 && tramitesDelExpediente.First().Id == tramite.Id)
        {
            db.Tramites.Remove(tramite);
            db.SaveChanges();

            if (tramitesDelExpediente.Count > 1)
            {
                var ultimoTramite = tramitesDelExpediente[1];
                var modificaremos = db.Expedientes.SingleOrDefault(e => e.Id == ultimoTramite.ExpedienteId);
                
                if (modificaremos != null)
                {
                    modificaremos = cambio.CambioEstado(modificaremos, ultimoTramite);
                    db.SaveChanges();
                }
            }
            else
            {
                var modificaremos = db.Expedientes.SingleOrDefault(e => e.Id == tramite.ExpedienteId); 
                
                if (modificaremos != null)
                {
                    var aux = new Tramite { EstadoTramite = EstadoTramite.PaseAlArchivo };
                    modificaremos = cambio.CambioEstado(modificaremos, aux);
                    db.SaveChanges();
                }
            }
        }
        else
        {
            db.Tramites.Remove(tramite);
            db.SaveChanges();
        }
        }
    }
    public void ModificarRegistro(Tramite tramite, int idUsuario)
    {
        using (var db = new DataContext())
        {
            Tramite? aux = db.Tramites.Where(t => t.Id == tramite.Id).SingleOrDefault();
            if(aux == null) throw new RepositorioException($" no se encontro Tramite {tramite.Id}"); 
            aux.IdUsuario = idUsuario;
            aux.FechaHoraUltimaModificacion = DateTime.Now; 
            aux.ExpedienteId = tramite.ExpedienteId;
            aux.EstadoTramite = tramite.EstadoTramite; 
            aux.Contenido =  tramite.Contenido;
            db.Tramites.Update(aux); 
            db.SaveChanges();
            Expediente? padre = e.ConsultaPorId(aux.Id); 
            if(padre!= null)
            {
                e.ModificarExpediente(cambio.CambioEstado(padre, aux), idUsuario);
                db.SaveChanges();
            } 
        } 
        
    }
}
