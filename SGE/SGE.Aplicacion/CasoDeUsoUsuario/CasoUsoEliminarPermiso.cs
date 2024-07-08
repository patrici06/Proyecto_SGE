namespace SGE.Aplicacion;

public class CasoUsoEliminarPermiso
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoEliminarPermiso(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(Usuario usuario, Permiso permiso)
    {
        if(!usuario.permisos.Contains(permiso)) throw new ValidacionException($"El usuario ya no cuenta con permiso {permiso}");
        usuario.permisos.Remove(permiso);
        _repositorio.ModificarUsuario(usuario);
    }
}