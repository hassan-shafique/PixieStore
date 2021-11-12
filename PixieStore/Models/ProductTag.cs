using System;
using System.ComponentModel.DataAnnotations;

namespace PixieStore.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Product Tag's Name")]
        public string TagName { get; set; }
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
