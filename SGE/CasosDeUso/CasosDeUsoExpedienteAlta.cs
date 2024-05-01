namespace Aplicacion;

public class CasoDeUsoExpedienteAlta(Expediente expediente, string dir){
    using (StreamReader reader = new StreamReader(dir, true))
    {
      reader.WriteLine(expediente).Close();
    }
}