using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ex_api_inicial.Models
{

    [Table("Product")]
    public class Product
    { 

        public Product()
        {
            ProductId = Guid.NewGuid();
        }

        [Key]
        [Required]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
    }
}