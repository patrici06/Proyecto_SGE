namespace SGE.Aplicacion; 

public class CasoUsoConsultaExpedientes
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    public CasoUsoConsultaExpedientes(IExpedienteRepositorio expedienteRepositorio){
        _ExpedienteRepositorio = expedienteRepositorio;
    }

    public List<Expediente>? Ejecutar()
    {
        List<Expediente>? expedientes = _ExpedienteRepositorio.ConsultarTodos();
        if(expedientes == null || !expedientes.Any()) throw new RepositorioException("No hay Expedientes En la DB");
        return expedientes;
    }
}