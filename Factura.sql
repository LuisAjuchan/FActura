CREATE DATABASE Factura;
GO

CREATE TABLE tbl_Cliente(
	idCliente INT NOT NULL PRIMARY KEY IDENTITY,
	nombre NVARCHAR(255) NOT NULL,
	nit int NOT NULL
);
GO

INSERT INTO tbl_Cliente VALUES ('Kevin Barrios',12356789);
INSERT INTO tbl_Cliente VALUES ('Josué Pérez',12356789);
INSERT INTO tbl_Cliente VALUES ('Daniel Barrios',12356789);
INSERT INTO tbl_Cliente VALUES ('Diego Barrios',12356789);

CREATE TABLE tbl_Producto(
	idProducto INT NOT NULL PRIMARY KEY IDENTITY,
	nombre NVARCHAR(255) NOT NULL,
	precio FLOAT NOT NULL
);
GO

INSERT INTO tbl_Producto VALUES ('Producto 1',79.90);
INSERT INTO tbl_Producto VALUES ('Producto 2',120.10);
INSERT INTO tbl_Producto VALUES ('Producto 3',45.25);
INSERT INTO tbl_Producto VALUES ('Producto 4',20.75);

CREATE TABLE tbl_Factura(
	idFactura INT NOT NULL PRIMARY KEY IDENTITY,
	idCliente INT NOT NULL,
	total FLOAT NOT NULL,
	fecha NVARCHAR(10) NOT NULL,
	FOREIGN KEY (idCliente) REFERENCES tbl_Cliente(idCliente)
);
GO

CREATE TABLE tbl_DetalleFactura(
	idDetalleFactura INT NOT NULL PRIMARY KEY IDENTITY,
	idFactura INT NOT NULL,
	idProducto INT NOT NULL,
	cantidad INT NOT NULL,
	FOREIGN KEY (idFactura) REFERENCES tbl_Factura(idFactura),
	FOREIGN KEY (idProducto) REFERENCES tbl_Producto(idProducto)
);
GO