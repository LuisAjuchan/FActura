
CREATE PROCEDURE spr_CrearFactura
	@idFactura int,
	@idCliente int,
	@total FLOAT,
	@fecha NVARCHAR(10)
	
AS
BEGIN
	INSERT INTO tbl_Factura VALUES (@idFactura,@idCliente,@total,@fecha)
END
GO

CREATE PROCEDURE spr_ListarProductos 
AS
BEGIN
	SELECT * FROM tbl_Producto
END
GO
CREATE PROCEDURE spr_ListarClientes
AS
BEGIN
	SELECT * FROM tbl_Cliente
END
GO