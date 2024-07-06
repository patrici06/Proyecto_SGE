namespace SGE.Aplicacion; 

public class CasoUsoModificacionTramite
{
     private readonly ITramiteRepositorio _tramiteRepositorio;
    private readonly IExpedienteRepositorio _expedienteRepositorio;
     private readonly ServicioAutorizacion _usuarioValidador;
     public CasoUsoModificacionTramite(ITramiteRepositorio tramiteRepositorio,IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacion servicioAutorizacion){
        _tramiteRepositorio = tramiteRepositorio;
        _expedienteRepositorio = expedienteRepositorio;
        _usuarioValidador = servicioAutorizacion;
     }
     public void Ejecutar(Tramite tramite, Usuario idUsuario){
         if(!_usuarioValidador.TienePermiso(idUsuario, Permiso.TramiteModificacion)) throw new AutorizacionException($"No posee permiso {Permiso.TramiteModificacion}");
         Tramite? aux = _tramiteRepositorio.ConsultaPorId(tramite.Id);
         TramiteValidador.ValidarTramite(tramite);
         if(_expedienteRepositorio.ConsultaPorId(tramite.ExpedienteId) == null) throw new RepositorioException($"No existe Expediente con ID {tramite.ExpedienteId}");
         if(aux == null) throw new RepositorioException($" no se encontro Tramite {tramite.Id}"); 
        _tramiteRepositorio.ModificarRegistro(tramite, idUsuario.Id);
     }
}