using Pll_ProductRepository.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pll_ProductRepository.AccesoDatos
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        bool Save(Product product);
        bool Delete(int id);
    }
}
