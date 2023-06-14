using System.ComponentModel.DataAnnotations;

namespace Pizza_API.Data.Model
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Diamter { get; set; }
        public DateTime? LeftOvenAt { get; set; }
        public List<Topping> Toppings { get; set; }
    }
}
