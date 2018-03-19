namespace CityParkWeb.Entities.Negocio
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AgenteCliente")]
    public partial class AgenteCliente
    {
        public int Id { get; set; }

        public int? IdAgente { get; set; }

        public int? IdCliente { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
