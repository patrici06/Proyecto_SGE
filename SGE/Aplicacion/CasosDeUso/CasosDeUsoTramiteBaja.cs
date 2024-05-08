namespace Aplicacion;

public class CasosDeUsoTramiteBaja(ITramiteRepositorio tramiteRepositorio, ServicioActualizacionEstado servicio)
{
        public void Ejecutar(int idTramite, int idUsuario)
        {
            Tramite? tramite  = tramiteRepositorio.ConsultaPorId(idTramite); 
            if(tramite != null) {
                tramiteRepositorio.ElimiarRegistro(idTramite, idUsuario);
                servicio.Actualizacion(tramite.ExpedienteId);
            }
        }

}