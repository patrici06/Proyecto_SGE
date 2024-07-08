namespace SGE.Aplicacion;

public class CasoUsoModificacionUsuario
{
    private readonly IUsuariosRepositorios _repositorio;
    private readonly ServicioHash _servicioHash;

    public CasoUsoModificacionUsuario(IUsuariosRepositorios repositorio, ServicioHash servicioHash)
    {
        _repositorio = repositorio;
        _servicioHash = servicioHash;
    }

    public void Ejecutar(Usuario usuario, Usuario usuarioMod, string contraseñaAnterior)
    {
        if (usuarioMod == null)
            throw new ArgumentNullException(nameof(usuarioMod),"El usuario modificado no puede ser nulo");
        if (string.IsNullOrEmpty(usuarioMod.apellido))
            throw new ValidacionException("No se ingresó apellido");
        if (string.IsNullOrEmpty(usuarioMod.correo))
            throw new ValidacionException("No se ingresó correo");
        if (string.IsNullOrEmpty(usuarioMod.nombre))
            throw new ValidacionException("No se ingresó nombre");
        if (string.IsNullOrEmpty(usuarioMod.contrasena))
            throw new ValidacionException("No se ingresó contraseña");
        var user = _repositorio.ListarUsuarios().FirstOrDefault(u => u.correo == usuarioMod.correo);
        if (user != null && user.correo != usuario.correo)
            throw new ValidacionException("Error: Ese correo ya fue utilizado");
        if (!_servicioHash.validarContrasena(contraseñaAnterior, usuario.contrasena))
            throw new ValidacionException("No coinciden las contraseñas");
        usuario.nombre = usuarioMod.nombre;
        usuario.apellido = usuarioMod.apellido;
        usuario.correo = usuarioMod.correo;
        usuario.contrasena = _servicioHash.generarHashContrasena(usuarioMod.contrasena);
        _repositorio.ModificarUsuario(usuario);
    }
}
