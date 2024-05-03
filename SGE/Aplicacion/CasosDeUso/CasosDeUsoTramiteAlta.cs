namespace Aplicacion;

public class CasosDeUsoTramiteAlta
{
    public CasosDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio, Tramite t, int idUsuario)
    {
      tramiteRepositorio.AgregarRegistro(t, idUsuario);
    }
    public static void Ejecutar(ITramiteRepositorio tramiteRepositorio, Tramite t, int idUsuario)
    {
      tramiteRepositorio.AgregarRegistro(t, idUsuario);
    }
}