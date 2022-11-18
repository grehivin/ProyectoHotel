using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidades
{
    public partial class Habitaciones
    {
        public Habitaciones()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        [Display(Name = "# de habitación")]
        public decimal IdHabitacion { get; set; }
        [Display(Name = "# de la habitación en el piso")]
        public decimal NumHabitacion { get; set; }
        [Display(Name = "# del piso de la habitación")]
        public decimal PisoHabitacion { get; set; }
        [Display(Name = "Código del tipo de habitación")]
        public decimal IdTipoHabitacion { get; set; }
        [Display(Name = "Capacidad en personas")]
        public decimal CapacidadPersonas { get; set; }
        [Display(Name = "Habitación activa?")]
        public bool HabitacionActiva { get; set; }

        public virtual TiposHabitaciones IdTipoHabitacionNavigation { get; set; }
        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
