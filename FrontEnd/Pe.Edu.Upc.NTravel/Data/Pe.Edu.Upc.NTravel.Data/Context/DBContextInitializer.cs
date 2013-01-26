using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;

namespace Pe.Edu.Upc.NTravel.Data.Context
{
    // DropCreateDatabaseIfModelChanges<GenericDBContext> // DropCreateDatabaseAlways // 
    public class DBContextInitializer : CreateDatabaseIfNotExists<GenericDBContext>
    {
        protected override void Seed(GenericDBContext context)
        {
            var usuarios = new List<Usuario>
            {
                new Usuario{Nombre="Edgar", Apellido="Melgarejo",Correo="edgar.melgarejo",Clave="1234",DefaultAction="Viaje/Index"},
                new Usuario{Nombre="Administrador", Apellido="NTravel",Correo="admin.ntravel",Clave="1234",DefaultAction="Viaje/Index"}
            };

            usuarios.ForEach(p => context.Set<Usuario>().Add(p));

            var lugares = new List<Lugar>
            {
                new Lugar{Descripcion="Lima-Lima-Perú"},
                new Lugar{Descripcion="Buenos Aires-Argentina"},
                new Lugar{Descripcion="Bogotá-Colombia"}
            };

            lugares.ForEach(p => context.Set<Lugar>().Add(p));

            var Tours = new List<Tours>
            {
                new Tours{IdLugar=1,Descripción="Tours en la ciudad pase por los mejores lugares.Almuerzo en Campo",Costo=110.0M},
                new Tours{IdLugar=1,Descripción="Tours en la ciudad pase por los mejores lugares.",Costo=110.0M}
                
            };

            Tours.ForEach(p => context.Set<Tours>().Add(p));

            context.SaveChanges();
        }
    }
}
