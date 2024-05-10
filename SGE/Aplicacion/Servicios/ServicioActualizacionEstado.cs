namespace Aplicacion;

public class ServicioActualizacionEstado(IExpedienteRepositorio expediente, EspecificacionCambioEstado cambioEstado)
{
    public void Actualizacion(int idExpediente)
    {
        Expediente? retorno = null;
        LinkedList<Tramite> tramites = expediente.ConsultarExpedienteYTramites(out retorno,idExpediente);
        if(retorno != null)
        {
            cambioEstado.CambioEstado(retorno, tramites.Last());
            expediente.ModificarExpediente(retorno, retorno.IdUsuarioModificacion);
        }
    } 
}