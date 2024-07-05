namespace SGE.Aplicacion;

public class CasoUsoConsultaTramiteID
{
    private readonly ITramiteRepositorio _tramiteRepositorio;
    public CasoUsoConsultaTramiteID(ITramiteRepositorio tramiteRepositorio)
    {
        _tramiteRepositorio = tramiteRepositorio;
    }

    public Tramite Ejecutar(int idTramite)
    {
        return _tramiteRepositorio.ConsultaPorId(idTramite)?? throw new RepositorioException($"No se encuentra Id :{idTramite}");
    }
}