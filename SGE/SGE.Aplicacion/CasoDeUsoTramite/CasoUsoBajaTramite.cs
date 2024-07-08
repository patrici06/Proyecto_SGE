namespace SGE.Aplicacion; 

public class CasoUsoBajaTramite
{
     private readonly ITramiteRepositorio _tramiteRepositorio;
     private readonly IExpedienteRepositorio _expedienteRepositorio;
     private readonly ServicioCambioEstado _cambio;
     private readonly IServicioAutorizacion _usuarioValidador;
     public CasoUsoBajaTramite(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion usuarioValidador,IExpedienteRepositorio expedienteRepositorio, ServicioCambioEstado cambioEstado){
        _tramiteRepositorio = tramiteRepositorio;
        _expedienteRepositorio = expedienteRepositorio;
        _usuarioValidador = usuarioValidador;
        _cambio = cambioEstado;
     }
     public void Ejecutar(int idTramite, Usuario idUsuario){
      if(!_usuarioValidador.TienePermiso(idUsuario, Permiso.TramiteBaja)) throw new AutorizacionException($"No posee permiso {Permiso.TramiteBaja}");
      {
    Tramite? tramite = _tramiteRepositorio.ConsultaPorId(idTramite);
    if (tramite == null) throw new RepositorioException($"No se encontro Tramite id{idTramite}");

    Expediente? expedienteAsociado = _expedienteRepositorio.ConsultaPorId(tramite.ExpedienteId);
    if (expedienteAsociado == null) throw new RepositorioException("NO Pertenece a ningun Expediente");

    if (expedienteAsociado.Tramites == null || !expedienteAsociado.Tramites.Any())
    {
        throw new RepositorioException("NO Pertenece a ningun Tramite");
    }

    // Remover tramite del expediente
    expedienteAsociado.Tramites.Remove(tramite);

    if (!expedienteAsociado.Tramites.Any())
    {
        expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, EstadoTramite.PaseAlArchivo);
    }
    else
    {
        int lastIndex = expedienteAsociado.Tramites.Count - 1;
        if (lastIndex >= 0 && expedienteAsociado.Tramites[lastIndex].Id == idTramite)
        {
            if (lastIndex - 1 >= 0)
            {
                EstadoTramite estadoAnterior = expedienteAsociado.Tramites[lastIndex - 1].EstadoTramite;
                expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, estadoAnterior);
            }
            else
            {
                expedienteAsociado = _cambio.CambioEstado(expedienteAsociado, EstadoTramite.PaseAlArchivo);
            }
        }
      } 
         _tramiteRepositorio.ElimiarRegistro(tramite);
         _expedienteRepositorio.ModificarExpediente(expedienteAsociado, idUsuario.Id);
      }
   }
} 