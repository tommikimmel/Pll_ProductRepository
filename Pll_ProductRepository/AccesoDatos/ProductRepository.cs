using Pll_ProductRepository.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pll_ProductRepository.AccesoDatos
{
    public class ProductRepository : IProductRepository
    {
        public bool Delete(int id)
        {
            List<ParametroSP> parametros = new List<ParametroSP>()
            {
                new ParametroSP
                {
                    nombre = "@codigo",
                    valor = id,
                }
            };
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_REGISTRAR_BAJA_PRODUCTO", parametros);
            if (dt != null)
                return true;
            else
                return false;
        }

        public List<Product> GetAll()
        {
            List<Product> lst = new List<Product>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_PRODUCTOS");
            foreach (DataRow row in dt.Rows)
            { 
                Product p = new Product();
                p.codigo = (int)row["codigo"];
                p.nombre = (string)row["n_producto"];
                p.precio = (double)row["precio"];
                p.stock = (int)row["stock"];
                p.activo = (bool)row["esta_activo"];
                lst.Add(p);
            }
            return lst;
        }

        public Product? GetById(int id)
        {
            List<ParametroSP> parametro = new List<ParametroSP>()
            {
                new ParametroSP()
                {
                    nombre = "@codigo",
                    valor = id
                }
            };
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_PRODUCTO_POR_CODIGO", parametro);
            if (dt != null && dt.Rows.Count > 0)
            {
                Product p = new Product();
                p.codigo = (int)dt.Rows[0]["codigo"];
                p.nombre = (string)dt.Rows[0]["n_producto"];
                p.precio = (double)dt.Rows[0]["precio"];
                p.stock = (int)dt.Rows[0]["stock"];
                p.activo = (bool)dt.Rows[0]["esta_activo"];
                return p;
            }
            return null; 
        }

        public bool Save(Product product)
        {
            List<ParametroSP> Parametros = new List<ParametroSP>()
            {
                new ParametroSP
                {
                    nombre = "@codigo",
                    valor = product.codigo,
                },
                new ParametroSP
                {
                    nombre = "@nombre",
                    valor = product.nombre,
                },
                new ParametroSP
                {
                    nombre = "@stock",
                    valor = product.stock,
                },
                new ParametroSP
                {
                    nombre = "@precio",
                    valor = product.precio,
                },
            };

            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_GUARDAR_PRODUCTO", Parametros);
            return dt != null;
        }
    }
}
