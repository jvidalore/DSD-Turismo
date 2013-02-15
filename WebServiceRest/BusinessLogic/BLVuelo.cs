using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.NoTransactional;
using Domain.DTO;
namespace BusinessLogic
{
    public class BLVuelo
    {
        #region "NoTransactional"
        public static System.Collections.Generic.List<Vuelo> CargarVueloAll()
        {
            return new DANTVuelo().CargarVueloAll();
        }
        public static System.Collections.Generic.List<Vuelo> CargarVueloFind(string FechaPartida, string FechaRegreso, string LugarOrigen, string LugarDestino)
        {
            return new DANTVuelo().CargarVueloFind(FechaPartida, FechaRegreso, LugarOrigen, LugarDestino);
        }
        public static System.Collections.Generic.List<Vuelo> CargarVueloOne(int iNuVuelo)
        {
            return new DANTVuelo().CargarVueloOne(iNuVuelo);
        }
        #endregion

        #region "Transactional"

        #endregion
    }
}
