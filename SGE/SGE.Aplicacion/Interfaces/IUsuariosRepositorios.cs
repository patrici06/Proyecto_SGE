namespace SGE.Aplicacion; 

public interface IUsuariosRepositorios
{
        public void Crear(Usuario nuevo);
        public Usuario? Logear(string correo, string contrasena);
        public void OtorgarPermisos(Usuario usuario, Permiso permiso);
        public void EliminarUsuario(int id);
        public void ModificarUsuario(Usuario usuario);
        public Usuario? ObtenerUsuarioPorId(int id);
        public List<Usuario> ListarUsuarios();

}