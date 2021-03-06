﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;
using Pe.Edu.Upc.NTravel.Domain.Common;
using Pe.Edu.Upc.NTravel.Domain.DTO;

namespace Pe.Edu.Upc.NTravel.Domain.ServiceContract
{
    public interface IViajeService : IGenericService<Viaje>
    {
        Paquete BuscarDisponibilidad(Viaje viaje);
    }
}
