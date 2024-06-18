
using Aplicacion;
using Repositorios;

//Configuracion de los Casos de Uso y Repositorios
TramitesRepositorio tramitesRepositorio = new TramitesRepositorio("Tramites.txt");
tramitesRepositorio.Crear(1);
ExpedienteRepositorio expedienteRepositorio = new ExpedienteRepositorio(tramitesRepositorio, "Expedientes.txt"); 
expedienteRepositorio.Crear(1);
EspecificacionCambioEstado cambioEstado = new EspecificacionCambioEstado();
ServicioActualizacionEstado servicioActualizacionEstado = new ServicioActualizacionEstado(expedienteRepositorio, cambioEstado);
CasosDeUsoExpedienteAlta ExpedienteAlta = new CasosDeUsoExpedienteAlta(expedienteRepositorio); 
CasosDeUsoExpedienteBaja ExpedienteBaja = new CasosDeUsoExpedienteBaja(expedienteRepositorio); 
CasosDeUsoExpedienteConsultaId ExpedienteConsultaId = new CasosDeUsoExpedienteConsultaId(expedienteRepositorio);
CasoDeUsoExpedienteYTramites casosDeUsoExpedienteYTramites = new CasoDeUsoExpedienteYTramites(expedienteRepositorio);
CasosDeUsoExpedienteConsultaTodos ExpedienteConsultaTodos = new CasosDeUsoExpedienteConsultaTodos(expedienteRepositorio); 
CasosDeUsoExpedienteModificacion ExpedienteModificacion = new CasosDeUsoExpedienteModificacion(expedienteRepositorio);
CasosDeUsoTramiteAlta TramiteAlta = new CasosDeUsoTramiteAlta(tramitesRepositorio, servicioActualizacionEstado);  
CasosDeUsoTramiteBaja tramiteBaja = new CasosDeUsoTramiteBaja(tramitesRepositorio, servicioActualizacionEstado);
CasosDeUsoTramiteConsultaPorEtiqueta TramiteConsultaPorEtiqueta = new CasosDeUsoTramiteConsultaPorEtiqueta(tramitesRepositorio);
CasosDeUsoTramiteModificacion TramiteModificacion = new CasosDeUsoTramiteModificacion(tramitesRepositorio, servicioActualizacionEstado);
ServicioAutorizacionProvisorio servicioAutorizacion = new ServicioAutorizacionProvisorio();
////Fin Configuracion/////
int usuario = 1;
bool ok = true;
while(ok)
{
    int opcion; 
    Console.WriteLine("_________________________________________________________________________");
    Console.WriteLine("Igrese 1 para Crear un Tramite");
    Console.WriteLine("Ingrese 2 para Consular Tramites Por Etiqueta");
    Console.WriteLine("Ingrese 3 Para Modificar Tramite por uno nuevo"); 
    Console.WriteLine("Ingrese 4 para Dar de Baja un tramite por id");
    Console.WriteLine("Ingrese 5 para Crear Un Expediente");
    Console.WriteLine("Ingrese 6 Consultar Un expediente por ID y sus Tramites");
    Console.WriteLine("Ingrese 7 Consultar Todos los expedientes");
    Console.WriteLine("Ingrese 8 Modificar un expediente por uno nuevo con su mismo id");
    Console.WriteLine("Ingrese 9 Para Eliminar Un Expediente");
    opcion = int.Parse(Console.ReadLine()??"10");
    
    if(servicioAutorizacion.PoseeElPermiso(usuario))
    {
        switch (opcion){
        case 1 :
        { 
            Console.WriteLine ("Ingrese id expediente al que pertenece (numerico)"); 
            int idExpediente = int.Parse(Console.ReadLine()??"0");
            Console.WriteLine("Ingrese Contendio del Tramite"); 
            string contenido = Console.ReadLine()??"";
            Console.WriteLine($"Eliga el Estado del Tramite:\n1:{EstadoTramite.Despacho}\n2:{EstadoTramite.EscritoPresentado}\n3:{EstadoTramite.Notificacion}\n4:{EstadoTramite.PaseAEstudio}\n5:{EstadoTramite.PaseAlArchivo}\n6:{EstadoTramite.Resolucion}");
            opcion = int.Parse(Console.ReadLine()??"1");
            EstadoTramite estadoTramite = EstadoTramite.EscritoPresentado;
            switch(opcion)
            {
                case 1: estadoTramite = EstadoTramite.Despacho; break;
                case 2: estadoTramite = EstadoTramite.EscritoPresentado; break;
                case 3: estadoTramite = EstadoTramite.Notificacion; break;
                case 4: estadoTramite = EstadoTramite.PaseAEstudio; break; 
                case 5: estadoTramite = EstadoTramite.PaseAlArchivo; break; 
                case 6: estadoTramite = EstadoTramite.Resolucion; break;
            }
            Tramite tramite = new Tramite(idExpediente, contenido, usuario,estadoTramite) ;
            Console.WriteLine("Opcion 1: modificarContenido \nOpcion2: EstadoTramite \nOpcion3: altaTramite");
            opcion = int.Parse(Console.ReadLine()??"1");
            switch(opcion)
            {
                case 1:
                {
                     Console.WriteLine("Ingrese Nuevo Contenido");
                     contenido = Console.ReadLine()??"";
                     tramite.ActualizarContenido(contenido, usuario);
                     TramiteAlta.Ejecutar(tramite,usuario);
                     break;
                }
                case 2: 
                {
                Console.WriteLine($"Eliga el Estado del Tramite:\n 1:{EstadoTramite.Despacho}\n2:{EstadoTramite.EscritoPresentado}\n3:{EstadoTramite.Notificacion}\n4:{EstadoTramite.PaseAEstudio}\n5:{EstadoTramite.PaseAlArchivo}\n6:{EstadoTramite.Resolucion}");
                opcion = int.Parse(Console.ReadLine()??"1");
                switch(opcion)
                {
                    case 1: estadoTramite = EstadoTramite.Despacho; break;
                    case 2: estadoTramite = EstadoTramite.EscritoPresentado; break;
                    case 3: estadoTramite = EstadoTramite.Notificacion; break;
                    case 4: estadoTramite = EstadoTramite.PaseAEstudio; break; 
                    case 5: estadoTramite = EstadoTramite.PaseAlArchivo; break; 
                    case 6: estadoTramite = EstadoTramite.Resolucion; break;
                    
                 }
                 TramiteAlta.Ejecutar(tramite,usuario);
                 break;
                }
                case 3:
                {
                  TramiteAlta.Ejecutar(tramite,usuario);      
                  break;  
                }
            }
        break;
        }
        //"Ingrese 2 para Consular Tramites Por Etiqueta
        case 2: 
        {
            Console.WriteLine("Seleccione una etiqueta de estado:");
            Console.WriteLine($"1:{EstadoTramite.Despacho}");
            Console.WriteLine($"2:{EstadoTramite.EscritoPresentado}");
            Console.WriteLine($"3:{EstadoTramite.Notificacion}");
            Console.WriteLine($"4:{EstadoTramite.PaseAEstudio}");
            Console.WriteLine($"5:{EstadoTramite.PaseAlArchivo}");
            Console.WriteLine($"6:{EstadoTramite.Resolucion}");
            opcion = int.Parse(Console.ReadLine()??"");
            EstadoTramite estadoTramite = EstadoTramite.EscritoPresentado;
            switch(opcion)
                {
                 case 1: estadoTramite = EstadoTramite.Despacho; break;
                 case 2: estadoTramite = EstadoTramite.EscritoPresentado; break;
                 case 3: estadoTramite = EstadoTramite.Notificacion; break;
                 case 4: estadoTramite = EstadoTramite.PaseAEstudio; break; 
                 case 5: estadoTramite = EstadoTramite.PaseAlArchivo; break; 
                 case 6: estadoTramite = EstadoTramite.Resolucion; break;
                }
            LinkedList<Tramite> tramites = new LinkedList<Tramite>(); 
            tramites = TramiteConsultaPorEtiqueta.Uso(estadoTramite);
            foreach(Tramite t in tramites)
            {
                Console.WriteLine(t);
            }
            break;      
        }
        // Console.WriteLine("Ingrese 3 Para Modificar Tramite por uno nuevo"); 
        case 3:
        {
            Console.WriteLine ("Ingrese id expediente al que pertenece (numerico)"); 
            int idExpediente = int.Parse(Console.ReadLine()??"0");
            Tramite? tramite = tramitesRepositorio.ConsultaPorId(idExpediente);
            if(tramite != null){
            Console.WriteLine("Ingrese Contendio del Tramite"); 
            string contenido = Console.ReadLine()??"";
            Console.WriteLine($"Eliga el Estado del Tramite:\n1:{EstadoTramite.Despacho}\n2:{EstadoTramite.EscritoPresentado}\n3:{EstadoTramite.Notificacion}\n4:{EstadoTramite.PaseAEstudio}\n5:{EstadoTramite.PaseAlArchivo}\n6:{EstadoTramite.Resolucion}");
            opcion = int.Parse(Console.ReadLine()??"1");
            EstadoTramite estadoTramite = EstadoTramite.EscritoPresentado;
            switch(opcion)
            {
                case 1: estadoTramite = EstadoTramite.Despacho; break;
                case 2: estadoTramite = EstadoTramite.EscritoPresentado; break;
                case 3: estadoTramite = EstadoTramite.Notificacion; break;
                case 4: estadoTramite = EstadoTramite.PaseAEstudio; break; 
                case 5: estadoTramite = EstadoTramite.PaseAlArchivo; break; 
                case 6: estadoTramite = EstadoTramite.Resolucion; break;
            }
            tramite.ActualizarContenido(contenido,usuario);
            tramite.ActualizarEstado(estadoTramite, usuario);
            TramiteModificacion.Ejecutar(tramite, usuario);
            }
            break;
        }
        //Console.WriteLine("Ingrese 4 para Dar de Baja un tramite por id");
        case 4:
        {
            Console.WriteLine("Ingrese un id Para eliminar el tramite asociado");
            int id = int.Parse(Console.ReadLine()??"-1");
            tramiteBaja.Ejecutar(id, usuario);
            break;
        }
       /*
     Ingrese 5 para Crear Un Expediente");
     */
        case 5: 
        {
            Console.WriteLine("Ingrese Contenido del expediente"); 
            string contenido = Console.ReadLine()??""; 
            Console.WriteLine("Ingrese un numero asociado al estado del expediente");
            Console.WriteLine($"1:{EstadoExpediente.ConResolucion}");
            Console.WriteLine($"2:{EstadoExpediente.EnNotificacion}");
            Console.WriteLine($"3:{EstadoExpediente.Finalizado}"); 
            Console.WriteLine($"4:{EstadoExpediente.ParaResolver}");
            Console.WriteLine($"5:{EstadoExpediente.RecienIniciado}");
            opcion  = int.Parse(Console.ReadLine()??"-1");
            EstadoExpediente estadoExpediente = EstadoExpediente.RecienIniciado;
            switch(opcion)
            {
                case 1: estadoExpediente = EstadoExpediente.ConResolucion; break;
                case 2: estadoExpediente = EstadoExpediente.EnNotificacion; break;
                case 3: estadoExpediente = EstadoExpediente.Finalizado;break;
                case 4: estadoExpediente = EstadoExpediente.ParaResolver;break; 
                case 5: estadoExpediente = EstadoExpediente.RecienIniciado;break;
            }
            Expediente expediente =  new Expediente(contenido, estadoExpediente,null, usuario);
            ExpedienteAlta.Ejecutar(expediente, usuario);
          break;  
        }
        case 6:
        {
            Console.WriteLine("Ingrese Id del expediente para consultar por el mismo y sus tramites"); 
            int id = int.Parse(Console.ReadLine()??"-1");
            Expediente? expediente = casosDeUsoExpedienteYTramites.Ejecutar(id);
            Console.WriteLine(expediente); 
            foreach(Tramite tramite in expediente.Tramites)
            {
                Console.WriteLine(tramite);
            }
         break;
        }
        case 7: 
        {
         LinkedList<Expediente> expedientes; 
         ExpedienteConsultaTodos.Ejecutar(out expedientes);
         Console.WriteLine("-----------------------------------------------");
         foreach (Expediente expediente in expedientes)
         {
            Console.WriteLine(expediente);
         }
        break;
        }
        case 8: 
        {
            Console.WriteLine("Ingrese Id del expediente a Encontrar y modificar");
            Expediente? expediente;
            ExpedienteConsultaId.Ejecutar(int.Parse(Console.ReadLine()??"-1"), out expediente);
            if(expediente!= null)
            {
            Console.WriteLine("Ingrese Nuevo Contenido");
            expediente.ActualizarContenido(Console.ReadLine()??"", usuario);
            ExpedienteModificacion.Ejecutar(expediente, usuario);
            }

            break;
        }
        case 9:
        {
            Console.WriteLine("Ingrese el id del Expediente a eliminar"); 
            ExpedienteBaja.Ejecutar(int.Parse(Console.ReadLine()??"-1"), usuario);
            break;
        }
        case 10 : ok = false; break;
    }
  }
}
