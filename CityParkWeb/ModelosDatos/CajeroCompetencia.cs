namespace CityParkWeb.ModelosDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CajeroCompetencia")]
    public partial class CajeroCompetencia
    {
        [StringLength(50)]
        public string Entidad { get; set; }

        [StringLength(50)]
        public string Zona { get; set; }

        [StringLength(10)]
        public string Telefono { get; set; }

        [StringLength(50)]
        public string Sucursal { get; set; }

        [StringLength(80)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Provincia { get; set; }

        [StringLength(50)]
        public string Canton { get; set; }

        public double? Altitud { get; set; }

        public double? Longitud { get; set; }

        public int Id { get; set; }
    }
}
