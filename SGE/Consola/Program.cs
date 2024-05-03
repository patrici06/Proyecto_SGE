using Aplicacion; 
using Repositorios; 
ServicioAutorizacionProvisorio SA = new ServicioAutorizacionProvisorio();
TramiteValidador VL = new TramiteValidador();
ExpedienteValidador EV = new ExpedienteValidador();
File.Create("tramites.txt").Close();
TramitesRepositorio t = new TramitesRepositorio(SA,VL);
ExpedienteRepositorio e = new ExpedienteRepositorio(SA,EV,t);
Expediente expediente = new Expediente("Prueba", EstadoExpediente.RecienIniciado, 1);
CasosDeUsoExpedienteAlta.Ejecutar(e,expediente, 1);
Tramite tramite =  new Tramite(expediente.Id,"Pato", 1, EstadoTramite.Escrito_Presentado);
CasosDeUsoTramiteAlta.Ejecutar(t, tramite, 1);
CasosDeUsoExpedienteBaja.Ejecutar(e,1,1);





//pato puto