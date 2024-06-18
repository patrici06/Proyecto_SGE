namespace Aplicacion;

public class ExpedienteValidador
{
    public void ValidarExpediente(Expediente expediente, int Usuario)
    {
        if (string.IsNullOrWhiteSpace(expediente.Caratula))
        {
            throw new ValidacionException("La carátula del expediente no puede estar vacía.");
        }
    }
}