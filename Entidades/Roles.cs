using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidades
{
    public partial class Roles
    {
        public Roles()
        {
            RolesUsuarios = new HashSet<RolesUsuarios>();
        }

        [Display(Name = "Código del rol")]
        public decimal IdRol { get; set; }
        [Display(Name = "Descripción del rol")]
        public string Descripcion { get; set; }
        [Display(Name = "Rol activo")]
        public bool RolActivo { get; set; }

        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }
    }
}
