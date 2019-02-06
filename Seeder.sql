INSERT INTO Cliente (Nombre, NumGuia, Patente, Transporte, Conductor, RutConductor, Fecha, Temperatura, NumSello, PesoGuia)
VALUES ('BG Asesorias y Gestion Com. SPA', 23250, 'XX1111', 'No Figura', 'No Asigna', 'x.xxx.xxx-x', '2019-01-15',-18 , 233276,'25704,00');
INSERT INTO Cliente (Nombre, NumGuia, Patente, Transporte, Conductor, RutConductor, Fecha, Temperatura, NumSello, PesoGuia)
VALUES ('Procesos Naturales Vilkun SA', 43674, 'HLFT27', 'Leon Transportes', 'Ruben Diaz', 'x.xxx.xxx-x', '2019-01-08', -18, 1212,'23290,00');

INSERT INTO Carga (Producto, TipoProducto, UnidadSoportante, CantidadUS, Envase, KgNeto, IdCliente)
VALUES('Trutro Cuarto Pollo', 'Elaborado', 'Pallet', 23, 'Caja de 15 Kg', '25704,00', 1);
INSERT INTO Carga (Producto, TipoProducto, UnidadSoportante, CantidadUS, Envase, KgNeto, IdCliente)  
VALUES ('Arandano Brigitta Granel', 'Elaborado', 'Bins', 3, 'Bins 460.7', '1382,1', 2);   
INSERT INTO Carga (Producto, TipoProducto, UnidadSoportante, CantidadUS, Envase, KgNeto, IdCliente) 
VALUES('Arandano Camellia Granel', 'Elaborado', 'Bins', 1, 'Bins 460.7', '460,7', 2);
INSERT INTO Carga (Producto, TipoProducto, UnidadSoportante, CantidadUS, Envase, KgNeto, IdCliente) 
VALUES('Arandano Esmerald Granel', 'Elaborado', 'Bins', 3, 'Bins 460.7', '1382,1', 2);
INSERT INTO Carga (Producto, TipoProducto, UnidadSoportante, CantidadUS, Envase, KgNeto, IdCliente) 
VALUES('Arandano Legacy Granel', 'Elaborado', 'Bins', 1, 'Bins 460.7', '460,7', 2);

INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 76,'15', 4);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 77,'15', 5);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 77 ,'15', 6);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70 ,'15', 7);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 8);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 9);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 10);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 11);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 12);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 13);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 14);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 15);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70, '15', 16);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(2, 'Arandano Brigitta Granel', 'Bins 460.7', 1, '460,7', 1068501);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(2, 'Arandano Brigitta Granel', 'Bins 460.7', 1, '460,7', 1068502);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(2, 'Arandano Brigitta Granel', 'Bins 460.7', 1, '460,7', 1068503);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(3, 'Arandano Camellia Granel', 'Bins 460.7', 1, '460,7', 1068504);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(4, 'Arandano Esmerald Granel', 'Bins 460.7', 1, '460,7', 1068505);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(4, 'Arandano Esmerald Granel', 'Bins 460.7', 1, '460,7', 1068506);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(4, 'Arandano Esmerald Granel', 'Bins 460.7', 1, '460,7', 1068507);
INSERT INTO DetalleCarga (IdCarga, Producto, Envase, CantidadEnvases, KgEnvase, FolioExterno)
VALUES(5, 'Arandano Legacy Granel', 'Bins 460.7', 1, '460,7', 1068508);

INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 4, 1, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 76);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 5, 2, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 77);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 6, 3, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 77);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 7, 4, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 8, 5, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 9, 6, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 10, 7, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 11, 8, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 12, 9, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 13, 10, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 14, 11, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 15, 12, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(23250, 16, 13, 'Trutro Cuarto Pollo', 'Caja de 15 Kg', 70);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068501, 14, 'Arandano Brigitta Granel', 'Bins 460.7', 1);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068502, 15, 'Arandano Brigitta Granel', 'Bins 460.7', 1);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068503, 16, 'Arandano Brigitta Granel', 'Bins 460.7', 1);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068504, 17, 'Arandano Camellia Granel', 'Bins 460.7', 1);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068505, 18, 'Arandano Esmerald Granel', 'Bins 460.7', 1);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068506, 19, 'Arandano Esmerald Granel', 'Bins 460.7', 1);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068507, 20, 'Arandano Esmerald Granel', 'Bins 460.7', 1);
INSERT INTO Producto (NumGuia, FolioExterno, FolioInterno, Nombre, Envase, CantidadEnvases)
VALUES(43674, 1068508, 21, 'Arandano Legacy Granel', 'Bins 460.7', 1);
