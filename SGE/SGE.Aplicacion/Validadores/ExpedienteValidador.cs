namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static void ValidarExpediente(Expediente expediente)
    {
        if (string.IsNullOrWhiteSpace(expediente.Caratula))
        {
            throw new ValidacionException("La carátula del expediente no puede estar vacía.");
        }
        if (expediente.FechaCreacion == null)
        {
            throw new ValidacionException("La Fecha del expediente no puede estar vacía.");
        }
    }
}