using Aplicacion;

public class CasosDeUsoTramiteModificacion
{
// Requiere Modificacion Previa de el Tramite
    public CasosDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, Tramite tramite, int idUsuario)
    {
        tramiteRepositorio.ModificarRegistro(tramite, idUsuario);
    }
}