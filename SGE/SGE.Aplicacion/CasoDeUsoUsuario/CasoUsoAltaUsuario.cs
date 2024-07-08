namespace SGE.Aplicacion;

public class CasoUsoAltaUsuario
{

    private readonly IUsuariosRepositorios _repositorio;
    private readonly ServicioHash _servicioHash;

    public CasoUsoAltaUsuario(IUsuariosRepositorios repositorio, ServicioHash servicioHash)
    {
        _repositorio = repositorio;
        _servicioHash = servicioHash;
    }

    public void Ejecutar(Usuario usuario)
    {
        if(string.IsNullOrEmpty(usuario.apellido)) throw new ValidacionException("No se ingreso Apellido ");
        if(string.IsNullOrEmpty(usuario.correo))  throw new ValidacionException("No se ingreso Correo");
        if(string.IsNullOrEmpty(usuario.nombre))  throw new ValidacionException("No se ingreso Nombre ");
        if(string.IsNullOrEmpty(usuario.contrasena))  throw new ValidacionException("No se ingreso Constraseña");
        var user = _repositorio.ListarUsuarios().FirstOrDefault(u => u.correo == usuario.correo);
        if(user != null)
            throw new ValidacionException("Error: Ese correo ya fue utilizado");
         usuario.contrasena = _servicioHash.generarHashContrasena(usuario.contrasena);  
        _repositorio.Crear(usuario);
    }
}