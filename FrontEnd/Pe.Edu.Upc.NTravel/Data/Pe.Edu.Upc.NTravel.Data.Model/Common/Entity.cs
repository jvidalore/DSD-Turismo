using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.Edu.Upc.NTravel.Data.Model.Common
{   
    /// <summary>
    /// Base for an Entity.
    /// </summary>
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
