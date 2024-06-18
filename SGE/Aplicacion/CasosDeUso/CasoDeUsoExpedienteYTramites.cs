namespace Aplicacion; 

public class CasoDeUsoExpedienteYTramites(IExpedienteRepositorio expedienteRepositorio)
{
    public Expediente? Ejecutar(int id)
    {
        try 
        {   
            return expedienteRepositorio.ConsultarExpedienteYTramites(id);
        }
        catch
        {
            return null;
        }
    }
}