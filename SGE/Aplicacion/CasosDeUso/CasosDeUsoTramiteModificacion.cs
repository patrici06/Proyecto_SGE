using Aplicacion;

public class CasosDeUsoTramiteModificacion{
// Requiere Modificacion Previa de el Tramite
public static void uso(Tramite tramite,string dir)
    {
        LinkedList<string> temp = Safe(dir);
        LinkedList<string> modificada = new LinkedList<string>();
        using(StreamWriter writer = new StreamWriter(dir))
        {
            foreach(string act in temp)
            {
            string[] Act = act.Split("\t");
            string[] tramiteElem = tramite.ToString().Split("\t");
            if(Act[0] == tramiteElem[0])
            {
                modificada.AddLast(tramite.ToString()?? "");    
            } 
            else
            {
                modificada.AddLast(act);
            }
            }
            foreach(string aux in modificada)
            {
                writer.WriteLine(aux);
            }  
            writer.Close();
        }
    }
    //Retorna una linkedList Con Todos los tramiteentos del archivo
    private static LinkedList<string> Safe(string dir)
    {
        using(StreamReader reader = new StreamReader(dir)){
        LinkedList<string> temp = new LinkedList<string>();
        while(!reader.EndOfStream)
        {
            string add = reader.ReadLine()?? "Error Imposible";
            temp.AddLast(add);
        }
        reader.Close();
        return temp;
        }
    }
}