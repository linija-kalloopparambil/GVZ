using System.ComponentModel.DataAnnotations;

namespace Pizza_API.Data.DTO
{
    public class ToppingDTO
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        public int PizzaId { get; set; }
    }
}
