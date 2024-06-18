using System.Collections;

namespace Aplicacion;
public class Tramite:IEnumerable
{
    private static int s_id = 1;
    public int id {get; private set; } 
    public int ExpedienteId{get; set;}
    //Delego Responsabilidad a la propiedad ExpedienteId.
    public string? contenido {get; private set; }   
    public DateTime fecha_hora_creacion{get;} = DateTime.Now;
    public DateTime fecha_hora_ultimaModificacion{get; private set; }
    public int idUsuario{get; private set; }
    public EstadoTramite estadoTramite{ get; private set;}
    
    
    public Tramite()
    {
        id  = s_id;
        s_id++;
        contenido = "";
    }
    private Tramite(string id,string idExpediente,string contenido,string creacion,string modificacion,string idUsuario,string estadoTramite)
    {
        this.id = int.Parse(id);
        this.ExpedienteId = int.Parse(idExpediente);
        this.idUsuario = int.Parse(idUsuario);
        this.contenido = contenido;
        this.fecha_hora_creacion = DateTime.Parse(creacion);
        this.fecha_hora_ultimaModificacion = DateTime.Parse(modificacion);
        //ValorPredeterminado
        this.estadoTramite = (EstadoTramite)Enum.Parse(typeof(EstadoTramite), estadoTramite);;
    }
    public static Tramite Ensamblador(string cadena)
    {
        string[] temp = cadena.Split("\t");
        return new Tramite(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5],temp[6]);
    }
    public Tramite (int idExpediente, string contenido, int idUsuario, EstadoTramite estadoTramite)
    {
        try
        {
        id  = s_id;
        s_id++;
        ExpedienteId = idExpediente;
        ActualizarContenido(contenido, idUsuario); 
        this.idUsuario = idUsuario;
        this.estadoTramite = estadoTramite;
        }
        catch        {
        }
    }

    //Metodo Privado Para Actualizacion UltimaModificacion
    private void UltimaModificacion(int idUsuario)
    {
        this.idUsuario = idUsuario;
        this.fecha_hora_ultimaModificacion = DateTime.Now; 
    }
    //MetodoParaActualizacion del contenido;
    public void ActualizarContenido(string contenido, int idUsuario)
    {   
            this.contenido = contenido;
            UltimaModificacion(idUsuario);
    }
    //Metodo para Actualizacion del estado Del tramite
    public void ActualizarEstado(EstadoTramite estadoTramite, int idUsuario)
    {
        this.estadoTramite = estadoTramite;
        UltimaModificacion(idUsuario);
    }
    public override string ToString()
    {
            return $"{id}\t{ExpedienteId}\t{contenido}\t{fecha_hora_creacion}\t{fecha_hora_ultimaModificacion}\t{idUsuario}\t{estadoTramite}";
    }
    //Completar
  public IEnumerator<Tramite> GetEnumerator()
        {
            if (this == null)
            {
                return new Tramite().GetEnumerator();
            }
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
}