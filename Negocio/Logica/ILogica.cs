using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Logica
{
       public interface ILogica
    {

        #region Clientes

        bool AgregarClientes(Clientes P_Entidad);
        bool ModificarClientes(Clientes P_Entidad);
        bool EliminarClientes(Clientes P_Entidad);
        List<Clientes> ConsultarClientes(Clientes P_Entidad);

        #endregion

        #region Habitaciones
        bool AgregarHabitaciones(Habitaciones P_Entidad);
        bool ModificarHabitaciones(Habitaciones P_Entidad);
        bool EliminarHabitaciones(Habitaciones P_Entidad);
        List<Habitaciones> ConsultarHabitaciones(Habitaciones P_Entidad);
        #endregion

        #region Reservaciones
        bool AgregarReservaciones(Reservaciones P_Entidad);
        bool ModificarReservaciones(Reservaciones P_Entidad);
        bool EliminarReservaciones(Reservaciones P_Entidad);
        List<Reservaciones>ConsultarReservaciones(Reservaciones P_Entidad);

        #endregion

        #region Usuarios
        bool AgregarUsuarios(Usuarios P_Entidad);
        bool ModificarUsuarios(Usuarios P_Entidad);
        bool EliminarUsuarios(Usuarios P_Entidad);
        List<Usuarios> ConsultarUsuarios(Usuarios P_Entidad);
        #endregion

    }

}
