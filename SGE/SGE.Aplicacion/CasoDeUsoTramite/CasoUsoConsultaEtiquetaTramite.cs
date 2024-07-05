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
        return _tramiteRepositorio.ConsultaPorEtiqueta(estado)??throw new RepositorioException("No hay Coincidencias");
    }
}