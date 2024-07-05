namespace SGE.Aplicacion;

public static class TramiteValidador
{
    public static void ValidarTramite(Tramite tramite)
    {
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new ValidacionException("El contenido del trámite no puede estar vacío.");
        }
    }
} 