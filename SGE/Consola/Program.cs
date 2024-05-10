
using Aplicacion;
using Repositorios;
//Configuracion de los Casos de Uso y Repositorios

TramitesRepositorio tramitesRepositorio = new TramitesRepositorio("tramites.txt");
ExpedienteRepositorio expedienteRepositorio = new ExpedienteRepositorio(tramitesRepositorio, "Expedientes.txt"); 
EspecificacionCambioEstado cambioEstado = new EspecificacionCambioEstado();
ServicioActualizacionEstado servicioActualizacionEstado = new ServicioActualizacionEstado(expedienteRepositorio, cambioEstado);
CasosDeUsoExpedienteAlta ExpedienteAlta = new CasosDeUsoExpedienteAlta(expedienteRepositorio); 
CasosDeUsoExpedienteBaja ExpedienteBaja = new CasosDeUsoExpedienteBaja(expedienteRepositorio); 
CasosDeUsoExpedienteConsultaId ExpedienteConsultaId = new CasosDeUsoExpedienteConsultaId(expedienteRepositorio); 
CasosDeUsoExpedienteConsultaTodos ExpedienteConsultaTodos = new CasosDeUsoExpedienteConsultaTodos(expedienteRepositorio); 
CasosDeUsoExpedienteModificacion ExpedienteModificacion = new CasosDeUsoExpedienteModificacion(expedienteRepositorio);
CasosDeUsoTramiteAlta TramiteAlta = new CasosDeUsoTramiteAlta(tramitesRepositorio, servicioActualizacionEstado);  
CasosDeUsoTramiteBaja tramiteBajaBaja = new CasosDeUsoTramiteBaja(tramitesRepositorio, servicioActualizacionEstado);
CasosDeUsoTramiteConsultaPorEtiqueta casosDeUsoTramiteConsultaPorEtiqueta