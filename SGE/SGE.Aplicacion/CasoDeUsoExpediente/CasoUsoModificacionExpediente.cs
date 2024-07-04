namespace SGE.Aplicacion; 

public class CasoUsoModificacionExpediente
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    public CasoUsoModificacionExpediente(IExpedienteRepositorio expedienteRepositorio){
        _ExpedienteRepositorio = expedienteRepositorio;
    }

    public void Ejecutar(Expediente expediente, int idUsuario)
    {
       _ExpedienteRepositorio.ModificarExpediente(expediente, idUsuario);
    }
}