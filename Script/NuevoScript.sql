create database nuevoProyectoSoftware;

use nuevoProyectoSoftware;

create table Producto(RefProducto nvarchar(15) primary key, Nombre nvarchar(15), Peso nvarchar(15), Precio nvarchar(15));

create table Empaque(RefEmpaque nvarchar(15) primary key,  RefProducto nvarchar(15), Producto nvarchar(15), PesoProducto nvarchar(15), PrecioProducto nvarchar(15),
					Largo nvarchar(15), Ancho nvarchar(15), Alto nvarchar(15), PesoEmpaque nvarchar(15), CantProductos nvarchar(15), PrecioProdXCantProdEmpaque nvarchar(15), 
					PesoEmpaqXPesoProducto nvarchar(15));

create table Embalaje(RefEmbalaje nvarchar(15) primary key, RefEmpaque nvarchar(15), Largo nvarchar(15), Ancho nvarchar(15), Alto nvarchar(15), EmpXLargo nvarchar(15), EmpXAncho nvarchar(15),
					EmpXAlto nvarchar(15), TotalEmpaqueXEmbalaje nvarchar(15));

create table Estibado(RefEstibado nvarchar(15) primary key, RefEmbalaje nvarchar(15), Largo nvarchar(15), Ancho nvarchar(15), Alto nvarchar(15), EmbalajeXLargo nvarchar(15),
					EmbalajeXAncho nvarchar(15), EmbalajeXAlto nvarchar(15), TotalEmbalajesXEstibas nvarchar(15));

create table Contenedor(RefContenedor nvarchar(30) primary key, RefEstibado nvarchar(15), TipoContenedor nvarchar(30), Largo nvarchar(30), Ancho nvarchar(30),
						EstibadoXLargo nvarchar(30), EstibadoXAncho nvarchar(30),TotalEstibasXContenedor nvarchar(30), NumEstibasXProducto nvarchar(30), TotalEmbalajesEnContenedor nvarchar(30));

create table Orden(RefOrden nvarchar(30) primary key, RefContenedor nvarchar(30), ValorCarga nvarchar(30));

create table Usuario(NombreUsuario nvarchar(30) primary key, contraseña nvarchar(30) );

insert into Usuario values ('ivan', '12345')
insert into Usuario values ('daniel','12345');

alter table Empaque add constraint FK_RefProducto foreign key (RefProducto) references Producto(RefProducto);
alter table Embalaje add constraint FK_RefEmpaque foreign key (RefEmpaque) references Empaque(RefEmpaque);
alter table Estibado add constraint FK_RefEmbalaje foreign key (RefEmbalaje) references Embalaje(RefEmbalaje);
alter table Contenedor add constraint FK_RefEstibado foreign key (RefEstibado) references Estibado(RefEstibado);
alter table Orden add constraint FK_RefContenedor foreign key (RefContenedor) references Contenedor(RefContenedor);


select *from Producto;

select *from Empaque;

select *from Embalaje;

select *from Estibado;

select *from Contenedor;

select * from Orden;

select * from Usuario

