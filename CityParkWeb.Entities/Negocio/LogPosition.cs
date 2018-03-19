namespace CityParkWeb.Entities.Negocio
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LogPosition")]
    public partial class LogPosition
    {
        public int id { get; set; }

        public int? idAgente { get; set; }

        public double? Lat { get; set; }

        public double? Lon { get; set; }

        public DateTime? Fecha { get; set; }

        public virtual Agente Agente { get; set; }
    }
}
