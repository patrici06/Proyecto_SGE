namespace SGE.Aplicacion;

public class CasoUsoAltaUsuario
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoAltaUsuario(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(Usuario usuario)
    {
        _repositorio.Crear(usuario);
    }
}