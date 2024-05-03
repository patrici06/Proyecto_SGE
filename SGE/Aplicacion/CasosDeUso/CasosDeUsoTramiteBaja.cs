namespace Aplicacion;

public class CasosDeUsoTramiteBaja
{
    public static void UsoIdTramite(Tramite tramite, string dir)
    {
        LinkedList<string> temp = Safe(dir);
        using(StreamWriter writer = new StreamWriter(dir))
        {
        LinkedList<string> modificada = new LinkedList<string>();
        
        foreach(string act in temp)
        {
            string[]resumen = act.Split("\t");
            string[] Elem = tramite.ToString().Split("\t");
            if (resumen[0] != Elem[0])
            {
              modificada.AddLast(act);
            }
        }
        foreach(string act in modificada)
        {
            writer.WriteLine(act);
        }
        writer.Close();
        }
    }
    public static void UsoIdExpediente(string id, string dir)
    {
        LinkedList<string> temp = Safe(dir);
        using(StreamWriter writer = new StreamWriter(dir))
        {
        LinkedList<string> modificada = new LinkedList<string>();
        
        foreach(string act in temp)
        {
            string[]resumen = act.Split("\t");
            if (resumen[1] != id)
            {
              modificada.AddLast(act);
            }
        }
        foreach(string act in modificada)
        {
            writer.WriteLine(act);
        }
        writer.Close();
        }
    }
    private static LinkedList<string> Safe(string dir)
    {
        using(StreamReader reader = new StreamReader(dir)){
        LinkedList<string> temp = new LinkedList<string>();
        while(!reader.EndOfStream)
        {
            string line =  reader.ReadLine()?? " ERROR IMPOSIBLE"; 
            temp.AddLast(line);
        }
        reader.Close();
        return temp;
        }
    }
}