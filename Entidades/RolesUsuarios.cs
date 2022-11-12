using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class RolesUsuarios
    {
        public decimal Id { get; set; }
        public string Usuario { get; set; }
        public decimal Rol { get; set; }

        public virtual Roles RolNavigation { get; set; }
        public virtual Usuarios UsuarioNavigation { get; set; }
    }
}
