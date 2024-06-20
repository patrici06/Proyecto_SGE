

namespace SGE.Aplicacion;

public class ServicioTramite : ITramiteRepositorio
{
    private readonly ITramiteRepositorio _tramiteRepositorio;
    public ServicioTramite(ITramiteRepositorio tramiteRepositorio)
    {
        _tramiteRepositorio = tramiteRepositorio;
    }
    public void AgregarRegistro(Tramite tramite)
    {
        _tramiteRepositorio.AgregarRegistro(tramite); 
    }

    public List<Tramite>? ConsultaPorEtiqueta(EstadoTramite estado)
    {
        return _tramiteRepositorio.ConsultaPorEtiqueta(estado);
    }

    public Tramite? ConsultaPorId(int idTramite)
    {
        return _tramiteRepositorio.ConsultaPorId(idTramite);
    }

    public List<Tramite>? ConsultarTodos()
    {
        return _tramiteRepositorio.ConsultarTodos();
    }

    public void ElimiarRegistro(int idTramie, int idUsuario)
    {
       _tramiteRepositorio.ElimiarRegistro(idTramie,idUsuario);
    }

    public void ModificarRegistro(Tramite tramite, int idUsuario)
    {
        _tramiteRepositorio.ModificarRegistro(tramite, idUsuario);
    }
}
    