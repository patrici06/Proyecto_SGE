namespace Aplicacion; 

public class CasosDeUsoExpedienteBaja(IExpedienteRepositorio repositorio, ExpedienteValidador validador)
{
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        try {
            repositorio.BajaExpediente(idExpediente, idUsuario);
        }
        finally
        {}
    }
}

    
