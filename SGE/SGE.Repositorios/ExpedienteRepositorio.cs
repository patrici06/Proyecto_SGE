 namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

public class ExpedienteRepositorio: IExpedienteRepositorio
{
    private readonly DataContext _context;

    public ExpedienteRepositorio(DataContext context)
    {
        _context = context;
    }
    public void AltaExpediente(Expediente expediente)
    {
       
       _context.Expedientes.Add(expediente);
       _context.SaveChanges();

    }

    public void BajaExpediente(int idExpediente)
    {
        Expediente? expediente = _context.Expedientes.Where(e => e.Id == idExpediente).SingleOrDefault();
        if ( expediente != null )
        {
            if (expediente.Tramites != null && expediente.Tramites.Any())
            {
               foreach(Tramite t in expediente.Tramites)
                {
                    _context.Tramites.Remove(t);
                }
             }
             _context.Remove(expediente);
             _context.SaveChanges();
        }else{
            throw new RepositorioException($"No se encontro Expediente Id{idExpediente}");
        }
    }

    public Expediente? ConsultaPorId(int id)
    {
        return _context.Expedientes.Where(e => e.Id == id).SingleOrDefault();
    }

    public List<Expediente>? ConsultarTodos()
    {
        List<Expediente>? list = _context.Expedientes.ToList();
        if(list == null) throw new RepositorioException("No se encontraron Expedientes");
        return  list;
    }

    public bool ExisteId(int Id)
{
    return _context.Expedientes.Any(e => e.Id == Id);
}

    public void ModificarExpediente(Expediente expediente, int idUsuario)
    {
        Expediente? remplazado  = ConsultaPorId(expediente.Id);
        if (remplazado == null) throw new RepositorioException($"No se Encuentra Expediente {expediente.Id}"); 
        remplazado.Caratula = expediente.Caratula;
        remplazado.IdUsuarioModificacion = idUsuario;
        remplazado.FechaModificacion = DateTime.Now;
        remplazado.Estado = expediente.Estado;
        _context.Expedientes.Update(remplazado);
        _context.SaveChanges();
    }
}
