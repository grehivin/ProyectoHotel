using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccesoDatos
{
    public class AccesoSQL : IAccesoSQL
    {

        #region Metodos Clientes

        #region Agregar_Clientes
        public bool AgregarClientes(Clientes P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;
            try
            {
                contexto = new HotelContext();
                contexto.Clientes.Add(P_Entidad);
                contexto.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;

        }
        #endregion

        #region Modificar_Clientes

        public bool ModificarClientes(Clientes P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                var consulta = (from x in contexto.Clientes
                                where x.IdCliente.Equals(P_Entidad.IdCliente)
                                select x).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.IdCliente = P_Entidad.IdCliente;
                    consulta.NombreCompleto = P_Entidad.NombreCompleto;
                    consulta.TelefonoContacto = P_Entidad.TelefonoContacto;
                    consulta.CorreoElectronico = P_Entidad.CorreoElectronico;
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }
            return resultado;
        }

        #endregion

        #region Eliminar_Clientes
        public bool EliminarClientes(Clientes P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;
            try
            {
                contexto = new HotelContext();
                contexto.Clientes.Add(P_Entidad);
                contexto.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;

        }
        #endregion

        #region Consultar_Clientes
        public List<Clientes> ConsultarClientes(Clientes P_Entidad)
        {
            HotelContext contexto = null;
            List<Clientes> lista = new List<Clientes>();
            try
            {
                contexto = new HotelContext();

                if (contexto != null)
                {
                    var consulta = (from x in contexto.Clientes
                                    select x).ToList();
                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
                else
                {
                    var consulta = (from x in contexto.Clientes
                                    where x.IdCliente.Equals(P_Entidad.IdCliente)
                                    select x).ToList();
                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return lista;
        }

        #endregion


        #region Agregar_X

        #endregion

        #endregion

        #region Metodos Habitaciones

        #region Agregar_Habitacion
        public bool AgregarHabitaciones(Habitaciones P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                contexto.Habitaciones.Add(P_Entidad);
                contexto.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }
        #endregion

        #region Modificar_Habitacion
        public bool ModificarHabitaciones(Habitaciones P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                var consulta = (from x in contexto.Habitaciones
                                where x.NumHabitacion.Equals(P_Entidad.NumHabitacion)
                                select x).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.NumHabitacion = P_Entidad.NumHabitacion;
                    consulta.IdTipoHabitacion = P_Entidad.IdTipoHabitacion;
                    consulta.CapacidadPersonas = P_Entidad.CapacidadPersonas;
                    consulta.HabitacionActiva = P_Entidad.HabitacionActiva;
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }
        #endregion

        #region Consultar_Habitacion
        public List<Habitaciones> ConsultarHabitaciones(Habitaciones P_Entidad)
        {
            HotelContext contexto = null;
            List<Habitaciones> lista = new List<Habitaciones>();
            try
            {
                contexto = new HotelContext();

                if (Convert.ToString(P_Entidad.NumHabitacion).Length == 0)
                {
                    var consulta = (from x in contexto.Habitaciones
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
                else
                {
                    var consulta = (from x in contexto.Habitaciones
                                    where x.NumHabitacion.Equals(P_Entidad.NumHabitacion)
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return lista;
        }

        #endregion

        #region Eliminar_Habitacion
        public bool EliminarHabitaciones(Habitaciones P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                var consulta = (from x in contexto.Habitaciones
                                where x.NumHabitacion.Equals(P_Entidad.NumHabitacion)
                                select x).FirstOrDefault();

                if (consulta != null)
                {
                    contexto.Habitaciones.Remove(consulta);
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;

        }

        #endregion

        #endregion

        #region Metodos Reservas
      
        #region Agregar Reservas
        public bool AgregarReservaciones(Reservaciones P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                contexto.Reservaciones.Add(P_Entidad);
                contexto.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }
        #endregion

        #region Modificar Reservaciones
        public bool ModificarReservaciones(Reservaciones P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                var consulta = (from x in contexto.Reservaciones
                                where x.IdReservacion.Equals(P_Entidad.IdReservacion)
                                select x).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.IdReservacion = P_Entidad.IdReservacion;
                    consulta.FechaEntrada = P_Entidad.FechaEntrada;
                    consulta.FechaSalida = P_Entidad.FechaSalida;
                    consulta.CantidadAcompanantes = P_Entidad.CantidadAcompanantes;
                    consulta.IdCliente = P_Entidad.IdCliente;
                    consulta.IdHabitacion = P_Entidad.IdHabitacion;
                    consulta.CostoReservacion = P_Entidad.CostoReservacion;
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }

        #endregion

        #region Consultar Reservas
        public List<Reservaciones> ConsultarReservaciones(Reservaciones P_Entidad)
        {
            HotelContext contexto = null;
            List<Reservaciones> lista = new List<Reservaciones>();
            try
            {
                contexto = new HotelContext();

                if (Convert.ToString(P_Entidad.IdReservacion).Length == 0)
                {
                    var consulta = (from x in contexto.Reservaciones
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
                else
                {
                    var consulta = (from x in contexto.Reservaciones
                                    where x.IdReservacion.Equals(P_Entidad.IdReservacion)
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return lista;
        }



        #endregion

        #region Eliminar Reservas
        public bool EliminarReservaciones(Reservaciones P_Entidad)
        {
            bool resultado = false;
           HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                var consulta = (from x in contexto.Reservaciones
                                where x.IdReservacion.Equals(P_Entidad.IdReservacion)
                                select x).FirstOrDefault();

                if (consulta != null)
                {
                    contexto.Reservaciones.Remove(consulta);
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }
        #endregion


        #endregion

        #region  Metodos Usuarios


        #region Agregar Usuarios


        public bool AgregarUsuarios(Usuarios P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                contexto.Usuarios.Add(P_Entidad);
                contexto.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }


        #endregion

        #region Modificar Usuarios

        public bool ModificarUsuarios(Usuarios P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                var consulta = (from x in contexto.Usuarios
                                where x.Usuario.Equals(P_Entidad.Usuario)
                                select x).FirstOrDefault();

                if (consulta != null)
                {

                    consulta.Usuario = P_Entidad.Usuario;
                    consulta.UsuarioActivo = P_Entidad.UsuarioActivo;
                    consulta.RolesUsuarios = P_Entidad.RolesUsuarios;
                    consulta.Contrasena = P_Entidad.Contrasena;
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }


        #endregion

        #region Consultar Usuarios


        public List<Usuarios> ConsultarUsuarios(Usuarios P_Entidad)
        {
            HotelContext contexto = null;
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                contexto = new HotelContext();

                if (Convert.ToString(P_Entidad.Usuario).Length == 0)
                {
                    var consulta = (from x in contexto.Usuarios
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
                else
                {
                    var consulta = (from x in contexto.Usuarios
                                    where x.Usuario.Equals(P_Entidad.Usuario)
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return lista;
        }



        #endregion

        #region Eliminar Usuarios
        public bool EliminarUsuarios(Usuarios P_Entidad)
        {
            bool resultado = false;
            HotelContext contexto = null;

            try
            {
                contexto = new HotelContext();
                var consulta = (from x in contexto.Usuarios
                                where x.Usuario.Equals(P_Entidad.Usuario)
                                select x).FirstOrDefault();

                if (consulta != null)
                {
                    contexto.Usuarios.Remove(consulta);
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }
        #endregion


        #endregion
    }

}





