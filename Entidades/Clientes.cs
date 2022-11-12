using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Clientes
    {
        public Clientes()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        public decimal IdCliente { get; set; }
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoContacto { get; set; }
        public bool ClienteActivo { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipalidad { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Direccion { get; set; }

        public virtual Usuarios UsuarioNavigation { get; set; }
        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
