namespace CityParkWeb.ModelosDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MapaConcentracion")]
    public partial class MapaConcentracion
    {
        public double? Latitud { get; set; }

        public double? Longitud { get; set; }

        public int Id { get; set; }
    }
}
