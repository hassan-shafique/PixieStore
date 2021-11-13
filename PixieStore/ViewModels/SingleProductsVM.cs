using PixieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.ViewModels
{
    public class SingleProductsVM
    {
        public Subscriber Subscriber{ get; set; }
        public Products Products { get; set; }
    }
}
