namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

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
    try
    {
        if (!_expedienteRepositorio.ExisteId(tramite.ExpedienteId))
        {
            throw new ValidacionException($"No existe Expediente con Id {tramite.ExpedienteId}");
        }

        _context.Tramites.Add(tramite);
        _context.SaveChanges();
        
        Expediente ex = _expedienteRepositorio.ConsultaPorId(tramite.ExpedienteId);
        if (ex != null)
        {
            ex = _cambio.CambioEstado(ex, tramite.EstadoTramite);
            if (ex.Tramites == null)
            {
                ex.Tramites = new List<Tramite>();
            }
            ex.Tramites.Add(tramite);

            _expedienteRepositorio.ModificarExpediente(ex, tramite.IdUsuario);
        }
    }
    catch (DbUpdateException ex)
    {
        // Captura la excepción de Entity Framework Core
        // y también revisa la InnerException para más detalles
        Console.WriteLine("Error al guardar cambios:");
        Console.WriteLine(ex.InnerException?.Message);
        throw; // Asegura que la excepción se propague para manejarla en capas superiores
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error inesperado: {e.Message}");
        throw; // Asegura que la excepción se propague para manejarla en capas superiores
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
       return _context.Tramites.SingleOrDefault(t => t.Id == idTramite);
    }

    public List<Tramite>? ConsultarTodos()
    {
        List<Tramite>? tramites = new List<Tramite>();
        if(_context.Tramites.Count()> 0)
            tramites = _context.Tramites.OrderByDescending(t => t.Id).ToList();
        else throw new RepositorioException("no Hay Tramites en la DB");
        return tramites; 
    }

    public void ElimiarRegistro(int idTramite, int idUsuario)
    {
        Tramite? tramite = _context.Tramites.Where(t => t.Id == idTramite).SingleOrDefault();
        if(tramite == null) throw new RepositorioException($"No se encontro Tramite id{idTramite}");

        Expediente? expedienteAsociado = _context.Expedientes.Where(e => e.Id == tramite.ExpedienteId).SingleOrDefault();
        if(expedienteAsociado == null) throw new RepositorioException($"NO Pertenece a ningun Tramite");
        if(expedienteAsociado.Tramites == null) throw new RepositorioException($"NO Pertenece a ningun Tramite");
        if(expedienteAsociado.Tramites != null)
            expedienteAsociado.Tramites.Remove(tramite);
        if (expedienteAsociado.Tramites == null || expedienteAsociado.Tramites.Count == 0)
        {
            expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, EstadoTramite.PaseAlArchivo);
        }
        else
        {
            int lastIndex = expedienteAsociado.Tramites.Count - 1;
            if (expedienteAsociado.Tramites[lastIndex].Id == idTramite)
            {
                if (lastIndex >= 1)
                {
                    EstadoTramite estadoAnterior = expedienteAsociado.Tramites[lastIndex - 1].EstadoTramite;
                    expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, estadoAnterior);
                }
            }
        }
        _context.Tramites.Remove(tramite);
        _expedienteRepositorio.ModificarExpediente(expedienteAsociado, idUsuario);
        _context.SaveChanges();
    }
    public void ModificarRegistro(Tramite tramite, int idUsuario)
    {
            Tramite? aux = _context.Tramites.SingleOrDefault(t => t.Id == tramite.Id);
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
                _expedienteRepositorio.ModificarExpediente(_cambio.CambioEstado(padre, aux.EstadoTramite), idUsuario);
                _context.SaveChanges();
            }   
    }
}
