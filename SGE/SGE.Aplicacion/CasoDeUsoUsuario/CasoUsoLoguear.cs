namespace SGE.Aplicacion;

public class CasoUsoLoguear
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoLoguear(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public Usuario? Ejecutar(string correo, string contrasena)
    {
        return _repositorio.Logear(correo, contrasena);
    }
}