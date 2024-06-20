namespace SGE.Aplicacion; 

public interface IExpedienteRepositorio
{
    
    //public void Crear(int idUsuario);
    public void AltaExpediente(Expediente expediente);
    public void ModificarExpediente(Expediente expediente, int idUsuario);
    public void BajaExpediente(int idExpediente);
    public Expediente? ConsultaPorId(int id);
    public List<Expediente>? ConsultarTodos();
    //public Expediente? ConsultarExpedienteYTramites(int idExpediente);
}