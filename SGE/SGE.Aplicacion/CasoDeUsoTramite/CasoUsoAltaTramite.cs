namespace SGE.Aplicacion;

public class CasoUsoAltaTramite
{
    private readonly ITramiteRepositorio _tramiteRepositorio;
    public CasoUsoAltaTramite(ITramiteRepositorio tramiteRepositorio)
    {
        _tramiteRepositorio = tramiteRepositorio;
    }

    public void Ejecutar(Tramite tramite)
    {
        _tramiteRepositorio.AgregarRegistro(tramite); 
    }
}