namespace SGE.Aplicacion;

public class CasoUsoConsultaTramites
{
    private readonly ITramiteRepositorio _tramiteRepositorio;
    public CasoUsoConsultaTramites(ITramiteRepositorio tramiteRepositorio)
    {
        _tramiteRepositorio = tramiteRepositorio;
    }

    public List<Tramite>? Ejecutar()
    {
        return _tramiteRepositorio.ConsultarTodos();
    }
}