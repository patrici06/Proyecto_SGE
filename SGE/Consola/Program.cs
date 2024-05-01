// See https://aka.ms/new-console-template for more informa
using System.Collections;
using Aplicacion;
using Repositorios;

File.Create("Expedientes.txt").Close(); 
Expediente expediente = new Expediente();
Expediente expediente2 = new Expediente();

CasosDeUsoExpedienteAlta.Uso(expediente, "Expedientes.txt");
CasosDeUsoExpedienteAlta.Uso(expediente2, "Expedientes.txt");
CasosDeUsoExpedienteAlta.Uso(expediente, "Expedientes.txt");
CasosDeUsoExpedienteAlta.Uso(expediente2, "Expedientes.txt");
CasosDeUsoExpedienteBaja.Uso(expediente, "Expedientes.txt");
// ControlRepositorios.RutaOrigen = "tramites.txt";
// //ControlRepositorios.ElimiarRegistro(tramite2);

// List<Tramite> tramites = new List<Tramite>();
// ControlRepositorios.Crear();
//   for(int i = 0; i<10; i++)
//   {
//       Tramite tramite = new Tramite(1,"Tramite Pato", 1, EstadoTramite.Escrito_Presentado);
//   }
// foreach (string datos in ControlRepositorios.Safe())
// {
//     tramites.Add( Tramite.Ensamblador(datos));
// }
// foreach(Tramite tramite in tramites)
// {
//     Console.WriteLine(tramite);
// }
// ControlRepositorios.ElimiarRegistro(0);