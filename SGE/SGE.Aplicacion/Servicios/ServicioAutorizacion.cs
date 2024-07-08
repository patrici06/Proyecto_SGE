
using SGE.Aplicacion;

public class ServicioAutorizacion: IServicioAutorizacion 
{
    private readonly  IUsuariosRepositorios _servicioUsuarios;
    private readonly UsuarioValidador _usuarioValidador;

    public ServicioAutorizacion( IUsuariosRepositorios servicioUsuarios, UsuarioValidador usuarioValidador)
    {
        _servicioUsuarios = servicioUsuarios;
        _usuarioValidador = usuarioValidador;
    }

    //Recibe una lista de permisos y verifica que el usuario tenga esos mismos permisos
    public bool TienePermiso(Usuario usuarioId, Permiso permiso)
    {
        var usuario = _servicioUsuarios.ObtenerUsuarioPorId(usuarioId.Id);
        return _usuarioValidador.TienePermiso(usuario, permiso);
    
    }
}