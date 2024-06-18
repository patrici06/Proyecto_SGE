using System.Collections;

namespace Aplicacion;

public class Expediente:IEnumerable<Tramite>
{
    private static int s_id = 1;
    private int id;
    private string? caratula;
    private DateTime fechaCreacion;
    private DateTime fechaModificacion;
    private int idUsuarioModificacion;
    private List<Tramite>? tramites = null;
    private EstadoExpediente estado;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Caratula
    {
        get => caratula != null ? caratula : "NULL"; 
        //Todo el manejo de excepciones corresponde al programa principal, y la implementacion de estas al caso de uso 
        set => this.caratula = value;
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
    public List<Tramite>? Tramites
    {
        get
        {
            return tramites;
        }
        set
        {
            this.tramites = value;
        }
    }
    public Expediente()
    {
        caratula = "";
        id = s_id;
        s_id++;
        fechaCreacion = DateTime.Now;
        fechaModificacion = DateTime.Now;
        tramites = new List<Tramite>();
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

    public Expediente(string Caratula, EstadoExpediente Estado,List<Tramite>? tramites ,int Usuario)
    {
            id = s_id;
            s_id++;
            fechaCreacion = DateTime.Now;
            fechaModificacion = DateTime.Now;
            this.caratula = Caratula;
            this.estado = Estado;
            idUsuarioModificacion = Usuario;
            this.tramites = tramites;
    }

    private void ActualizarFechaModificacion(int idUsuario)
    {
        fechaModificacion = DateTime.Now;
        idUsuarioModificacion = idUsuario;
    } 

    public void ActualizarContenido(string contenido, int idUsuario)
    {
            this.Caratula = contenido;
            ActualizarFechaModificacion(idUsuario);
    }

    
    public override string ToString()
    {
            return $"{id}\t{caratula}\t{fechaCreacion}\t{fechaModificacion}\t{idUsuarioModificacion}\t{estado}";
    }
    //Completar
    public IEnumerator<Tramite> GetEnumerator()
        {
            if (tramites == null)
            {
                return new List<Tramite>().GetEnumerator();
            }
            return tramites.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
}