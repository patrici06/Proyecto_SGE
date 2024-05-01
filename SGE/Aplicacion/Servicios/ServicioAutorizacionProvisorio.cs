namespace Aplicacion;
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, int permiso)
    {
        // Si el IdUsuario es igual a 1, siempre retorna true, de lo contrario, retorna false
        return IdUsuario == 1;
    }
}