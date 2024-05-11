namespace Aplicacion; 

public class CasoDeUsoExpedienteYTramites(IExpedienteRepositorio expedienteRepositorio)
{
    public LinkedList<Tramite> Ejecutar(out Expediente? expediente, int id)
    {
        return expedienteRepositorio.ConsultarExpedienteYTramites(out expediente, id);
    }
}