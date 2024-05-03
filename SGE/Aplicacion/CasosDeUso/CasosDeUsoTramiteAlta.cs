namespace Aplicacion;

public class CasosDeUsoTramiteAlta
{
    public static void Uso(Tramite tramite, string dir)
    {
    using (StreamWriter writer = new StreamWriter(dir, true))
    {
      writer.WriteLine(tramite);
      writer.Close();
    }
    }
}