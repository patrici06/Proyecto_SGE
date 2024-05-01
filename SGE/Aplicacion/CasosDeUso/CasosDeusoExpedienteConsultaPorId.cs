namespace Aplicacion; 
public class CasosDeUsoExpedienteConsultaId
{
   public static Expediente? Uso(int id, string dir)
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
   public static LinkedList<string> Safe(string dir)
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