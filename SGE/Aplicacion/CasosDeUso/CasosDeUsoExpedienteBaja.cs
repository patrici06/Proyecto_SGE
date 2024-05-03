namespace Aplicacion; 

public class CasosDeUsoExpedienteBaja
{
    public static void Ejecutar(IExpedienteRepositorio expedienteRepositorio, int idExpediente, int idUsuario)
    {
        expedienteRepositorio.BajaExpediente(idExpediente, idUsuario);
    }
}

    
