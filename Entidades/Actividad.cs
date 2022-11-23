using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Actividad
    {
        public Actividad()
        {
        }

        public Actividad(string funcion, string usuario, string resultado)
        {
            Funcion = funcion ?? throw new ArgumentNullException(nameof(funcion));
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            Resultado = resultado ?? throw new ArgumentNullException(nameof(resultado));
        }

        public string Funcion { get; set; }
        public string Usuario { get; set; }
        public string Resultado { get; set; }
    }
}
