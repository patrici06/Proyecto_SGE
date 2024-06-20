
namespace SGE.Aplicacion; 

public class ServicioExpedientes: IExpedienteRepositorio
{
     private readonly IExpedienteRepositorio _ExpedienteRepositorio;
     public ServicioExpedientes (IExpedienteRepositorio expedienteRepositorio){
          _ExpedienteRepositorio = expedienteRepositorio;
     }

    public void AltaExpediente(Expediente expediente)
    {
        _ExpedienteRepositorio.AltaExpediente(expediente);
    }

    public void BajaExpediente(int idExpediente)
    {
        _ExpedienteRepositorio.BajaExpediente(idExpediente);
    }

    public Expediente? ConsultaPorId(int id)
    {
          return  _ExpedienteRepositorio.ConsultaPorId(id);
    }

    public List<Expediente>? ConsultarTodos()
    {
        return _ExpedienteRepositorio.ConsultarTodos();
    }

    public bool ExisteId(int Id)
    {
       return _ExpedienteRepositorio.ExisteId(Id);
    }

    public void ModificarExpediente(Expediente expediente, int idUsuario)
    {
       _ExpedienteRepositorio.ModificarExpediente(expediente, idUsuario);
    }
}