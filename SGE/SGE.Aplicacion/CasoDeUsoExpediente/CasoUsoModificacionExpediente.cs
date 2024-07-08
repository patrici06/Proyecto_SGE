namespace SGE.Aplicacion; 

public class CasoUsoModificacionExpediente
{
    private readonly IExpedienteRepositorio _ExpedienteRepositorio;
    private readonly IServicioAutorizacion _UsuarioValidador;
    public CasoUsoModificacionExpediente(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion _usuarioValidador){
        _ExpedienteRepositorio = expedienteRepositorio;
        _UsuarioValidador = _usuarioValidador;
    }

    public void Ejecutar(Expediente expediente, Usuario idUsuario)
    {
        if(!_UsuarioValidador.TienePermiso(idUsuario, Permiso.ExpedienteModificacion)) throw new AutorizacionException($"No posee permiso {Permiso.ExpedienteModificacion}");
        Expediente? exp = _ExpedienteRepositorio.ConsultaPorId(expediente.Id);
        ExpedienteValidador.ValidarExpediente(exp);
        if(exp == null) throw new RepositorioException($" No se encontro un Expediente con ID {expediente.Id}");
       _ExpedienteRepositorio.ModificarExpediente(expediente, idUsuario.Id);
    }
}