using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pizza_API.Data.Model
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int PizzaId { get; set; }
        [NotMapped]
        public Pizza Pizza { get; set; }
    }
}
