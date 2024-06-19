namespace Aplicacion;

public class TramiteValidador
{
    public void ValidarTramite(Tramite tramite)
    {
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new ValidacionException("El contenido del trámite no puede estar vacío.");
        }
    }
} 