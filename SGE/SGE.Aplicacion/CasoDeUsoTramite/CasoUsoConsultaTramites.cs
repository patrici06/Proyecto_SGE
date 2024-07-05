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
        List<Tramite>? tramites = _tramiteRepositorio.ConsultarTodos(); 
        if(tramites == null || !tramites.Any()) throw new RepositorioException("No hay tramites En la DB");
        return tramites;
    }
}