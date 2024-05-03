namespace Aplicacion;
public interface ITramiteRepositorio
{
    public void Crear(int idUsuario);
    public void AgregarRegistro(Tramite tramite, int idUsuario);
    public void ModificarRegistro(Tramite tramite, int idUsuario);
    public void ElimiarRegistro(int idTramie, int idUsuario);
    public LinkedList<Tramite> ConsultaPorEtiqueta(EstadoTramite estado);
}