namespace Aplicacion;

public class ServicioActualizacionEstado(IExpedienteRepositorio expediente, EspecificacionCambioEstado cambioEstado)
{
    public void Actualizacion(int idExpediente)
    {
        Expediente? retorno = expediente.ConsultarExpedienteYTramites(idExpediente);
        if(retorno != null)
        {
            cambioEstado.CambioEstado(retorno, retorno.Tramites.Last());
            expediente.ModificarExpediente(retorno, idUsuario: retorno.IdUsuarioModificacion);
        }
    } 
}