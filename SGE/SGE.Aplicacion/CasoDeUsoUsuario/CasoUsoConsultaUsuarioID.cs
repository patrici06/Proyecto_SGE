namespace SGE.Aplicacion;

public class CasoUsoConsultaUsuarioID
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoConsultaUsuarioID(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public Usuario? Ejecutar(int id)
    {
        return _repositorio.ObtenerUsuarioPorId(id);
    }
}