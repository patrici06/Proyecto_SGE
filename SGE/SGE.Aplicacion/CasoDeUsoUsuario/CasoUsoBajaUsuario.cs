namespace SGE.Aplicacion;

public class CasoUsoBajaUsuario
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoBajaUsuario(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(int id)
    {
        _repositorio.EliminarUsuario(id);
    }
}