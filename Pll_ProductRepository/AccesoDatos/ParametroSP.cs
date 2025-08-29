using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pll_ProductRepository.AccesoDatos
{
    //Clase para representar un parametro de un SP
    public class ParametroSP
    {
        public string nombre { get; set; }
        public object valor { get; set; }

    }
}
