using System.Linq.Expressions;

namespace Aplicacion;

public class UsuarioValidador : IServicioAutorizacion
{
    public bool PoseeElPermiso(Usuario usuario, List<Permiso> permisos)
    {
        try{

            if (usuario.permisos != null)
             return  permisos.All(n => usuario.permisos.Exists(p => p.Equals(n))); 
            else
                return false;
             //cheque que en la lista de permisos de la instancia usuario tenga todos los permisos 
             //detallados en la lista.
        }
        catch{
            return false;
        }
    }
}