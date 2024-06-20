using System;
using System.Collections.Generic;

namespace Aplicacion;
    public class Tramite
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraUltimaModificacion { get; set; }
        public int ExpedienteId { get; set; }
        public int IdUsuario { get; set; }
        public EstadoTramite EstadoTramite { get; set; }

        public Tramite()
        {
        }
        public override string ToString()
        {
            return $"{Id}\t{ExpedienteId}\t{Contenido}\t{FechaHoraCreacion}\t{FechaHoraUltimaModificacion}\t{IdUsuario}\t{EstadoTramite}";
        }
    }