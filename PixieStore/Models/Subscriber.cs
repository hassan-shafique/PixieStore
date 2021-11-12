using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Subscriber's Email")]
        public string S_Email { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTime Created_Date { get; set; }
    }
}
