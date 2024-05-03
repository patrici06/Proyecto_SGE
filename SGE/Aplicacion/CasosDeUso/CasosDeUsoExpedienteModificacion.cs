namespace Aplicacion;

public class CasosDeUsoExpedienteModificacion
{
    public CasosDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, Expediente e, int idUsuario)
    {
        expedienteRepositorio.ModificarExpediente(e,idUsuario);
    }
}