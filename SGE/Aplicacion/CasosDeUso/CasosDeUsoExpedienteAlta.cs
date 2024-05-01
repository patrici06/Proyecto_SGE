namespace Aplicacion;

public class CasosDeUsoExpedienteAlta
{
    public static void Uso(Expediente expediente, string dir)
    {
    using (StreamWriter writer = new StreamWriter(dir, true))
    {
      writer.WriteLine(expediente);
      writer.Close();
    }
    }
}