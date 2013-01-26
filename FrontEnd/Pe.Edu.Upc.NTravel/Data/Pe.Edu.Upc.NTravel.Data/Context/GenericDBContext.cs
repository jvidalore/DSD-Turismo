using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pe.Edu.Upc.NTravel.Data.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace Pe.Edu.Upc.NTravel.Data.Context
{
    public class GenericDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var usuario = modelBuilder.Entity<Usuario>();
            usuario.HasKey(u => u.Id)
                .ToTable("Usuario", "Seguridad");
            usuario.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IdUsuario");

            /******************/
            var lugar = modelBuilder.Entity<Lugar>();
            lugar.HasKey(u => u.Id)
                .ToTable("Maestro", "Lugar");
            lugar.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IdLugar");


            /******************/
            var tours = modelBuilder.Entity<Tours>();
            tours.HasKey(u => u.Id)
                .ToTable("Tours", "Venta");
            tours.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IdTours");
            tours.HasRequired(t => t.Lugar)
              .WithMany()
              .HasForeignKey(t => t.IdLugar);

            /******************/
            var viaje = modelBuilder.Entity<Viaje>();
            viaje.HasKey(v => v.Id)
                .ToTable("Viaje", "Venta");
            viaje.Property(v => v.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IdViaje");

            viaje.HasRequired(v => v.Origen)
               .WithMany()
               .HasForeignKey(v => v.IdLugarOrigen)
               .WillCascadeOnDelete(false);

            viaje.HasRequired(v => v.Destino)
               .WithMany()
               .HasForeignKey(v => v.IdLugarDestino)
               .WillCascadeOnDelete(false);

            viaje.HasRequired(v => v.Usuario)
               .WithMany()
               .HasForeignKey(v => v.IdUsuario)
               .WillCascadeOnDelete(false);

            viaje.HasMany(v => v.Tours).
                WithMany(t => t.Viajes)
                .Map(mc =>
                {
                    mc.ToTable("ToursXViaje", "Venta");
                    mc.MapLeftKey("IdViaje");
                    mc.MapRightKey("IdTours");
                });


        }
    }
}
