namespace Aplicacion;

public class Expediente
{
    private static int s_id = 1;
    private int id;
    private string? caratula;
    private DateTime fechaCreacion;
    private DateTime fechaModificacion;
    private int idUsuarioModificacion;
    private EstadoExpediente estado;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Caratula
    {
        get => caratula != null ? caratula : "NULL"; 
        //Revisar Usar el manejo de excepciones visto en la clase 6 para una correcta 
        set {   try
                {
                    if(string.IsNullOrWhiteSpace(value))
                    {
                        throw new ValidacionException("Error : Contenido no valido El campo Esta Incompleto");
                    }
                    this.caratula = value;
                }
                catch (ValidacionException e)
                {
                    Console.WriteLine($"{e.Message}");
                }
             }
    }

    public DateTime FechaCreacion
    {
        get { return fechaCreacion;}
    }
    public DateTime FechaModificacion
    {
        get { return fechaModificacion;}
    }
    public int IdUsuarioModificacion
    {
        get { return idUsuarioModificacion;}
    }
    public EstadoExpediente Estado
    {
        get{ return estado; }
        set { estado = value; }
    }

    public Expediente()
    {
        caratula = "";
        id = s_id;
        s_id++;
        fechaCreacion = DateTime.Now;
        fechaModificacion = DateTime.Now;
    }
    //$"{id}\t{caratula}\t{fechaCreacion}\t{fechaModificacion}\t{idUsuarioModificacion}\t{estado}"
    private Expediente (string id, string caratula,string fechaCreacion, string fechaModificacion, string idUsuario,string estado)
    {
        this.id = int.Parse(id); 
        this.caratula = caratula; 
        this.fechaCreacion = DateTime.Parse(fechaCreacion); 
        this.fechaModificacion = DateTime.Parse(fechaModificacion); 
        this.idUsuarioModificacion = int.Parse(idUsuario);
        this.estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), estado);
    }
    public static Expediente Ensamblado(string cadena)
    {
       string[] partes = cadena.Split("\t");
        return new Expediente(partes[0], partes[1], partes[2], partes[3], partes[4],partes[5]);
    }

    public Expediente(string Caratula, EstadoExpediente Estado, int Usuario)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Caratula))
            {
                throw new ValidacionException("Error : Contenido no valido La carátula del expediente no puede estar vacía.");
            }
            id = s_id;
            s_id++;
            fechaCreacion = DateTime.Now;
            fechaModificacion = DateTime.Now;
            this.caratula = Caratula;
            this.estado = Estado;
            idUsuarioModificacion = Usuario;
        }
        catch(ValidacionException e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    private void ActualizarFechaModificacion(int idUsuario)
    {
        fechaModificacion = DateTime.Now;
        idUsuarioModificacion = idUsuario;
    } 

    public void ActualizarContenido(string contenido, int idUsuario)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(contenido))
            {
                throw new ValidacionException("Error : Contenido no valido El campo Esta Incompleto");
            }
            this.Caratula = contenido;
            ActualizarFechaModificacion(idUsuario);
        }
        catch (ValidacionException e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
    public override string ToString()
    {
        return $"{id}\t{caratula}\t{fechaCreacion}\t{fechaModificacion}\t{idUsuarioModificacion}\t{estado}";
    }
}