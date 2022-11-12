using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Entidades;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace AccesoDatos
{
    public class AccesoMongo : IAccesoMongo
    {
        #region Atributos
        private readonly string CadenaConexion = "mongodb+srv://progravan:Progr4van@cluster0.e1ukwux.mongodb.net/?retryWrites=true&w=majority";
        private MongoClient InstanciaMongo;
        private IMongoDatabase BaseDatos;

        private const string NombreBaseDatos = "Hotel";
        #endregion

        #region Constructor
        public AccesoMongo()
        {
            try
            {
                BaseDatosEnLinea();
            }
            /*
            catch (MongoException exMDB)
            {
                throw exMDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // */
            finally
            {
                if (InstanciaMongo != null)
                    InstanciaMongo = null;

                if (BaseDatos != null)
                    BaseDatos = null;
            }
        }
        #endregion

        #region Métodos

        #region Privados
        /// <summary>
        /// Realiza la conexión a la base de datos utilizando los parámetros ya establecidos.
        /// </summary>
        /// <returns>Verdadero si la conexión es posible, falso si la conexión no es posible.</returns>
        private bool BaseDatosEnLinea()
        {
            bool conexionExitosa = false;

            try
            {
                InstanciaMongo = new MongoClient(CadenaConexion);

                BaseDatos = InstanciaMongo.GetDatabase(NombreBaseDatos);
                conexionExitosa = BaseDatos.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            }
            catch (MongoException exMDB)
            {
                throw exMDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return conexionExitosa;
        }
        #endregion

        #region Públicos
        /// <summary>
        /// Agrega una nueva entrada en la colección de actividades.
        /// </summary>
        /// <param name="evento">Evento de actividad realizada.</param>
        /// <returns>Cierto si el registro se pudo almacenar, falso si hubo algún error.</returns>
        public bool AgregarRegistroBitacora(Accion evento)
        {
            bool eventoAlmacenado = false;

            if (BaseDatosEnLinea())
            {
                try
                {
                    var Actividades = BaseDatos.GetCollection<Accion>("Bitacora");
                    Actividades.InsertOne(evento);
                    eventoAlmacenado = true;
                }
                catch (MongoException exMDB)
                {
                    throw exMDB;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    InstanciaMongo = null;
                    BaseDatos = null;
                }
            }

            return eventoAlmacenado;
        }

        /// <summary>
        /// Devuelve la lista completa de actividades realizadas en el sistema para un listado completo.
        /// </summary>
        /// <returns>Lista de entidades de tipo RegistroActividad</returns>
        public List<Accion> ObtenerBitacoraCompleta()
        {
            List<Accion> bitacora = new List<Accion>();

            if (BaseDatosEnLinea())
            {
                try
                {
                    var Actividades = BaseDatos.GetCollection<Accion>("Bitacora");
                    bitacora = Actividades.Find(d => true).ToList();
                }
                catch (MongoException exMDB)
                {
                    throw exMDB;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    InstanciaMongo = null;
                    BaseDatos = null;
                }
            }

            return bitacora;
        }
        #endregion

        #endregion
    }
}

