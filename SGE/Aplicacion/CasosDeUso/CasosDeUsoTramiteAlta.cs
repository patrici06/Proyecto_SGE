namespace Aplicacion;

public class CasosDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio, ServicioActualizacionEstado servicio)
{
    public void Ejecutar(Tramite t, int idUsuario)
    {
      tramiteRepositorio.AgregarRegistro(t, idUsuario);
      servicio.Actualizacion(t.ExpedienteId);
    }
}