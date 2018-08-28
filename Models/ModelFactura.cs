using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factura.Models
{
    public class ModelFactura
    {
        public int idFactura { get; set; }
        public int idCliente { get; set; }
        public double total { get; set; }
        public string fecha { get; set; }
    }
}