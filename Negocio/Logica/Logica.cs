using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Logica
{
   public  class Logica : ILogica
    {
      
        private readonly IAccesoSQL _iaccesoSQL;
        public Logica(IAccesoSQL iaccesoSQL)
        {
            _iaccesoSQL = iaccesoSQL;
        }


        #region Clientes
        public bool AgregarClientes(Clientes P_Entidad)
        {
            return _iaccesoSQL.AgregarClientes(P_Entidad);
        }

        public List<Clientes> ConsultarClientes(Clientes P_Entidad)
        {
            return _iaccesoSQL.ConsultarClientes(P_Entidad);
        }

        public bool EliminarClientes(Clientes P_Entidad)
        {
            return _iaccesoSQL.EliminarClientes(P_Entidad);
        }


        public bool ModificarClientes(Clientes P_Entidad)
        {
            return _iaccesoSQL.ModificarClientes(P_Entidad);
        }

        #endregion

        #region Habitaciones


        public bool AgregarHabitaciones(Habitaciones P_Entidad)
        {
            return _iaccesoSQL.AgregarHabitaciones(P_Entidad);
        }

        public List<Habitaciones> ConsultarHabitaciones(Habitaciones P_Entidad)
        {
            return _iaccesoSQL.ConsultarHabitaciones(P_Entidad);
        }
        public bool EliminarHabitaciones(Habitaciones P_Entidad)
        {
            return _iaccesoSQL.EliminarHabitaciones(P_Entidad);
        }

        public bool ModificarHabitaciones(Habitaciones P_Entidad)
        {
            return _iaccesoSQL.ModificarHabitaciones(P_Entidad);
        }

        #endregion

        #region Usuarios
        public bool AgregarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.AgregarUsuarios(P_Entidad);
        }

        public List<Usuarios>ConsultarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.ConsultarUsuarios(P_Entidad);
        }

        public bool ModificarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.ModificarUsuarios(P_Entidad);
        }

        public bool EliminarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.EliminarUsuarios(P_Entidad);
        }


        #endregion

        #region Reservas
        public bool AgregarReservaciones(Reservaciones P_Entidad)
        {
            return _iaccesoSQL.AgregarReservaciones(P_Entidad);
        }

        public List<Reservaciones> ConsultarReservaciones(Reservaciones P_Entidad)
        {
            return _iaccesoSQL.ConsultarReservaciones(P_Entidad);
        }

        public bool ModificarReservaciones(Reservaciones P_Entidad)
        {
            return _iaccesoSQL.ModificarReservaciones(P_Entidad);
        }

        public bool EliminarReservaciones(Reservaciones P_Entidad)
        {
            return _iaccesoSQL.EliminarReservaciones(P_Entidad);
        }



        #endregion

    }


}
