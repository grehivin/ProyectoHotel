using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidades
{
    public partial class Clientes
    {
        public Clientes()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        [Display(Name="# de identificación del cliente")]
        public decimal IdCliente { get; set; }
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Correo electrónico")]
        public string CorreoElectronico { get; set; }
        [Display(Name = "Teléfono de contacto")]
        public string TelefonoContacto { get; set; }
        [Display(Name = "Cliente activo?")]
        public bool ClienteActivo { get; set; }
        [Display(Name = "País de residencia")]
        public string Pais { get; set; }
        [Display(Name = "Estado/Provincia/Departamento")]
        public string Estado { get; set; }
        [Display(Name = "Condado/Cantón/Municipalidad")]
        public string Municipalidad { get; set; }
        [Display(Name = "Barrio")]
        public string Localidad { get; set; }
        [Display(Name = "Código postal")]
        public string CodigoPostal { get; set; }
        [Display(Name = "Dirección exacta")]
        public string Direccion { get; set; }

        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
