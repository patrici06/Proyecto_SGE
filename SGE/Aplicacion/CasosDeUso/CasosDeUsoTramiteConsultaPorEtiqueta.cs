namespace Aplicacion; 

public class CasosDeUsoTramiteConsultaPorEtiqueta (ITramiteRepositorio tramiteRepositorio)
{

    public LinkedList<Tramite> Uso(EstadoTramite estadoTramite)
    {
        return tramiteRepositorio.ConsultaPorEtiqueta(estadoTramite);
    }
}