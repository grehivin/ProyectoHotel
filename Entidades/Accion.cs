using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entidades
{
    public class Accion
    {
        #region Atributos
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjID { get; set; }

        [Display(Name = "Accion")]
        [BsonElement("Accion")]
        public string AccionRealizada { get; set; }
        [Display(Name = "Objeto")]
        [BsonElement("Objeto")]
        public string Objeto { get; set; }
        [Display(Name = "Instancia")]
        [BsonElement("Instancia")]
        public string Instancia { get; set; }
        [Display(Name = "Usuario")]
        [BsonElement("Usuario")]
        public string Usuario { get; set; }
        [Display(Name = "Resultado")]
        [BsonElement("Resultado")]
        public string Resultado { get; set; }
        [Display(Name = "Momento")]
        [BsonElement("Momento")]
        public DateTime Momento { get; set; }
        #endregion

        #region Constructor
        public Accion()
        {
            AccionRealizada = string.Empty;
            Objeto = string.Empty;
            Instancia = string.Empty;
            Usuario = string.Empty;
            Resultado = string.Empty;
            Momento = DateTime.MinValue;
        }
        #endregion
    }
}
