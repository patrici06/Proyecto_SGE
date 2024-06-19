namespace Aplicacion; 

public interface IExpedienteRepositorio
{
    
    public void Crear(int idUsuario);
    public void AltaExpediente(Expediente expediente);
    public void ModificarExpediente(Expediente expediente);
    public void BajaExpediente(int idExpediente);
    public Expediente? ConsultaPorId(int id);
    public LinkedList<Expediente> ConsultarTodos();
    public Expediente? ConsultarExpedienteYTramites(int idExpediente);
}