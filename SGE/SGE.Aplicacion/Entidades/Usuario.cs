namespace Aplicacion; 

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
        this.contrasena= ServicioHash.generarHashContrasena(contrase);
        this.permisos = Permisos ?? new List<Permiso>();
    }

}