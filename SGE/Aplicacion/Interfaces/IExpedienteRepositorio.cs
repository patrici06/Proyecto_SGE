namespace Aplicacion; 

public interface IExpedienteRepositorio
{
    
    public void Crear(int idUsuario);
    public void AltaExpediente(Expediente expediente, int idUsuario);
    public void ModificarExpediente(Expediente expediente, int idUsuario);
    public void BajaExpediente(int idExpediente, int idUsuario);
    public Expediente? ConsultaPorId(int id);
    public LinkedList<Expediente> ConsultarTodos();
    public Expediente? ConsultarExpedienteYTramites(int idExpediente);
}