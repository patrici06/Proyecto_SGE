namespace SGE.Aplicacion; 

public class CasoUsoModificacionTramite
{
     private readonly ITramiteRepositorio _tramiteRepositorio;
    private readonly IExpedienteRepositorio _expedienteRepositorio;
     private readonly IServicioAutorizacion _usuarioValidador;
     private readonly ServicioCambioEstado _cambio;
     public CasoUsoModificacionTramite(ITramiteRepositorio tramiteRepositorio,IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion, ServicioCambioEstado cambioEstado){
        _tramiteRepositorio = tramiteRepositorio;
        _expedienteRepositorio = expedienteRepositorio;
        _usuarioValidador = servicioAutorizacion;
        _cambio = cambioEstado;
     }
     public void Ejecutar(Tramite tramite, Usuario idUsuario){
         if(!_usuarioValidador.TienePermiso(idUsuario, Permiso.TramiteModificacion)) throw new AutorizacionException($"No posee permiso {Permiso.TramiteModificacion}");
         Tramite? aux = _tramiteRepositorio.ConsultaPorId(tramite.Id);
         TramiteValidador.ValidarTramite(tramite);
         Expediente? padre = _expedienteRepositorio.ConsultaPorId(aux.Id);
         if(padre == null) throw new RepositorioException($"No existe Expediente con ID {tramite.ExpedienteId}");
         if(aux == null) throw new RepositorioException($" no se encontro Tramite {tramite.Id}"); 
         _tramiteRepositorio.ModificarRegistro(tramite, idUsuario.Id);
         _expedienteRepositorio.ModificarExpediente(_cambio.CambioEstado(padre, aux.EstadoTramite), idUsuario.Id); 
     }
}