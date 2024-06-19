namespace Aplicacion; 

public class EspecificacionCambioEstado()
{
    public void CambioEstado (Expediente retorno, in Tramite ultimoTramite)
    {
        switch(ultimoTramite.EstadoTramite)
            {
                case EstadoTramite.Resolucion: retorno.Estado = EstadoExpediente.ConResolucion;
                break;
                case EstadoTramite.PaseAEstudio: retorno.Estado = EstadoExpediente.ParaResolver;
                break; 
                case EstadoTramite.PaseAlArchivo: retorno.Estado = EstadoExpediente.Finalizado;
                break;
            }
    }
}