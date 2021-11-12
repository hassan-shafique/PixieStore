using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.Models
{
    public class productCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Description must less than 32")]
        [Display(Name ="Product Category")]
        public string Product_CatName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Description must less than 255")]
        [Display(Name = "Category Description")]
        public string Category_Desc { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created on")]
        public DateTime created_Date { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated on")]
        public DateTime last_Update { get; set; }
    }
}
