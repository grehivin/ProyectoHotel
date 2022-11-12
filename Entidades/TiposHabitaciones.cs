using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class TiposHabitaciones
    {
        public TiposHabitaciones()
        {
            Habitaciones = new HashSet<Habitaciones>();
        }

        public decimal IdTipoHabitacion { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioNoche { get; set; }

        public virtual ICollection<Habitaciones> Habitaciones { get; set; }
    }
}
