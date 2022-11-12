using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Clientes = new HashSet<Clientes>();
            RolesUsuarios = new HashSet<RolesUsuarios>();
        }

        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool UsuarioActivo { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }
    }
}
