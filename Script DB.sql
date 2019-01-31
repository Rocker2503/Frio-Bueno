IF EXISTS(select * from sys.databases where name='FrioBuenoBD')
DROP DATABASE FrioBuenoBD

CREATE DATABASE FrioBuenoBD

Create table Cliente(
	Id int not null primary key identity,
	Nombre text not null,
	NumGuia int not null,
    Patente text not null,
    Transporte text not null, 
    Conductor text not null,
    RutConductor text not null,   
	Fecha date not null,
    Temperatura int not null,
    NumSello int not null,
	PesoGuia text not null 
);

Create table Carga(
	Id int not null primary key identity,
    Producto text not null,
    TipoProducto text not null,
    UnidadSoportante text not null,
    CantidadUS int not null,
    Envase text not null,
    KgNeto text not null,
    IdCliente int not null references Cliente(Id)
	on update cascade
	on delete cascade
);

CREATE table DetalleCarga(
    Id int not null primary key identity,
    IdCarga int not null references Carga(Id)
	on update cascade
	on delete cascade,
    Producto text not null, 
    Envase text not null,
    CantidadEnvases int not null,
    KgEnvase text not null,
    FolioExterno int not null     
);

Create table Producto(
    Id int not null primary key identity,
    NumGuia int not null,
    FolioExterno int not null,
    FolioInterno int not null,
    Nombre text not null,
    Envase text not null,
    CantidadEnvases int not null
);

Create Table ProductosParaDespacho(
    Id int not null primary key identity,
    NumGuia int not null,
    FolioExterno int not null,
    FolioInterno int not null,
    Nombre text not null,
    Envase text not null,
    CantidadEnvases int not null,
    IdProducto int not null REFERENCES Producto(Id)
    on update CASCADE
    on delete CASCADE
);

Create Table LotesParaDespacho(
    Id int not null primary key identity,
    Nombre text not null,
    TipoProducto text not null,
    Envase text not null,
    IdCarga int not null REFERENCES Carga(Id)
    on UPDATE CASCADE
    on DELETE CASCADE
);

Create table AsocDespachoProductos(
    Id int not null primary key identity,
    NumOrden int not null,
    TipoDespacho text not null,
    NumGuia int not null,
    FolioInterno int not null,
    FolioExterno int not null,
    Producto text not null,
    CantidadEnvases int not null
);

