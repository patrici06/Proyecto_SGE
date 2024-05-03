namespace Aplicacion;

public class CasosDeUsoExpedienteAlta
{
    public CasosDeUsoExpedienteAlta(IExpedienteRepositorio expedienteRepositorio, Expediente e, int idUsuario)
    {
      expedienteRepositorio.AltaExpediente(e, idUsuario);
    }
    public static void Ejecutar(IExpedienteRepositorio expedienteRepositorio, Expediente e, int idUsuario)
    {
      expedienteRepositorio.AltaExpediente(e, idUsuario);
    }
}