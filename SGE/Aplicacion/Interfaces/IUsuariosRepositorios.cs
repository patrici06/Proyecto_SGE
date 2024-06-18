namespace Aplicacion; 

public interface IUsuarioRepositorios
{
    public void Crear(Usuario nuevo);
    public void Logear(Usuario usuario); 
    public void OtorgarPermisos (Usuario usuario, List<Permiso> permisos); 

}