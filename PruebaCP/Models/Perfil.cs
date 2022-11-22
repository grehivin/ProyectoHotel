

namespace WebAPI.Models
{
    public class Perfil
    {
        #region Propiedad

        public int Codigo { get; set; }

        public string Descripcion { get; set; }
        #endregion

        #region Constructor 
        public Perfil()
        {
            Codigo = 0;

            Descripcion = string.Empty;
        #endregion

        }
    }
}
