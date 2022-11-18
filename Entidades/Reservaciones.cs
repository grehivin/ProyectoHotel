using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidades
{
    public partial class Reservaciones
    {
        [Display(Name = "Código de reservación")]
        public decimal IdReservacion { get; set; }
        [Display(Name = "# de identificación del cliente")]
        public decimal IdCliente { get; set; }
        [Display(Name = "# de habitación")]
        public decimal? IdHabitacion { get; set; }
        [Display(Name = "Cantidad de acompañantes")]
        public decimal CantidadAcompanantes { get; set; }
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaEntrada { get; set; }
        [Display(Name = "Fecha de salida")]
        public DateTime FechaSalida { get; set; }
        [Display(Name = "Estado de la reservación")]
        public string EstadoReservacion { get; set; }
        [Display(Name = "Costo de la reservación")]
        public decimal CostoReservacion { get; set; }
        [Display(Name = "Reservación pagada?")]
        public bool CostoReservacionPagado { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual Habitaciones IdHabitacionNavigation { get; set; }
    }
}
