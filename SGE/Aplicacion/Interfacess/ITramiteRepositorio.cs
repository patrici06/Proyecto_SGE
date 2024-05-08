namespace Aplicacion;
public interface ITramiteRepositorio
{
    public void Crear(int idUsuario);
    public void AgregarRegistro(Tramite tramite, int idUsuario);
    public void ModificarRegistro(Tramite tramite, int idUsuario);
    public void ElimiarRegistro(int idTramie, int idUsuario);
    public Tramite? ConsultaPorId(int idTramite);
    public LinkedList<Tramite> ConsultaPorEtiqueta(EstadoTramite estado);
}