using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{

    public class Product
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        [StringLength(1000,MinimumLength =10)]
        public string? description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }

}
