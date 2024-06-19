namespace Aplicacion; 

public class Usuario
{
    public int id{get; set;}
    public string? nombre{get; set;}
    public string? apellido{get;set;}
    public string? correo{get;set;}
    public int? contraseñia {get; set;}
    public List<Permiso>? permisos {get; set;}
    public Usuario()
    {

    }
    public Usuario(string nombre, string apellido, string correo,int contrase, List<Permiso> permisos){
        this.nombre= nombre;
        this.apellido=apellido;     
        this.correo=correo;
        this.contraseñia=contrase;
        this.permisos=permisos;
    }
}