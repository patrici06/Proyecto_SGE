namespace SGE.Aplicacion; 

public class CasoUsoBajaTramite
{
     private readonly ITramiteRepositorio _tramiteRepositorio;
     private readonly UsuarioValidador _usuarioValidador;
     public CasoUsoBajaTramite(ITramiteRepositorio tramiteRepositorio, UsuarioValidador usuarioValidador){
        _tramiteRepositorio = tramiteRepositorio;
        _usuarioValidador = usuarioValidador;
     }
     public void Ejecutar(int idTramite, Usuario idUsuario){
      if(!_usuarioValidador.TienePermiso(idUsuario, Permiso.TramiteModificacion)) throw new AutorizacionException($"No posee permiso {Permiso.TramiteModificacion}");
        _tramiteRepositorio.ElimiarRegistro(idTramite,idUsuario.Id);
     }
}