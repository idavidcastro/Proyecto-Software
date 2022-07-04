create database ProyectoSoftware;

use ProyectoSoftware;

create table Producto(RefProducto nvarchar(15) primary key, Nombre nvarchar(15), Peso nvarchar(15), Precio nvarchar(15));

create table Empaque(RefEmpaque nvarchar(15) primary key,  RefProducto nvarchar(15), Producto nvarchar(15), PesoProducto nvarchar(15), PrecioProducto nvarchar(15),
					Largo nvarchar(15), Ancho nvarchar(15), Alto nvarchar(15), PesoEmpaque nvarchar(15), CantProductos nvarchar(15), PrecioProdXCantProdEmpaque nvarchar(15), 
					PesoEmpaqXPesoProducto nvarchar(15));

create table Embalaje(RefEmbalaje nvarchar(15) primary key, RefEmpaque nvarchar(15), Largo nvarchar(15), Ancho nvarchar(15), Alto nvarchar(15), EmpXLargo nvarchar(15), EmpXAncho nvarchar(15),
					EmpXAlto nvarchar(15), TotalEmpaqueXEmbalaje nvarchar(15));

alter table Empaque add constraint FK_RefProducto foreign key (RefProducto) references Producto(RefProducto);
alter table Embalaje add constraint FK_RefEmpaque foreign key (RefEmpaque) references Empaque(RefEmpaque);

drop table Producto;
drop table Empaque;
drop table Embalaje;


select *from Producto;

select *from Empaque;

select *from Embalaje;



