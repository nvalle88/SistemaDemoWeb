namespace CityParkWeb.ModelosDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CajeroCoopPolicia")]
    public partial class CajeroCoopPolicia
    {
        [StringLength(20)]
        public string Provincia { get; set; }

        [StringLength(20)]
        public string Canton { get; set; }

        [StringLength(20)]
        public string Sector { get; set; }

        [StringLength(20)]
        public string Codigo { get; set; }

        [StringLength(60)]
        public string Ubicación { get; set; }

        [StringLength(80)]
        public string Direccion { get; set; }

        [StringLength(8)]
        public string Tipo { get; set; }

        [StringLength(8)]
        public string Modelo { get; set; }

        public double? Latitud { get; set; }

        public double? Longitud { get; set; }

        public int? TrxPropia { get; set; }

        public int? TrxBanred { get; set; }

        public int Id { get; set; }
    }
}
