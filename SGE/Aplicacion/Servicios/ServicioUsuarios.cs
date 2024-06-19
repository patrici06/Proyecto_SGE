namespace Aplicacion;

public class ServicioUsuarios 
{

    private readonly IUsuariosRepositorios _repositorio;

    public ServicioUsuarios(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public void RegistrarUsuario(string nombre, string apellido, string correo, string contrasena, List<Permiso> permisos)
    {
        var usuario = new Usuario(nombre, apellido, correo, contrasena, permisos);
        _repositorio.Crear(usuario);
    }

    public Usuario? IniciarSesion(string correo, string contrasena)
    {
        return _repositorio.Logear(correo, contrasena);
    }

    public void AsignarPermisos(Usuario usuario, List<Permiso> permisos, int idUsuario)
    {
        _repositorio.OtorgarPermisos(usuario, permisos);
    }

    public void EliminarUsuario(int id)
    {
        _repositorio.EliminarUsuario(id);
    }

    public void ActualizarUsuario(Usuario usuario)
    {
        _repositorio.ModificarUsuario(usuario);
    }

    public Usuario? BuscarPorId(int idUsuario)
    {
        return _repositorio.ObtenerUsuarioPorId(idUsuario);
    }

    public List<Usuario> ObtenerUsuarios()
    {
        return _repositorio.ListarUsuarios();
    }

}