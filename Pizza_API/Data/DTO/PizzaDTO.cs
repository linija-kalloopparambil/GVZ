﻿using System.ComponentModel.DataAnnotations;

namespace Pizza_API.Data.DTO
{
    public class PizzaDTO
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }
        public int Diamter { get; set; }
        public int ToppingId { get; set; }
    }
}
