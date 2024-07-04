namespace SGE.Aplicacion;

public class CasoUsoModificacionUsuario
{

    private readonly IUsuariosRepositorios _repositorio;

    public CasoUsoModificacionUsuario(IUsuariosRepositorios repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(Usuario usuario)
    {
        _repositorio.ModificarUsuario(usuario);
    }
}