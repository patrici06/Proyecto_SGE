namespace SGE.Aplicacion;
public interface ITramiteRepositorio
{
    public void AgregarRegistro(Tramite tramite);
    public void ModificarRegistro(Tramite tramite, int idUsuario);
    public void ElimiarRegistro(Tramite tramite);
    public Tramite? ConsultaPorId(int idTramite);
    public List<Tramite>? ConsultaPorEtiqueta(EstadoTramite estado);
    public List<Tramite>? ConsultarTodos();
}