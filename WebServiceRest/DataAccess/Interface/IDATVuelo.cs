using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Interface
{
    public interface IDATVuelo<T>
    {
        bool ActualizarVuelo(T pEntidad);
    }
}
