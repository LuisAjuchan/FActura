using Factura.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Factura.Controllers
{
    public class FacturaController : Controller
    {
        string cadenaConexion = "data source=alejo5269.database.windows.net;initial catalog=Factura;persist security info=True;user id=adminPruebaMVC;Password= Mvcrules2018; MultipleActiveResultSets=True;App=EntityFramework";
   
      //  string cadenaConexion = "Data Source=DESKTOP-7ALT5DI/SQLSERVER_2016;Initial Catalog=Factura;Integrated Security=True";

        // GET: Factura
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String CrearFactura(FacturaViewModel modelo)
        {
            return Conexion(modelo);
        }

        public ActionResult ListarClientes()
        {
           // string cadenaConexion = "data source=DESKTOP-7ALT5DI\\SQLSERVER_2016;initial catalog=Factura;integrated security=True;";
            using (SqlConnection conexionBD = new SqlConnection(cadenaConexion))
            {
                SqlTransaction transaccion = null;
                try
                {
                    conexionBD.Open();
                    transaccion = conexionBD.BeginTransaction("Transaccion");
                    List<ModelCliente> clientes = new List<ModelCliente>();
                    var comando = new SqlCommand("spr_ListarClientes", conexionBD, transaccion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                    using (var listar = comando.ExecuteReader())
                    {
                        while (listar.Read())
                        {
                            ModelCliente cliente = new ModelCliente();
                            cliente.idCliente = Convert.ToInt32(listar["idCliente"]);
                            cliente.nombre = Convert.ToString(listar["nombre"]);
                            cliente.nit = Convert.ToInt32(listar["nit"]);
                            clientes.Add(cliente);
                        }

                    }
                    transaccion.Commit();
                    return Json(clientes, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        public ActionResult ListarProductos()
        {
           // string cadenaConexion = "data source=DESKTOP-7ALT5DI\\SQLSERVER_2016;initial catalog=Factura;integrated security=True;";
            using (SqlConnection conexionBD = new SqlConnection(cadenaConexion))
            {
                SqlTransaction transaccion = null;
                try
                {
                    conexionBD.Open();
                    transaccion = conexionBD.BeginTransaction("Transaccion");
                    List<ModelProducto> productos = new List<ModelProducto>();
                    var comando = new SqlCommand("spr_ListarProductos", conexionBD, transaccion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                    using (var listar = comando.ExecuteReader())
                    {
                        while (listar.Read())
                        {
                            ModelProducto producto = new ModelProducto();
                            producto.idProducto = Convert.ToInt32(listar["idProducto"]);
                            producto.nombre = Convert.ToString(listar["nombre"]);
                            producto.precio = Convert.ToDouble(listar["precio"]);
                            productos.Add(producto);
                        }

                    }
                    transaccion.Commit();
                    return Json(productos,JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

       
        public string Conexion(FacturaViewModel facturaNueva)
        {
            //string cadenaConexion = "Data Source=DESKTOP-7ALT5DI/SQLSERVER_2016;Initial Catalog=Factura;Integrated Security=True";
            using (SqlConnection conexionBD = new SqlConnection(cadenaConexion))
            {
                SqlTransaction transaccion = null;
                try
                {
                    conexionBD.Open();
                    transaccion = conexionBD.BeginTransaction("tran1");
                    string query = "insert into tbl_factura(idCliente, total, fecha) " +
                        "values (@idCliente, @total, @fecha);SELECT SCOPE_IDENTITY()";
                    SqlCommand comando = new SqlCommand(query, conexionBD, transaccion);
                    comando.Parameters.AddWithValue("@idCliente", facturaNueva.idCliente);
                    comando.Parameters.AddWithValue("@total", 0);
                    comando.Parameters.AddWithValue("@fecha", "2018-25");
                    //idFactura = 2
                    //insert into factura
                    //Nos devuelve el idCreado con el Scope_identity
                   object resultado =  comando.ExecuteScalar();
                    int idFacturaCreada = Int32.Parse(resultado.ToString());
                    foreach(var det in facturaNueva.detalleFactura)
                    {
                        string insertarDetalle = "insert into tbl_DetalleFactura " +
                            "(idFactura, idProducto, cantidad) values (@idFactura, @idProducto, @cantidad)";
                        SqlCommand comandoDetalle = new SqlCommand(insertarDetalle, conexionBD, transaccion);
                        // comando.CommandText = 
                        comandoDetalle.Parameters.AddWithValue("@idFactura", idFacturaCreada);
                        comandoDetalle.Parameters.AddWithValue("@idProducto", det.idProducto);
                        comandoDetalle.Parameters.AddWithValue("@cantidad", det.cantidad);
                        //insert into detalleFactura
                        comandoDetalle.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                    return "OK";
                }
                catch (SqlException exception)
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                    return "Hubo un error de tipo SQL:  " + exception.Message;
                }
                catch (Exception exception)
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                    return "Hubo un error general:  " + exception.Message;
                }
            }
            
        }
    }
}