using SGE.Aplicacion;
using SGE.Repositorios;
using System;
using System.Security.Cryptography;


namespace SGE.Repositorios;

public class UsuarioRepositorio : IUsuariosRepositorios
{
    private readonly DataContext _context;

    public UsuarioRepositorio(DataContext context)
    {
        _context = context;
    }

    public void Crear(Usuario nuevo)
    {
        _context.Usuarios.Add(nuevo);
        _context.SaveChanges();
    }

    public Usuario? Logear(string Correo, string Contrasena)
    {
        var user = _context.Usuarios.FirstOrDefault(u => u.correo == Correo);
        if(user!= null)
        {
            if(ServicioHash.validarContrasena(Contrasena, user.contrasena))
                return user;
            else    
                throw new ValidacionException("Error: La contraseña no es Correcta");
        }
        else
            throw new RepositorioException("Error de Usuario: No hay un Usuario con ese ID");
    }

    public void OtorgarPermisos(Usuario usuario, Permiso permiso)
    {
        var user = _context.Usuarios.Find(usuario.Id);
        if (user != null)
        {
            user.permisos.Add(permiso);
            _context.Update(user);
            _context.SaveChanges();
        }
        else
            throw new RepositorioException("Error de Usuario: No hay un Usuario con ese ID");
    }

    public void EliminarUsuario(int id) 
    {
        var user = _context.Usuarios.Find(id);
        if (user != null)
        {
            _context.Usuarios.Remove(user);
            _context.SaveChanges();
        }
        else
            throw new RepositorioException("Error de Usuario: No hay un Usuario con ese ID");
    }

    public void ModificarUsuario(Usuario usuario)
    {
        var user = _context.Usuarios.Find(usuario.Id);
        if (user != null)
        {
            user.nombre = usuario.nombre;
            user.apellido = usuario.apellido;
            user.correo = usuario.correo;
            user.contrasena = usuario.contrasena;
            user.permisos = usuario.permisos;
            _context.SaveChanges();
        }
        else
            throw new RepositorioException("Error de Usuario: No hay un Usuario con ese ID");
    }

    public Usuario? ObtenerUsuarioPorId(int idUsuario)
    {
        var user = _context.Usuarios.Find(idUsuario);
        if(user != null)
            return user;
        else
            throw new RepositorioException("Error de Usuario: No hay un Usuario con ese ID");
    }

    public List<Usuario> ListarUsuarios()
    {
        return _context.Usuarios.ToList();
    }

}