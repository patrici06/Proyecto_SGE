namespace SGE.Aplicacion; 

public class CasoUsoAltaExpediente
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    private readonly IServicioAutorizacion _UsuarioValidador;
    public CasoUsoAltaExpediente(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion _usuarioValidador){
        _ExpedienteRepositorio = expedienteRepositorio;
        _UsuarioValidador = _usuarioValidador;
    }

    public void Ejecutar(Expediente expediente, Usuario user)
    {
        ExpedienteValidador.ValidarExpediente(expediente);
        if(!_UsuarioValidador.TienePermiso(user, Permiso.ExpedienteAlta)) throw new AutorizacionException($"No posee permiso {Permiso.ExpedienteAlta}");
        _ExpedienteRepositorio.AltaExpediente(expediente);
    }
}