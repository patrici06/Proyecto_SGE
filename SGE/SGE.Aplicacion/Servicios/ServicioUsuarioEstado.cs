
namespace SGE.Aplicacion;
public class ServicioUsuarioEstado
{
    public Usuario? Usuario { get; private set; }

    public event Action? OnChange;

    public void SetUsuario(Usuario usuario)
    {
        Usuario = usuario;
    }
}