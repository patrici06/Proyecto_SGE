namespace Aplicacion;

public class TramiteValidador
{
    public void ValidarTramite(Tramite tramite)
    {
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new ValidacionException("El contenido del trámite no puede estar vacío.");
        }

        if (tramite.IdUsuario <= 0)
        {
            throw new ValidacionException("El ID de usuario de la última modificación del trámite no es válido.");
        }
    }
} 