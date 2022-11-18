using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidades
{
    public partial class RolesUsuarios
    {
        [Display(Name = "Código de asociación entre el usario y el rol")]
        public decimal Id { get; set; }
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Display(Name = "Código del rol")]
        public decimal IdRol { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual Usuarios UsuarioNavigation { get; set; }
    }
}
