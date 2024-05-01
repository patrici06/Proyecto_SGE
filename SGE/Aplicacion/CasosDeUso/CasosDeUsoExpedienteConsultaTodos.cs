namespace Aplicacion;

public class CasosDeUsoExpedienteConsultaTodos
{
    public static LinkedList<Expediente> Uso(string dir)
    {
    using (StreamReader reader = new StreamReader(dir, true))
    {
        LinkedList<Expediente> lista = new LinkedList<Expediente>();
        while(!reader.EndOfStream)
        {
            string linea = reader.ReadLine() ?? "ERROR IMPOSIBLE";
            Expediente e = Expediente.Ensamblado(linea);
            lista.AddLast(e);
        }  
        return lista;
    }
    }
}