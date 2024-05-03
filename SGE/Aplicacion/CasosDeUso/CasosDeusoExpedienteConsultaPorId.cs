namespace Aplicacion; 
public class CasosDeUsoExpedienteConsultaId
{
    
   public static Expediente? UsoSoloExpediente(int id, string dir)
   {
        Expediente? Retorno = null; 
        using(StreamReader reader =  new StreamReader (dir))
        {
            while(!reader.EndOfStream)
            {
                string linea = reader.ReadLine() ?? "ERROR IMPOSIBLE";
                string[] partes = linea.Split("\t"); 
                if(partes[0] == id.ToString())
                {
                    Retorno = Expediente.Ensamblado(linea);
                    break;
                }
            }  
        }
        return Retorno;
   }
    //  Requiere implementacion para Retornar el Expediente Y la Lista De tramites del mismo
     public static LinkedList<Tramite> GetExpedienteYTramites(out Expediente? expediente,int id, string dirExpediente, string dirTramites)
     {
        LinkedList<Tramite> retorno =  new LinkedList<Tramite>(); 
        expediente = UsoSoloExpediente(id, dirExpediente); 
        if(expediente!= null){
            using (StreamReader reader = new StreamReader(dirTramites))
            {
             while(!reader.EndOfStream)
             {
             string linea = reader.ReadLine() ?? "";
             string[] elems = linea.Split("\t");
             if(elems[1] == id.ToString())
                {
                    retorno.AddLast(Tramite.Ensamblador(linea));
                }
             }
             reader.Close();
            }
        }
        return retorno;
     }

   private static LinkedList<string> Safe(string dir)
    {
        using(StreamReader reader = new StreamReader(dir)){
        LinkedList<string> temp = new LinkedList<string>();
        while(!reader.EndOfStream)
        {
            string add = reader.ReadLine()?? "ERROR IMPOSIBLE";
            temp.AddLast(add);
        }
        reader.Close();
        return temp;
        }
    }
}