namespace Aplicacion;
public interface IServicioAutorizacion
{
    bool PoseeElPermiso(Usuario usuario, List<Permiso> permisos);
}