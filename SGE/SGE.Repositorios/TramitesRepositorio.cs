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

public void ElimiarRegistro(int idTramite, int idUsuario)
{
    Tramite? tramite = _context.Tramites.SingleOrDefault(t => t.Id == idTramite);
    if (tramite == null) throw new RepositorioException($"No se encontro Tramite id{idTramite}");

    Expediente? expedienteAsociado = _context.Expedientes.SingleOrDefault(e => e.Id == tramite.ExpedienteId);
    if (expedienteAsociado == null) throw new RepositorioException("NO Pertenece a ningun Expediente");

    if (expedienteAsociado.Tramites == null || !expedienteAsociado.Tramites.Any())
    {
        throw new RepositorioException("NO Pertenece a ningun Tramite");
    }

    // Remover tramite del expediente
    expedienteAsociado.Tramites.Remove(tramite);

    if (!expedienteAsociado.Tramites.Any())
    {
        expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, EstadoTramite.PaseAlArchivo);
    }
    else
    {
        int lastIndex = expedienteAsociado.Tramites.Count - 1;
        if (lastIndex >= 0 && expedienteAsociado.Tramites[lastIndex].Id == idTramite)
        {
            if (lastIndex - 1 >= 0)
            {
                EstadoTramite estadoAnterior = expedienteAsociado.Tramites[lastIndex - 1].EstadoTramite;
                expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, estadoAnterior);
            }
            else
            {
                expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, EstadoTramite.PaseAlArchivo);
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
