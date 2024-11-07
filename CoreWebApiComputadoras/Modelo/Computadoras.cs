using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiComputadoras.Modelo
{
    public class Computadoras
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        public int costo { get; set; }
    }
}
