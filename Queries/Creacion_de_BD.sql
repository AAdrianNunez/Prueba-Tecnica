CREATE DATABASE Parking
GO

USE Parking
GO

IF EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Cliente' and TYPE = 'U')
BEGIN
	DROP TABLE [dbo].[Cliente]
END

--CLIENTE
CREATE TABLE [dbo].[Cliente](
	IDCliente BIGINT NOT NULL IDENTITY,
	Nombre VARCHAR(128) NOT NULL,
	Apellidos VARCHAR(128) NOT NULL,
	DNI CHAR(8) NOT NULL,
	Telefono CHAR(9) NOT NULL,
	Email VARCHAR(64) NOT NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY(IDCliente)
)
GO

--Marca

IF EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Marca' and TYPE = 'U')
BEGIN
	DROP TABLE [dbo].[Marca]
END

CREATE TABLE [dbo].[Marca](
	IDMarca BIGINT NOT NULL IDENTITY,
	Nombre VARCHAR(100) NOT NULL,
	CONSTRAINT PK_Marca PRIMARY KEY(IDMarca),
)
GO

--MODELO

IF EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Modelo' and TYPE = 'U')
BEGIN
	DROP TABLE [dbo].[Modelo]
END

CREATE TABLE [dbo].[Modelo](
	IDModelo BIGINT NOT NULL IDENTITY,
	IDMarca BIGINT NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	CONSTRAINT PK_Modelo PRIMARY KEY(IDModelo),
	CONSTRAINT FK_Modelo_Marca FOREIGN KEY(IDMarca) REFERENCES Marca(IDMarca),
)
GO

--VEHICULO

IF EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Vehiculo' and TYPE = 'U')
BEGIN
	DROP TABLE [dbo].[Vehiculo]
END

CREATE TABLE [dbo].[Vehiculo](
	IDVehiculo BIGINT NOT NULL IDENTITY,
	IDCliente BIGINT NOT NULL,
	IDModelo BIGINT NOT NULL,
	Placa CHAR(6) NOT NULL,
	CONSTRAINT PK_Vehiculo PRIMARY KEY(IDVehiculo),
	CONSTRAINT FK_Vehiculo_Cliente FOREIGN KEY(IDCliente) REFERENCES Cliente(IDCliente),
	CONSTRAINT FK_Vehiculo_Modelo FOREIGN KEY(IDModelo) REFERENCES Modelo(IDModelo),
)
GO

--ESTACIONAMIENTO

IF EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Estacionamiento' and TYPE = 'U')
BEGIN
	DROP TABLE [dbo].[Estacionamiento]
END

CREATE TABLE [dbo].[Estacionamiento](
	IDEstacionamiento BIGINT NOT NULL IDENTITY,
	Numero INT NOT NULL,
	Estado TINYINT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Estacionamiento PRIMARY KEY(IDEstacionamiento),
)
GO

--PLAZAS

IF EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Plazas' and TYPE = 'U')
BEGIN
	DROP TABLE [dbo].[Plazas]
END

CREATE TABLE [dbo].[Plazas](
	IDPlazas BIGINT NOT NULL IDENTITY,
	IDVehiculo BIGINT NOT NULL,
	IDEstacionamiento BIGINT NOT NULL,
	FechaInicio DATE,
	FechaFin DATE,
	Estado TINYINT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Plazas PRIMARY KEY(IDPlazas),
	CONSTRAINT FK_Plazas_Vehiculo FOREIGN KEY(IDVehiculo) REFERENCES Vehiculo(IDVehiculo),
	CONSTRAINT FK_Plazas_Estacionamiento FOREIGN KEY(IDEstacionamiento) REFERENCES Estacionamiento(IDEstacionamiento),
)
GO

--USUARIO

IF EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Usuario' and TYPE = 'U')
BEGIN
	DROP TABLE [dbo].[Usuario]
END

CREATE TABLE [dbo].[Usuario](
	IDUsuario BIGINT NOT NULL IDENTITY,
	Usuario VARCHAR(64) NOT NULL,
	Contrasena VARCHAR(64) NOT NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY(IDUsuario),
)
GO
-- INSERTS MARCA
INSERT INTO Marca (Nombre) VALUES ('Toyota');
INSERT INTO Marca (Nombre) VALUES ('Ford');
INSERT INTO Marca (Nombre) VALUES ('Chevrolet');
INSERT INTO Marca (Nombre) VALUES ('Honda');
INSERT INTO Marca (Nombre) VALUES ('Volkswagen');
-- INSERTS MODELOS
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (1,'Corolla');
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (1,'RAV4');
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (2,'Mustang');
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (3,'Camaro');
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (3,'Silverado');
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (4,'Civic');
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (5,'Golf');
INSERT INTO Modelo (IDMarca,Descripcion) VALUES (5,'Jetta');
-- INSERTS ESTACIONAMIENTOS
INSERT INTO Estacionamiento (Numero) VALUES (101);
INSERT INTO Estacionamiento (Numero) VALUES (102);
INSERT INTO Estacionamiento (Numero) VALUES (103);
INSERT INTO Estacionamiento (Numero) VALUES (104);
INSERT INTO Estacionamiento (Numero) VALUES (105);
INSERT INTO Estacionamiento (Numero) VALUES (106);
INSERT INTO Estacionamiento (Numero) VALUES (107);
INSERT INTO Estacionamiento (Numero) VALUES (108);
INSERT INTO Estacionamiento (Numero) VALUES (109);
INSERT INTO Estacionamiento (Numero) VALUES (110);
-- INSERT USUARIO
INSERT INTO Usuario (Usuario, Contrasena) VALUES ('Adrian','Capibara123')



