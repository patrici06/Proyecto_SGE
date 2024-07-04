namespace SGE.Aplicacion; 

public class CasoUsoBajaTramite
{
     private readonly ITramiteRepositorio _tramiteRepositorio;
     public CasoUsoBajaTramite(ITramiteRepositorio tramiteRepositorio){
        _tramiteRepositorio = tramiteRepositorio;
     }
     public void Ejecutar(int idTramite, int idUsuario){
        _tramiteRepositorio.ElimiarRegistro(idTramite,idUsuario);
     }
}