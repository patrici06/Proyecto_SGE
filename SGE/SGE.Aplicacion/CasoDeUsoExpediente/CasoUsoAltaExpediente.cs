namespace SGE.Aplicacion; 

public class CasoUsoAltaExpediente
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    public CasoUsoAltaExpediente(IExpedienteRepositorio expedienteRepositorio){
        _ExpedienteRepositorio = expedienteRepositorio;
    }

    public void Ejecutar(Expediente expediente)
    {
        _ExpedienteRepositorio.AltaExpediente(expediente);
    }
}