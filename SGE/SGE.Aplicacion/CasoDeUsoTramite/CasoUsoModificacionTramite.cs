namespace SGE.Aplicacion; 

public class CasoUsoModificacionTramite
{
     private readonly ITramiteRepositorio _tramiteRepositorio;
     public CasoUsoModificacionTramite(ITramiteRepositorio tramiteRepositorio){
        _tramiteRepositorio = tramiteRepositorio;
     }
     public void Ejecutar(Tramite tramite, int idUsuario){
        _tramiteRepositorio.ModificarRegistro(tramite, idUsuario);
     }
}