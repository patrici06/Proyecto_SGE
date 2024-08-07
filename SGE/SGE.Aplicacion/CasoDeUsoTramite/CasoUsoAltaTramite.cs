namespace SGE.Aplicacion;

public class CasoUsoAltaTramite
{
    private readonly ITramiteRepositorio _tramiteRepositorio;
    private readonly IExpedienteRepositorio _expedienteRepositorio;
    private readonly ServicioCambioEstado _cambio;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public CasoUsoAltaTramite(ITramiteRepositorio tramiteRepositorio,
                               IExpedienteRepositorio expedienteRepositorio,
                               ServicioCambioEstado cambioEstado, IServicioAutorizacion servicioAutorizacion)
    {
        _tramiteRepositorio = tramiteRepositorio;
        _expedienteRepositorio = expedienteRepositorio; 
        _cambio = cambioEstado;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Tramite tramite, Usuario idUsuario)
    {
        TramiteValidador.ValidarTramite(tramite); 
        Expediente? ex = _expedienteRepositorio.ConsultaPorId(tramite.ExpedienteId);
        if (ex == null)
            throw new ValidacionException ($"No existe Expediente con Id {tramite.ExpedienteId}");
        _tramiteRepositorio.AgregarRegistro(tramite);
        ex = _cambio.CambioEstado(ex, tramite.EstadoTramite);
            if (ex.Tramites == null)
            {
                ex.Tramites = new List<Tramite>();
            }
            ex.Tramites.Add(tramite);
        _expedienteRepositorio.ModificarExpediente(ex, idUsuario.Id); 
    }
}