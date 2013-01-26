using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.Edu.Upc.NTravel.Service.Common;
using Pe.Edu.Upc.NTravel.Data.Context;
using Pe.Edu.Upc.NTravel.Data.Repository;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;
using Pe.Edu.Upc.NTravel.Domain.ServiceContract;
using Pe.Edu.Upc.NTravel.Domain.RepositoryContract;
using Pe.Edu.Upc.NTravel.Domain.DTO;
using Pe.Edu.Upc.NTravel.Service.SOAHotel;

namespace Pe.Edu.Upc.NTravel.Service.Travel
{
    public class ViajeService : GenericService<Viaje>, IViajeService
    {
        //private to
        public ViajeService()
        {
            this.Provider = new DBContextProvider();
            this.ViajeRepository = new ViajeRepository(this.Provider.Context);
            this.ToursRepository = new ToursRepository(this.Provider.Context);
        }
        public IViajeRepository ViajeRepository
        {
            set
            {
                this.genericRepository = value;
            }
            get
            {
                return this.genericRepository as IViajeRepository;
            }
        }

        public IToursRepository ToursRepository { get; set; }

        public Paquete BuscarDisponibilidad(Viaje viaje)
        {

            Paquete paquete = new Paquete()
            {
                Hoteles = this.ConsultarHotel(viaje),
                Vuelos = this.ConsultarVuelos(viaje),
                Tours = this.ConsultarTours(viaje)
            };

            return paquete;
        }

        public List<Hotel> ConsultarHotel(Viaje viaje)
        {

            HotelService hotelService = new HotelServiceClient();

            ConsultarDisponibilidad consultaHoteles = new ConsultarDisponibilidad(viaje.Adultos + viaje.Ninios);

            var hoteles = hotelService.ConsultarDisponibilidad(consultaHoteles).@return;

            var resultado = hoteles.Select(h => new Hotel
                {
                    Nombre = h.nombre,
                    Descripcion = h.descripcion,
                    Camas = h.camas,
                    Categoria = h.categoria,
                    Codigo = h.codigo,
                    Costo = decimal.Parse(h.costo.ToString()),
                    Logo = h.logo
                }).ToList();
            /*var resultado = new List<Hotel>()
                {
                    new Hotel()
                    {
                       Camas=2,
                       Categoria=2,
                       Codigo=1,
                       Costo=150.0M,
                       Descripcion="Hotel de primera",
                       Nombre="Mi Hotel",
                       Logo="http://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Hotel-room-renaissance-columbus-ohio.jpg/250px-Hotel-room-renaissance-columbus-ohio.jpg"
                    },

                    new Hotel()
                    {
                       Camas=1,
                       Categoria=3,
                       Codigo=2,
                       Costo=200.0M,
                       Descripcion="Un hotel cerca a la ciudad",
                       Nombre="Hotelisimo",
                       Logo="http://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Hotel-room-renaissance-columbus-ohio.jpg/250px-Hotel-room-renaissance-columbus-ohio.jpg"
                    },

                    new Hotel()
                    {
                       Camas=3,
                       Categoria=5,
                       Codigo=3,
                       Costo=250.0M,
                       Descripcion="Un hotel Antiguo",
                       Nombre="Super Hotel",
                       Logo="http://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Hotel-room-renaissance-columbus-ohio.jpg/250px-Hotel-room-renaissance-columbus-ohio.jpg"
                    }
                };*/
            return resultado;
        }

        public List<Tours> ConsultarTours(Viaje viaje)
        {
            var resultado = this.ToursRepository.Find().ToList();

            return resultado;
        }

        public List<Vuelo> ConsultarVuelos(Viaje viaje)
        {
            var resultado = new List<Vuelo>()
                {
                    new Vuelo()
                    {
                        Aerolinea = "Vuela Facil",
                        Asientos = 5,
                        Clase = "Economica",
                        Costo = 70.50M
                    },

                    new Vuelo()
                    {
                        Aerolinea = "LAN",
                        Asientos = 5,
                        Clase = "Primera Clase",
                        Costo = 150.50M
                    },

                    new Vuelo()
                    {
                        Aerolinea = "TACA",
                        Asientos = 5,
                        Clase = "Economica",
                        Costo = 98.50M
                    }
                };

            return resultado;
        }
    }
}
