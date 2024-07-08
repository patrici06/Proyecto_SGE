namespace SGE.Aplicacion;

public class CasoUsoModificacionUsuarioAdmin
{
    private readonly IUsuariosRepositorios _repositorio;
    private readonly ServicioHash _servicioHash;

    public CasoUsoModificacionUsuarioAdmin(IUsuariosRepositorios repositorio, ServicioHash servicioHash)
    {
        _repositorio = repositorio;
        _servicioHash = servicioHash;
    }

    public void Ejecutar(Usuario usuario,string contrasena, string apellido,string correo, string nombre)
    {
        if (string.IsNullOrEmpty(apellido))
            throw new ValidacionException("No se ingresó apellido");
        if (string.IsNullOrEmpty(correo))
            throw new ValidacionException("No se ingresó correo");
        if (string.IsNullOrEmpty(nombre))
            throw new ValidacionException("No se ingresó nombre");
        var user = _repositorio.ListarUsuarios().FirstOrDefault(u => u.correo == correo);
        if (user != null && user.correo != usuario.correo)
            throw new ValidacionException("Error: Ese correo ya fue utilizado");

        usuario.nombre = nombre;
        usuario.apellido = apellido;
        usuario.correo = correo;
        if(!String.IsNullOrEmpty(contrasena)) 
            usuario.contrasena = _servicioHash.generarHashContrasena(contrasena);
        _repositorio.ModificarUsuario(usuario);
    }
}
