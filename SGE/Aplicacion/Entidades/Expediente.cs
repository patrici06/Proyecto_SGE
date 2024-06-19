using System;
using System.Collections;
using System.Collections.Generic;

namespace Aplicacion
{
    public class Expediente : IEnumerable<Tramite>
    {
        public int Id { get; set; }
        public string? Caratula { get; set; } = "";
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public List<Tramite>? Tramites { get; set; }
        public EstadoExpediente? Estado { get; set; }

        public Expediente()
        {
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            Tramites = new List<Tramite>();
        }

        public Expediente(string caratula, EstadoExpediente estado, List<Tramite>? tramites, int usuario)
        {
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            Caratula = caratula;
            Estado = estado;
            IdUsuarioModificacion = usuario;
            Tramites = tramites;
        }

        // public static Expediente Ensamblado(string cadena)
        // {
        //     string[] partes = cadena.Split("\t");
        //     return new Expediente(partes[0], partes[1], partes[2], partes[3], partes[4], partes[5]);
        // }

        private void ActualizarFechaModificacion(int idUsuario)
        {
            FechaModificacion = DateTime.Now;
            IdUsuarioModificacion = idUsuario;
        }

        public void ActualizarContenido(string contenido, int idUsuario)
        {
            Caratula = contenido;
            ActualizarFechaModificacion(idUsuario);
        }

        public override string ToString()
        {
            return $"{Id}\t{Caratula}\t{FechaCreacion}\t{FechaModificacion}\t{IdUsuarioModificacion}\t{Estado}";
        }

        public IEnumerator<Tramite> GetEnumerator()
        {
            return Tramites?.GetEnumerator() ?? new List<Tramite>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
