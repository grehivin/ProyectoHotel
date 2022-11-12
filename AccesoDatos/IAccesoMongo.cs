using System;
using System.Collections.Generic;
using Entidades;

namespace AccesoDatos
{
    public interface IAccesoMongo
    {
        bool AgregarRegistroBitacora(Accion registro);

        List<Accion> ObtenerBitacoraCompleta();
    }
}

