using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Reservaciones
    {
        public Reservaciones()
        {
            AcompanantesReservaciones = new HashSet<AcompanantesReservaciones>();
        }

        public decimal IdReservacion { get; set; }
        public decimal Cliente { get; set; }
        public decimal? NumHabitacion { get; set; }
        public decimal CantidadAcompanantes { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string EstadoReservacion { get; set; }
        public decimal CostoReservacion { get; set; }
        public bool CostoReservacionPagado { get; set; }

        public virtual Clientes ClienteNavigation { get; set; }
        public virtual Habitaciones NumHabitacionNavigation { get; set; }
        public virtual ICollection<AcompanantesReservaciones> AcompanantesReservaciones { get; set; }
    }
}
