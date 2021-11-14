

using System;

namespace Examen2_FernandoEspinal.Modelos.Entidades
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string TipoSoporte { get; set; }
        public string Estado { get; set; }
    }
}
