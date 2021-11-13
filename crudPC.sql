create database crudPC
go
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
	cantidad int,
	fechaRegistro datetime default getdate()
)
go

-- Inserciones

select * from cliente
go 

select * from producto
go

select * from venta
go
-- Sentencia JOIN para venta --

select idVenta, p.idProducto, c.idCliente, nombreCompleto, rfc, (cantidad*p.precioVenta) as 'Total a pagar' from venta v 
inner join producto p on p.idProducto = v.idProducto
inner join cliente c on c.idCliente = v.idCliente
where cantidad <= stock

-- Sentencia JOIN para stock --

UPDATE producto set stock = stock - venta.cantidad from producto
inner join venta on venta.idProducto = producto.idProducto