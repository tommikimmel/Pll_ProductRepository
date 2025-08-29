using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pll_ProductRepository.Dominio
{
    public class Product
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public bool activo { get; set; }

        public override string ToString()
        {
            return $"Codigo:{codigo} Nombre:{nombre} Stock:{stock} Precio:{precio}";
        }
    }
}
