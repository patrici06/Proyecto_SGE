 namespace Repositorios;

using System.Collections.Generic;
using Aplicacion;


public class ExpedienteRepositorio: IExpedienteRepositorio
{
    public void AltaExpediente(Expediente expediente)
    {
       using  (var db = new DataContext()){
       db.Expedientes.Add( expediente );
       db.SaveChanges();
       }
    }

    public void BajaExpediente(int idExpediente)
    {
        using (var db = new DataContext()){ 
        Expediente? expediente = db.Expedientes.Where(e => e.Id == idExpediente).SingleOrDefault();
        if ( expediente != null )
        {
            if (expediente.Tramites != null && expediente.Tramites.Any())
            {
               foreach(Tramite t in expediente.Tramites)
                {
                    db.Tramites.Remove(t);
                }
             }
             db.Remove(expediente);
             db.SaveChanges();
        }else{
            throw new RepositorioException($"No se encontro Expediente Id{idExpediente}");
        }
        }
    }

    public Expediente? ConsultaPorId(int id)
    {
        using (var db = new DataContext()){ 
        return db.Expedientes.Where(e => e.Id == id).SingleOrDefault();
        }
    }

    public List<Expediente>? ConsultarTodos()
    {
       using (var db = new DataContext()){
        List<Expediente>? list = db.Expedientes.ToList();
        if(list == null) throw new RepositorioException("No se encontraron Expedientes");
        return  list;
       }
    }


    public void ModificarExpediente(Expediente expediente, int idUsuario)
    {
        Expediente? remplazado  = ConsultaPorId(expediente.Id);
        if (remplazado == null) throw new RepositorioException($"No se Encuentra Expediente {expediente.Id}"); 
        using (var db = new DataContext()){
        remplazado.Caratula = expediente.Caratula;
        remplazado.IdUsuarioModificacion = idUsuario;
        remplazado.FechaModificacion = DateTime.Now;
        remplazado.Estado = expediente.Estado;
        db.Expedientes.Update(remplazado);
        db.SaveChanges();
        }
    }
}
