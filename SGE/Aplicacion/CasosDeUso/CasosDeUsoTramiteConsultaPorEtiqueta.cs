namespace Aplicacion; 

public class CasosDeUsoTramiteConsultaPorEtiqueta
{
    public static LinkedList<Tramite> Uso(EstadoTramite estado, string dir)
    {
        LinkedList<Tramite>? retorno = new LinkedList<Tramite>();
        using (StreamReader reader = new StreamReader(dir))
        {
            while (!reader.EndOfStream)
            {
                string linea = reader.ReadLine() ?? "";
                string[] parts = linea.Split("\t"); 
                if((EstadoTramite)Enum.Parse(typeof(EstadoTramite), parts[6]) == estado)
                {
                    retorno.AddLast(Tramite.Ensamblador(linea));
                }
            }
            reader.Close();
        }
        return retorno;
    }
}