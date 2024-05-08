namespace Aplicacion;

public class CasosDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio)
{
    public void Ejecutar(Expediente e, int idUsuario)
    {
        expedienteRepositorio.ModificarExpediente(e,idUsuario);
    }
}