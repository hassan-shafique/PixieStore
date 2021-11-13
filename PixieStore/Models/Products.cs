using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string Image { get; set; }
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Product Tags")]
        [Required]
        public int ProducTagsId { get; set; }
        [ForeignKey("ProductTagsId")]
        public ProductTag ProductTag{ get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public List<productCategory> ProductCategory { get; set; }
    }
}
