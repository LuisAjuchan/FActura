using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factura.Models
{
    public class ModelProducto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
    }
}