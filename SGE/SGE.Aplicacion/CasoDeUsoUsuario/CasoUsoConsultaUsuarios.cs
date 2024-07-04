namespace SGE.Aplicacion;

public class CasoUsoConsultaUsuarios
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoConsultaUsuarios(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public List<Usuario> Ejecutar()
    {
        return _repositorio.ListarUsuarios();
    }
}