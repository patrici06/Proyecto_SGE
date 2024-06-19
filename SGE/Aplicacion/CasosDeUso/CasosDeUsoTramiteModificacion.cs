using Aplicacion;

public class CasosDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, ServicioActualizacionEstado servicio)
{
// Requiere Modificacion Previa de el Tramite
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        tramiteRepositorio.ModificarRegistro(tramite, idUsuario);
        //servicio.Actualizacion(tramite.ExpedienteId);
    }
}