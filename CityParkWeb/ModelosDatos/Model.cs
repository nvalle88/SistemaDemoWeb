namespace CityParkWeb.ModelosDatos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelCPNDB")
        {
        }

        public virtual DbSet<CajeroCompetencia> CajeroCompetencia { get; set; }
        public virtual DbSet<CajeroCoopPolicia> CajeroCoopPolicia { get; set; }
        public virtual DbSet<MapaConcentracion> MapaConcentracion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CajeroCompetencia>()
                .Property(e => e.Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCompetencia>()
                .Property(e => e.Zona)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCompetencia>()
                .Property(e => e.Telefono)
                .IsFixedLength();

            modelBuilder.Entity<CajeroCompetencia>()
                .Property(e => e.Sucursal)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCompetencia>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCompetencia>()
                .Property(e => e.Provincia)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCompetencia>()
                .Property(e => e.Canton)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Provincia)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Canton)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Ubicación)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<CajeroCoopPolicia>()
                .Property(e => e.Modelo)
                .IsUnicode(false);
        }
    }
}
