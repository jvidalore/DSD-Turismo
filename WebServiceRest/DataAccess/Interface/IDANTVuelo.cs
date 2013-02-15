using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Interface
{
    public interface IDANTVuelo<T>
    {
        List<T> CargarVueloAll() ;
        List<T> CargarVueloFind(string FechaPartida,string FechaRegreso,string LugarOrigen, string LugarDestino);
        List<T> CargarVueloOne(int iNuVuelo);
    }
}
