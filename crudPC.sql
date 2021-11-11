create database crudPC
use crudPC
go
create table cliente(
	idCliente int primary key identity,
	nombreCompleto varchar(100),
	correo varchar(50),
	rfc varchar(20),
	fechaCreacion datetime default getdate()
)
go

create table producto(
	idProducto int primary key identity,
	codigo varchar(50),
	nombreProducto varchar(100),
	descripcion varchar(100),
	stock int not null default 0,
	precioCompra decimal,
	precioVenta decimal,
	fechaCreacion datetime default getdate()
)
go

create table venta(
	idVenta int primary key identity,
	idProducto int references producto(idProducto),
	idCliente int references cliente(idCliente),
	nombreCliente varchar(100),
	montoPago decimal(10,4),
	montoCambio decimal(10,4),
	montoTotal decimal(10,4),
	fechaRegistro datetime default getdate()
)