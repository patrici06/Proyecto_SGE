namespace Aplicacion;

public class CasosDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    public void Ejecutar(out LinkedList<Expediente> lista)
    {
        lista = expedienteRepositorio.ConsultarTodos();
    }
}