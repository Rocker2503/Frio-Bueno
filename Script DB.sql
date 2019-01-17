IF EXISTS(select * from sys.databases where name='FrioBuenoDB')
DROP DATABASE FrioBuenoDB

CREATE DATABASE FrioBuenoDB

Create table Cliente(
	Id int not null primary key identity,
	Nombre text not null,
	NumGuia int not null,
    Patente text not null,
    Transporte text not null, 
    Conductor text not null,
    RutConductor text not null,   
	Fecha date not null,
	PesoGuia float(20) not null 
);

Create table Carga(
	Id int not null primary key identity,
    Producto text not null,
    TipoProducto text not null,
    UnidadSoportante text not null,
    CantidadUS int not null,
    Envase text not null,
    KgNeto float(20) not null,
    IdCliente int not null references Cliente(Id)
);

CREATE table DetalleCarga(
    Id int not null primary key identity,
    IdCarga int not null references Carga(Id),
    Producto text not null, 
    Envase text not null,
    KgEnvase float(20) not null,
    FolioExterno int not null
);

Create table ClienteDetalle(
    Id int not null primary key identity,
	IdCliente int not null references Cliente(Id),
    FolioInterno int not null references DetalleCarga(Id),
    Producto text not null,
    Envase text not null
);

Create table Producto(
    Id int not null primary key identity,
    NumGuia int not null,
    FolioExterno int not null,
    FolioInterno int not null,
    Nombre text not null,
    Envase text not null,
    Banda int not null,
    Piso int not null,
    Altura int not null
);

Create table OrdenDespacho(
    Id int not null primary key identity,
    CantidadProductos int not null
);

Create table OrdenAlmacenado(
    IdOrden int not null references OrdenDespacho(Id),
    IdProducto int not null references Producto(Id),
    NumGuia int not null,
    FolioExterno int not null,
    FolioInterno int not null
);

Create table Despacho(
    Id int not null primary key identity,
    IdOrdenDespacho int not null references OrdenDespacho(Id),
    IdCliente int not null references Cliente(Id),
    Nombre text not null,
    NumGuia int not null,
    Fecha date not null
);
