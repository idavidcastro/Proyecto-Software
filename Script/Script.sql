create database ProyectoSoftware;

use ProyectoSoftware;

create table Producto(RefProducto nvarchar(15) primary key, Nombre nvarchar(15), Peso nvarchar(15), Precio nvarchar(15));

create table Empaque(RefEmpaque nvarchar(15) primary key,  RefProducto nvarchar(15), Producto nvarchar(15), PesoProducto nvarchar(15), PrecioProducto nvarchar(15),
					Largo nvarchar(15), Ancho nvarchar(15), Alto nvarchar(15), PesoEmpaque nvarchar(15), CantProductos nvarchar(15), PrecioProdXCantProdEmpaque nvarchar(15), 
					PesoEmpaqXPesoProducto nvarchar(15));


select *from Producto;