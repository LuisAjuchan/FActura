using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factura.Models
{
    public class DetalleFacturaViewModel
    {
        public int idProducto { set; get; }
        public int cantidad { set; get; }

    }


    public class FacturaViewModel
    {
        public int idCliente{ set; get; }
        public List<DetalleFacturaViewModel> detalleFactura { set; get; } 

    }

    


}