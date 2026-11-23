using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShooping.ProductAPI.Models
{
    [Table("product")]
    public class Product : Base.BaseEntity
    {
        [Column("name")]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150)]
        public string? Name { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Column("price")]
        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1,100000)]
        public decimal Price { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(500)]
        public string? ImageUrl { get; set; }
    }
}