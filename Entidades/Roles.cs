using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Roles
    {
        public Roles()
        {
            RolesUsuarios = new HashSet<RolesUsuarios>();
        }

        public decimal IdRol { get; set; }
        public string Descripcion { get; set; }
        public bool RolActivo { get; set; }

        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }
    }
}
