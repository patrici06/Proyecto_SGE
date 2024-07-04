namespace SGE.Aplicacion; 

public class CasoUsoBajaExpediente
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    public CasoUsoBajaExpediente(IExpedienteRepositorio expedienteRepositorio){
        _ExpedienteRepositorio = expedienteRepositorio;
    }

    public void Ejecutar(int idExpediente)
    {
        _ExpedienteRepositorio.BajaExpediente(idExpediente);
    }
}