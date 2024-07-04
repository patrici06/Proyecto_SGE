namespace SGE.Aplicacion; 

public class CasoUsoConsultaExpedienteID
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    public CasoUsoConsultaExpedienteID(IExpedienteRepositorio expedienteRepositorio){
        _ExpedienteRepositorio = expedienteRepositorio;
    }

    public Expediente? Ejecutar(int id)
    {
          return  _ExpedienteRepositorio.ConsultaPorId(id);
    }
}