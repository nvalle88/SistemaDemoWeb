namespace CityParkWeb.Entities.Negocio
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Alarma")]
    public partial class Alarma
    {
        public int Id { get; set; }

        public int Minutos { get; set; }
    }
}
