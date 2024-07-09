namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

public class TramitesRepositorio : ITramiteRepositorio
{   
    private readonly DataContext _context;

    public TramitesRepositorio(DataContext context)
    {
        _context = context;
    }
    public void AgregarRegistro(Tramite tramite)
    {
        _context.Tramites.Add(tramite);
        _context.SaveChanges();       
    }
    public List<Tramite> ConsultaPorEtiqueta(EstadoTramite estado)
    { 
     return _context.Tramites.Where(t => t.EstadoTramite == estado).ToList();
    }

    public Tramite? ConsultaPorId(int idTramite)
    { 
       return _context.Tramites.SingleOrDefault(t => t.Id == idTramite);
    }

    public List<Tramite>? ConsultarTodos()
    {
            return _context.Tramites.OrderByDescending(t => t.Id).ToList();
    }

public void ElimiarRegistro(Tramite tramite)
{
    _context.Tramites.Remove(tramite);
    _context.SaveChanges();
}

public void ModificarRegistro(Tramite tramite, int idUsuario)
{
    Tramite? aux = _context.Tramites.SingleOrDefault(t => t.Id == tramite.Id);
    if (aux == null)
    {
        throw new RepositorioException($"No se encuentra Tramite {tramite.Id}");
    }
    else
    {
        aux.IdUsuario = idUsuario; // No más warnings
        aux.FechaHoraUltimaModificacion = DateTime.Now;
        aux.ExpedienteId = tramite.ExpedienteId;
        aux.EstadoTramite = tramite.EstadoTramite;
        aux.Contenido = tramite.Contenido;
        
        _context.Tramites.Update(aux);
        _context.SaveChanges();
    }
}
}
