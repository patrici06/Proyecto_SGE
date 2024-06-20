namespace Aplicacion;

public class ServicioUsuarios : IUsuariosRepositorios
{

    private readonly IUsuariosRepositorios _repositorio;

    public ServicioUsuarios(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public void Crear(Usuario usuario)
    {
      _repositorio.Crear(usuario);
    }

    public Usuario? Logear(string correo, string contrasena)
    {
        return _repositorio.Logear(correo, contrasena);
    }

    public void OtorgarPermisos(Usuario usuario, List<Permiso> permisos)
    {
        _repositorio.OtorgarPermisos(usuario, permisos);
    }

    public void EliminarUsuario(int id)
    {
        _repositorio.EliminarUsuario(id);
    }

    public void ModificarUsuario(Usuario usuario)
    {
        _repositorio.ModificarUsuario(usuario);
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        return _repositorio.ObtenerUsuarioPorId(id);
    }

    public List<Usuario> ListarUsuarios()
    {
        return _repositorio.ListarUsuarios();
    }
}