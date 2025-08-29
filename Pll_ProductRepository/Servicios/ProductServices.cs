using Pll_ProductRepository.AccesoDatos;
using Pll_ProductRepository.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pll_ProductRepository.Servicios
{
    public class ProductServices
    {
        private IProductRepository _repository;

        public ProductServices()
        {
            _repository = new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }
        public Product? GetProductById(int id)
        {
            return _repository.GetById(id);
        }
        public bool SaveProduct(Product product)
        {
            return _repository.Save(product);
        }
        public bool DeleteProduct(int id)
        {
            return _repository.Delete(id);
        }
    }
}
