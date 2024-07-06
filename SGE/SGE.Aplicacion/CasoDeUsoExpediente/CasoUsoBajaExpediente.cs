namespace SGE.Aplicacion; 

public class CasoUsoBajaExpediente
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    private readonly UsuarioValidador _UsuarioValidador;
    public CasoUsoBajaExpediente(IExpedienteRepositorio expedienteRepositorio, UsuarioValidador _usuarioValidador){
        _ExpedienteRepositorio = expedienteRepositorio;
        _UsuarioValidador = _usuarioValidador;
    }

    public void Ejecutar(int idExpediente, Usuario idUsuario)
    {
        if(!_UsuarioValidador.TienePermiso(idUsuario, Permiso.ExpedienteBaja)) throw new AutorizacionException($"No posee permiso {Permiso.ExpedienteBaja}");
        _ExpedienteRepositorio.BajaExpediente(idExpediente);
    }
}