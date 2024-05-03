namespace Aplicacion;

public class CasosDeUsoExpedienteConsultaTodos
{
    public CasosDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio, out LinkedList<Expediente> lista)
    {
        lista = expedienteRepositorio.ConsultarTodos();
    }
}