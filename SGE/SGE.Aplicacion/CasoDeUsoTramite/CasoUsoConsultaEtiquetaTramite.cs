namespace SGE.Aplicacion;

public class CasoUsoConsultaEtiquetaTramite
{
    private readonly ITramiteRepositorio _tramiteRepositorio;
    public CasoUsoConsultaEtiquetaTramite(ITramiteRepositorio tramiteRepositorio)
    {
        _tramiteRepositorio = tramiteRepositorio;
    }

    public List<Tramite> Ejecutar(EstadoTramite estado)
    {
          List<Tramite>? tramites = _tramiteRepositorio.ConsultaPorEtiqueta(estado); 
        if(tramites == null || !tramites.Any()) throw new RepositorioException("No hay tramites En la DB");
        return tramites;
    }
}