namespace SGE.Aplicacion; 

public class Usuario
{
    public int Id{get; set;}
    public string nombre{get; set;} = "";
    public string apellido{get;set;} = "";
    public string correo{get;set;} = "";
    public string contrasena {get; set;} = "";
    public List<Permiso> permisos {get; set;}

    public Usuario()
    {
        this.permisos = new List<Permiso>();
    }
    public Usuario(string nombre, string apellido, string correo,string contrase, List<Permiso> Permisos){
        this.nombre= nombre;
        this.apellido=apellido;     
        this.correo=correo;
        this.contrasena= contrase;
        this.permisos = Permisos ?? new List<Permiso>();
    }
    public Usuario(Usuario user){
        this.Id = user.Id; 
        this.contrasena = user.contrasena;
        this.correo = user.correo; 
        this.permisos = user.permisos;
        this.nombre = user.nombre; 
    }

}