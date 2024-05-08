namespace Aplicacion; 
public class CasosDeUsoExpedienteConsultaId(IExpedienteRepositorio expedienteRepositorio)
{
    public void Ejecutar(int id, out Expediente? e)
    {
        e = expedienteRepositorio.ConsultaPorId(id);
    }
}