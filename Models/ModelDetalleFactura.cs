using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factura.Models
{
    public class ModelDetalleFactura
    {
        public int idDetalleFactura { get; set; }

        public int idFactura { get; set; }

        public int idProducto { get; set; }

        public int cantidad { get; set; }

    }
}