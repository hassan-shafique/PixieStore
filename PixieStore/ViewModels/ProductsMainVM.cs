using PixieStore.Data;
using PixieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.ViewModels
{
    public class ProductsMainVM
    {
        public Subscriber subscriber { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }
}
