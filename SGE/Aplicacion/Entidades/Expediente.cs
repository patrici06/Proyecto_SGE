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
        get { return caratula; }
        //Revisar Usar el manejo de excepciones visto en la clase 6 para una correcta 
        set {   try
                {
                    if(string.IsNullOrWhiteSpace(value))
                    {
                        throw new ContenidoException("Error : Contenido no valido","El campo Esta Incompleto");
                    }
                    this.caratula = value;
                }
                catch (ContenidoException e)
                {
                    Console.WriteLine($"{e.Message},{e.contenidoException}");
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
        caratula = " ";
        id = s_id;
        s_id++;
        fechaCreacion = DateTime.Now;
        fechaModificacion = DateTime.Now;
    }

    public Expediente(string Caratula, EstadoExpediente Estado, int Usuario)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Caratula))
            {
                throw new ContenidoException("Error : Contenido no valido", "La carátula del expediente no puede estar vacía.");
            }
            id = s_id;
            s_id++;
            fechaCreacion = DateTime.Now;
            fechaModificacion = DateTime.Now;
            this.caratula = Caratula;
            this.estado = Estado;
            idUsuarioModificacion = Usuario;
        }
        catch(ContenidoException e)
        {
            Console.WriteLine($"{e.Message}, {e.contenidoException}");
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
                throw new ContenidoException("Error : Contenido no valido", "El campo Esta Incompleto");
            }
            this.Caratula = contenido;
            ActualizarFechaModificacion(idUsuario);
        }
        catch (ContenidoException e)
        {
            Console.WriteLine($"{e.Message}, {e.contenidoException}");
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