namespace Aplicacion;

public class CasosDeUsoExpedienteAlta(IExpedienteRepositorio repositorio, ExpedienteValidador validador)
{
    public void Ejecutar(Expediente e, int idUsuario)
    {
      try 
      {
        validador.ValidarExpediente(e,idUsuario);
        repositorio.AltaExpediente(e, idUsuario);
      }
      finally{
      }
    }
}