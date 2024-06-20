namespace SGE.Aplicacion;
public interface IServicioAutorizacion
{
    bool TienePermiso(Usuario usuarioId, Permiso permiso);
}