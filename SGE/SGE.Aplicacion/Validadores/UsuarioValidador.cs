using System.Linq.Expressions;

namespace SGE.Aplicacion;

public class UsuarioValidador : IServicioAutorizacion
{
    public bool TienePermiso(Usuario? usuario, Permiso permiso)
    {
        if(usuario != null)
        //permisos.All(n => usuario.permisos.Exists(p => p.Equals(n)))
            return  usuario.permisos.Contains(permiso);
        else
            throw new RepositorioException("Error No Posee Permisos");
    }
}