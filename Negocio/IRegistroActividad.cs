using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public interface IRegistroActividad
    {
        public void AgregarRegistro(Actividad actividad, Roles objeto);
        public void AgregarRegistro(Actividad actividad, Usuarios objeto);
        public void AgregarRegistro(Actividad actividad, RolesUsuarios objeto);
        public void AgregarRegistro(Actividad actividad, TiposHabitaciones objeto);
        public void AgregarRegistro(Actividad actividad, Habitaciones objeto);
        public void AgregarRegistro(Actividad actividad, Clientes objeto);
        public void AgregarRegistro(Actividad actividad, Reservaciones objeto);
        public void AgregarRegistroAcceso(Actividad actividad, string rol);
    }
}
