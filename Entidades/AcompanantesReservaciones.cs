using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class AcompanantesReservaciones
    {
        public decimal IdInvitadosReservacion { get; set; }
        public decimal IdReservacion { get; set; }
        public string NombreCompletoInvitado { get; set; }
        public decimal EdadInvitado { get; set; }
        public string TipoInvitado { get; set; }

        public virtual Reservaciones IdReservacionNavigation { get; set; }
    }
}
