namespace SGE.Aplicacion;

public class CasoUsoOtorgarPermisos
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoOtorgarPermisos(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(Usuario usuario, Permiso permiso)
    {
        _repositorio.OtorgarPermisos(usuario, permiso);
    }
}