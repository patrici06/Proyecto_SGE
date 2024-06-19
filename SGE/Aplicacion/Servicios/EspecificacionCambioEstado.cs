namespace Aplicacion; 

public class EspecificacionCambioEstado()
{
    public Expediente CambioEstado (Expediente retorno, Tramite ultimoTramite)
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
        return retorno;
    }
}