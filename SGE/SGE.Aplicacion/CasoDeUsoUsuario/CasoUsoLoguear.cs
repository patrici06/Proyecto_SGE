using System.Runtime.CompilerServices;

namespace SGE.Aplicacion;

public class CasoUsoLoguear
{

    private readonly IUsuariosRepositorios _repositorio;
    private readonly ServicioHash _servicioHash;

    public CasoUsoLoguear(IUsuariosRepositorios repositorio,ServicioHash servicioHash )
    {
        _repositorio = repositorio;
        _servicioHash = servicioHash;
    }

    public Usuario Ejecutar(string correo, string contrasena)
    {
        var usuario = _repositorio.Logear(correo);
        if(usuario == null) throw new RepositorioException($"No existe Usuario con correo {correo}");
        if(!_servicioHash.validarContrasena(contrasena, usuario.contrasena))
        throw new ValidacionException("Las contraseñas no coinciden");
        return usuario;
    }
}