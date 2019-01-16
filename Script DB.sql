IF EXISTS(select * from sys.databases where name='FrioBuenoDB')
DROP DATABASE FrioBuenoDB

CREATE DATABASE FrioBuenoDB

Create table Cliente(
	Id int not null primary key identity,
	Nombre varchar(255) not null,
	NumGuia int not null,
	Fecha date not null,
	Conductor varchar(255) not null,
	RutConductor varchar(255) not null,
	Transporte varchar(6) not null,
	PesoGuia int not null 
);

Create table Carga(
	NumLote int not null primary key identity,
    Producto varchar(255) not null,
    TipoProducto varchar(255) not null,
    UnidadSoportante varchar (255) not null,
    CantidadUS int not null,
    Envase varchar(255) not null,
    KgNeto int not null,
    IdCliente int not null references Cliente(Id)
);

CREATE table DetalleCarga(
    FolioInterno int not null primary key identity,
    NumLote int not null references Carga(NumLote),
    Producto varchar(255) not null, 
    Envase varchar(255) not null,
    KgEnvase int not null,
    FolioExterno int not null
);

Create table ClienteDetalle(
    Id int not null primary key identity,
	IdCliente int not null references Cliente(Id),
    FolioInterno int not null references DetalleCarga(FolioInterno),
    Producto varchar(255) not null,
    Envase varchar(255) not null
);

Create table Producto(
    Id int not null primary key identity,
    NumGuia int not null,
    FolioExterno int not null,
    FolioInterno int not null,
    Nombre varchar(255) not null,
    Envase varchar(255) not null,
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
    Nombre varchar(255) not null,
    NumGuia int not null,
    Fecha date not null
);
