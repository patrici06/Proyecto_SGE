namespace Aplicacion;

public class CasosDeUsoExpedienteAlta(IExpedienteRepositorio repositorio)
{
    public void Ejecutar(Expediente e, int idUsuario)
    {
      repositorio.AltaExpediente(e, idUsuario);
    }
}