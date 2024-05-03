namespace Aplicacion;

public class CasosDeUsoTramiteBaja
{
        public static void Ejecutar(ITramiteRepositorio tramiteRepositorio,int idTramite, int idUsuario)
        {
            tramiteRepositorio.ElimiarRegistro(idTramite, idUsuario);
        }

}