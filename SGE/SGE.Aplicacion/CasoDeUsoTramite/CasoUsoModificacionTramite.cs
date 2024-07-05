namespace SGE.Aplicacion; 

public class CasoUsoModificacionTramite
{
     private readonly ITramiteRepositorio _tramiteRepositorio;
     private readonly ServicioAutorizacion _usuarioValidador;
     public CasoUsoModificacionTramite(ITramiteRepositorio tramiteRepositorio, ServicioAutorizacion servicioAutorizacion){
        _tramiteRepositorio = tramiteRepositorio;
        _usuarioValidador = servicioAutorizacion;
     }
     public void Ejecutar(Tramite tramite, Usuario idUsuario){
         if(!_usuarioValidador.TienePermiso(idUsuario, Permiso.TramiteModificacion)) throw new AutorizacionException($"No posee permiso {Permiso.TramiteModificacion}");
         Tramite? aux = _tramiteRepositorio.ConsultaPorId(tramite.Id);
         TramiteValidador.ValidarTramite(tramite);
         if(aux == null) throw new RepositorioException($" no se encontro Tramite {tramite.Id}"); 
        _tramiteRepositorio.ModificarRegistro(tramite, idUsuario.Id);
     }
}