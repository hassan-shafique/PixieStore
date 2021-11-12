using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.Models
{
    public class Contactus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(101, ErrorMessage = "This Field is Necessary..")]
        public string Subject { get; set; }
        [Required]
        [StringLength(256, ErrorMessage ="This Field is Necessary..")]
        public string Message { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
