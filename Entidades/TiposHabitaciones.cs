using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidades
{
    public partial class TiposHabitaciones
    {
        public TiposHabitaciones()
        {
            Habitaciones = new HashSet<Habitaciones>();
        }

        [Display(Name = "Código del tipo de habitación")]
        public decimal IdTipoHabitacion { get; set; }
        [Display(Name = "Descripción del tipo de habitación")]
        public string Descripcion { get; set; }
        [Display(Name = "Precio por noche")]
        public decimal PrecioNoche { get; set; }

        public virtual ICollection<Habitaciones> Habitaciones { get; set; }
    }
}
