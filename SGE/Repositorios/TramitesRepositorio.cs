namespace Repositorios;

using System.Collections.Generic;
using Aplicacion;

public class TramitesRepositorio : ITramiteRepositorio
{   
    private readonly DataContext _context;
    private readonly IExpedienteRepositorio _expedienteRepositorio;
    private readonly EspecificacionCambioEstado _cambio;

    public TramitesRepositorio(DataContext context, IExpedienteRepositorio expedienteRepositorio, EspecificacionCambioEstado cambio)
    {
        _context = context;
        _expedienteRepositorio = expedienteRepositorio;
        _cambio = cambio;
    }
    public void AgregarRegistro(Tramite tramite)
    {
        _context.Tramites.Add(tramite); 
        _context.SaveChanges();
        Expediente? ex = _expedienteRepositorio.ConsultaPorId(tramite.ExpedienteId); 
        if (ex != null)
        {
           ex = _cambio.CambioEstado(ex, tramite);
           _expedienteRepositorio.ModificarExpediente(ex, tramite.IdUsuario);
        }
       
    }

    public List<Tramite> ConsultaPorEtiqueta(EstadoTramite estado)
    { 
       List<Tramite> tramites = _context.Tramites.Where(t => t.EstadoTramite == estado).ToList();
       if(tramites == null) throw new RepositorioException($"No se encontro tramites con la Etiqueda{estado}");
       return tramites;
    }

    public Tramite? ConsultaPorId(int idTramite)
    { 
        return _context.Tramites.Where(t => t.Id == idTramite).SingleOrDefault();
    }

    public void ElimiarRegistro(int idTramite, int idUsuario)
    {
        Tramite? tramite = _context.Tramites.Where(t => t.Id == idTramite).SingleOrDefault();
        if(tramite == null) throw new RepositorioException($"No se encontro Tramite id{idTramite}"); 
        List<Tramite> tramitesDelExpediente = _context.Tramites.Where(t=> t.ExpedienteId == tramite.ExpedienteId)
                                                .OrderByDescending(t => t.FechaHoraUltimaModificacion)
                                                .ToList();
        if (tramitesDelExpediente.Count >= 1 && tramitesDelExpediente.First().Id == tramite.Id)
        {
            _context.Tramites.Remove(tramite);
            _context.SaveChanges();

            if (tramitesDelExpediente.Count > 1)
            {
                var ultimoTramite = tramitesDelExpediente[1];
                var modificaremos = _context.Expedientes.SingleOrDefault(e => e.Id == ultimoTramite.ExpedienteId);
                
                if (modificaremos != null)
                {
                    modificaremos = _cambio.CambioEstado(modificaremos, ultimoTramite);
                    _context.SaveChanges();
                }
            }
            else
            {
                var modificaremos = _context.Expedientes.SingleOrDefault(e => e.Id == tramite.ExpedienteId); 
                
                if (modificaremos != null)
                {
                    var aux = new Tramite { EstadoTramite = EstadoTramite.PaseAlArchivo };
                    modificaremos = _cambio.CambioEstado(modificaremos, aux);
                    _context.SaveChanges();
                }
            }
        }
        else
        {
            _context.Tramites.Remove(tramite);
            _context.SaveChanges();
        }
    }
    public void ModificarRegistro(Tramite tramite, int idUsuario)
    {
            Tramite? aux = _context.Tramites.Where(t => t.Id == tramite.Id).SingleOrDefault();
            if(aux == null) throw new RepositorioException($" no se encontro Tramite {tramite.Id}"); 
            aux.IdUsuario = idUsuario;
            aux.FechaHoraUltimaModificacion = DateTime.Now; 
            aux.ExpedienteId = tramite.ExpedienteId;
            aux.EstadoTramite = tramite.EstadoTramite; 
            aux.Contenido =  tramite.Contenido;
            _context.Tramites.Update(aux); 
            _context.SaveChanges();
            Expediente? padre = _expedienteRepositorio.ConsultaPorId(aux.Id); 
            if(padre!= null)
            {
                _expedienteRepositorio.ModificarExpediente(_cambio.CambioEstado(padre, aux), idUsuario);
                _context.SaveChanges();
            }   
    }
}
