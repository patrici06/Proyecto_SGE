namespace SGE.Aplicacion; 

public class CasoUsoConsultaExpedientes
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    public CasoUsoConsultaExpedientes(IExpedienteRepositorio expedienteRepositorio){
        _ExpedienteRepositorio = expedienteRepositorio;
    }

    public List<Expediente>? Ejecutar()
    {
        return _ExpedienteRepositorio.ConsultarTodos();
    }
}