namespace Aplicacion; 

public class CasosDeUsoExpedienteBaja(IExpedienteRepositorio repositorio)
{
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        repositorio.BajaExpediente(idExpediente, idUsuario);
    }
}

    
