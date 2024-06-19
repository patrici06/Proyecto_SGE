using System;
using System.Collections.Generic;

namespace Aplicacion;
    public class Tramite
    {
        private static int s_id = 1; // Esto debe estar inicializado

        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraUltimaModificacion { get; set; }
        public int ExpedienteId { get; set; }
        public Expediente Expediente { get; set; }
        public int IdUsuario { get; set; }
        public EstadoTramite EstadoTramite { get; set; }

        public Tramite()
        {
        }

        private Tramite(string id, string idExpediente, string contenido, string creacion, string modificacion, string idUsuario, string estadoTramite)
        {
            Id = int.Parse(id);
            ExpedienteId = int.Parse(idExpediente);
            IdUsuario = int.Parse(idUsuario);
            Contenido = contenido;
            FechaHoraCreacion = DateTime.Parse(creacion);
            FechaHoraUltimaModificacion = DateTime.Parse(modificacion);
            EstadoTramite = (EstadoTramite)Enum.Parse(typeof(EstadoTramite), estadoTramite);
        }

        public static Tramite Ensamblador(string cadena)
        {
            string[] temp = cadena.Split("\t");
            return new Tramite(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
        }

        public Tramite(int idExpediente, string contenido, int idUsuario, EstadoTramite estadoTramite)
        {
            Id = s_id;
            s_id++;
            ExpedienteId = idExpediente;
            ActualizarContenido(contenido, idUsuario);
            IdUsuario = idUsuario;
            EstadoTramite = estadoTramite;
            FechaHoraCreacion = DateTime.Now;
        }

        private void UltimaModificacion(int idUsuario)
        {
            IdUsuario = idUsuario;
            FechaHoraUltimaModificacion = DateTime.Now;
        }

        public void ActualizarContenido(string contenido, int idUsuario)
        {
            Contenido = contenido;
            UltimaModificacion(idUsuario);
        }

        public void ActualizarEstado(EstadoTramite estadoTramite, int idUsuario)
        {
            EstadoTramite = estadoTramite;
            UltimaModificacion(idUsuario);
        }

        public override string ToString()
        {
            return $"{Id}\t{ExpedienteId}\t{Contenido}\t{FechaHoraCreacion}\t{FechaHoraUltimaModificacion}\t{IdUsuario}\t{EstadoTramite}";
        }
    }