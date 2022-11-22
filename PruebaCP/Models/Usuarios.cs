using Entidades;
using System.Collections.Generic;
using System.Net.Sockets;

namespace WebAPI.Models
{
    public class Usuarios
    {


        #region Propiedades 

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public bool Estado { get; set; }

        public List<Perfil> Perfiles { get; set; }
        #endregion

        #region Constructores 

        public Usuarios() 
        {
        
            Usuario = string.Empty;
            Contrasena = string.Empty;  
            Estado = true;
            Perfiles = new List<Perfil>();  
        }

        #endregion

        #region Metodos
        public Usuarios ValidarUsuario()
        {
            List<Usuarios> lstUsuario = new List<Usuarios>
            { 
            new Usuarios { Usuario = "DV3386CR", Contrasena ="1234", Estado = true, 
                         Perfiles = new List<Perfil> 
                         {
                         new Perfil {Codigo = 1 , Descripcion = "Gerencia" },
                         new Perfil {Codigo = 1 , Descripcion = "Reservaciones" },
                         new Perfil {Codigo = 1 , Descripcion = "Acerca de " },

                         }
                        },

              new Usuarios { Usuario = "GR2111CR", Contrasena ="1234", Estado = true,
                         Perfiles = new List<Perfil>
                         {
                  
                         new Perfil {Codigo = 2, Descripcion = "Reservaciones" },
                         new Perfil {Codigo = 2 , Descripcion = "Acerca de " },


                         }
                        },
              
                new Usuarios { Usuario = "DS2905CR", Contrasena ="1234", Estado = true,
                         Perfiles = new List<Perfil>
                         {
                         new Perfil {Codigo = 3 , Descripcion = "Gerencia" },
                         new Perfil {Codigo = 3 , Descripcion = "Reservaciones" },
                         new Perfil {Codigo = 3 , Descripcion = "Acerca de " },
                         }
                        },
            };

            Usuarios encontrado = lstUsuario.Find(x => x.Usuario.ToUpper().Equals(Usuario.ToUpper()) && 
                                                       x.Contrasena.ToUpper().Equals(Contrasena.ToUpper()) && 
                                                       x.Estado == true);

            return encontrado;
        }
        #endregion


    }
}
