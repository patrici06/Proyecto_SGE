namespace Aplicacion; 
public class CasosDeUsoExpedienteConsultaId
{
    public CasosDeUsoExpedienteConsultaId(IExpedienteRepositorio expedienteRepositorio, int id, out Expediente? e)
    {
        e = expedienteRepositorio.ConsultaPorId(id);
    }
}