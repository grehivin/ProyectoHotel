using AccesoDatos;
using Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace Negocio
{
   public  class RegistroActividad : IRegistroActividad
    {
      
        private readonly IAccesoMongo _accesoMongo;
        public RegistroActividad()
        {
            _accesoMongo = new AccesoMongo();
        }

        public void AgregarRegistro(Actividad actividad, Roles objeto)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = actividad.Funcion,
                Objeto = objeto.GetType().Name,
                Instancia = 
                    "rolid=" + 
                    objeto.IdRol.ToString() + 
                    ";descripcion=" + 
                    objeto.Descripcion + 
                    ";estado" + 
                    (objeto.RolActivo?"activo":"inactivo"),
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }

        public void AgregarRegistro(Actividad actividad, Usuarios objeto)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion() 
            {
                AccionRealizada = actividad.Funcion,
                Objeto = objeto.GetType().Name,
                Instancia = "usuario=" + objeto.Usuario + ";contrasena=" + objeto.Contrasena + ";estado=" + (objeto.UsuarioActivo?"activo":"inactivo"),
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }

        public void AgregarRegistro(Actividad actividad, RolesUsuarios objeto)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = actividad.Funcion,
                Objeto = objeto.GetType().Name,
                Instancia = "asigancionrolid=" + objeto.Id + ";rolid=" + objeto.IdRol + ";usuario=" + objeto.Usuario,
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }

        public void AgregarRegistro(Actividad actividad, TiposHabitaciones objeto)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = actividad.Funcion,
                Objeto = objeto.GetType().Name,
                Instancia = "tipohabitacionid=" + objeto.IdTipoHabitacion + ";Descripcion=" + objeto.Descripcion + ";preciopornoche=" + objeto.PrecioNoche,
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }

        public void AgregarRegistro(Actividad actividad, Habitaciones objeto)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = actividad.Funcion,
                Objeto = objeto.GetType().Name,
                Instancia = "habitacionid=" + objeto.IdHabitacion + ";pisohabitacion=" + objeto.PisoHabitacion + ";numerohabitacion=" + objeto.NumHabitacion + 
                    ";tipohabitacionid=" + objeto.IdTipoHabitacion + ";capacidadpersonas=" + objeto.CapacidadPersonas + ";estado=" + 
                    (objeto.HabitacionActiva ? "activa" : "inactiva"),
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }

        public void AgregarRegistro(Actividad actividad, Clientes objeto)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = actividad.Funcion,
                Objeto = objeto.GetType().Name,
                Instancia =
                    "clienteid=" +
                    objeto.IdCliente +
                    ";nombrecompleto=" +
                    objeto.NombreCompleto +
                    ";correoelectronico=" +
                    objeto.CorreoElectronico +
                    ";numerotelefono=" +
                    objeto.TelefonoContacto +
                    ";estado=" +
                    (objeto.ClienteActivo?"activo":"inactivo") +
                    ";pais=" +
                    objeto.Pais +
                    ";provincia=" +
                    objeto.Provincia +
                    ";canton=" +
                    objeto.Canton +
                    ";distrito=" +
                    objeto.Distrito +
                    ";codigopostal=" +
                    objeto.CodigoPostal +
                    "direccion=" +
                    objeto.Direccion,
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }

        public void AgregarRegistro(Actividad actividad, Reservaciones objeto)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = actividad.Funcion,
                Objeto = objeto.GetType().ToString(),
                Instancia =
                    "reservacionid=" +
                    objeto.IdReservacion +
                    ";clienteid=" +
                    objeto.IdCliente +
                    ";habitacionid=" +
                    objeto.IdHabitacion +
                    ";totalacompanantes=" +
                    objeto.CantidadAcompanantes +
                    ";fechaentrada=" +
                    objeto.FechaEntrada.Date +
                    ";fechasalida=" +
                    objeto.FechaSalida.Date +
                    ";estadoreservacion=" +
                    objeto.EstadoReservacion +
                    ";montoacancelar=" +
                    objeto.CostoReservacion +
                    ";montopagado=" +
                    (objeto.CostoReservacionPagado?"sí":"no"),
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }

        public void AgregarRegistroAcceso(Actividad actividad, string rol)
        {
            _accesoMongo.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = actividad.Funcion,
                Objeto = "Portal hotel",
                Instancia = rol,
                Usuario = actividad.Usuario,
                Resultado = actividad.Resultado,
                Momento = DateTime.Now
            });
        }
    }
}
