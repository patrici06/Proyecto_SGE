namespace Aplicacion;

public class ServicioActualizacionEstado(IExpedienteRepositorio expediente)
{
    public void Actualizacion(int idExpediente)
    {
        Expediente? retorno = null;
        LinkedList<Tramite> tramites = expediente.ConsultarExpedienteYTramites(out retorno,idExpediente);
        if(retorno != null)
        {
            switch(tramites.Last().estadoTramite)
            {
                case EstadoTramite.Resolucion: retorno.Estado = EstadoExpediente.ConResolucion;
                break;
                case EstadoTramite.PaseAEstudio: retorno.Estado = EstadoExpediente.ParaResolver;
                break; 
                case EstadoTramite.PaseAlArchivo: retorno.Estado = EstadoExpediente.Finalizado;
                break;
            }
            expediente.ModificarExpediente(retorno, retorno.IdUsuarioModificacion);
        }
    } 
}