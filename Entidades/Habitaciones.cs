using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Habitaciones
    {
        public Habitaciones()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        public decimal NumHabitacion { get; set; }
        public decimal PisoHabitacion { get; set; }
        public decimal TipoHabitacion { get; set; }
        public decimal CapacidadPersonas { get; set; }
        public bool HabitacionActiva { get; set; }

        public virtual TiposHabitaciones TipoHabitacionNavigation { get; set; }
        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
