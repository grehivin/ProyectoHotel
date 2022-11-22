using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Linq;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidades
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            RolesUsuarios = new HashSet<RolesUsuarios>();
        }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
        [Display(Name = "Usuario activo")]
        public bool UsuarioActivo { get; set; }

    
        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }

    }
}
