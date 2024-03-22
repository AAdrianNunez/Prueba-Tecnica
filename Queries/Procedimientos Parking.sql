CREATE PROC USPListarClientes
AS
BEGIN
	SELECT
		 IDCliente
		,Nombre
		,Apellidos
		,DNI
		,Telefono
		,Email
	FROM [dbo].[Cliente]
	WHERE ESTADO = 1
END
GO

CREATE PROC USPRegistrarCliente
	 @Nombre	VARCHAR(128)
	,@Apellidos	VARCHAR(128)
	,@DNI		CHAR(8)
	,@Telefono	CHAR(9)
	,@Email		VARCHAR(64)
AS
BEGIN
	INSERT INTO [dbo].[Cliente](
		 Nombre
		,Apellidos
		,DNI
		,Telefono
		,Email
	) VALUES (
		 @Nombre
		,@Apellidos
		,@DNI
		,@Telefono
		,@Email
	)
END
GO

CREATE PROC USPModificarCliente
	 @IDCliente	BIGINT
	,@Nombre	VARCHAR(128)
	,@Apellidos	VARCHAR(128)
	,@DNI		CHAR(8)
	,@Telefono	CHAR(9)
	,@Email		VARCHAR(64)
AS
BEGIN
	UPDATE [dbo].[Cliente]
	SET  Nombre = @Nombre
		,Apellidos = @Apellidos
		,DNI = @DNI
		,Telefono = @Telefono
		,Email = @Email
	WHERE IDCliente = @IDCliente
END
GO

CREATE PROC USPEliminarCliente
	@IDCliente	BIGINT
AS
BEGIN
	--Eliminación Lógica
	UPDATE [dbo].[Cliente]
	SET Estado = 0
	WHERE IDCliente = @IDCliente
END
GO

CREATE PROC USPListarVehiculos
	@IDCliente	BIGINT
AS
BEGIN
	SELECT
		 V.IDVehiculo
		,M.IDMarca
		,M.Nombre AS NombreMarca
		,O.IDModelo
		,O.Descripcion AS DescripcionModelo
		,V.Placa
	FROM [dbo].[Vehiculo] V
	INNER JOIN [dbo].[Modelo] O
		ON V.IDModelo = O.IDModelo
	INNER JOIN [dbo].[Marca] M
		ON O.IDMarca = M.IDMarca
	WHERE IDCliente = @IDCliente
	AND V.Estado = 1
END
GO

CREATE PROC USPListarMarcas
AS
BEGIN
	SELECT 
		 IDMarca
		,Nombre
	FROM [dbo].[Marca]
END
GO

CREATE PROC USPListarModelos
	@IDMarca	BIGINT
AS
BEGIN
	SELECT 
		 IDModelo
		,Descripcion
	FROM [dbo].[Modelo]
	WHERE IDMarca = @IDMarca
END
GO

CREATE PROC USPRegistrarVehiculo
	 @IDCliente	BIGINT
	,@IDModelo	BIGINT
	,@Placa		CHAR(6)
AS
BEGIN
	INSERT INTO [dbo].[Vehiculo](
		 IDCliente
		,IDModelo
		,Placa
	) VALUES (
		 @IDCliente
		,@IDModelo
		,@Placa
	)
END
GO

CREATE PROC USPModificarVehiculo
	 @IDVehiculo	BIGINT
	,@IDModelo		BIGINT
	,@Placa			CHAR(6)
AS
BEGIN
	UPDATE [dbo].[Vehiculo]
	SET	 IDModelo = @IDModelo
		,Placa = @Placa
	WHERE IDVehiculo = @IDVehiculo
END
GO

CREATE PROC USPEliminarVehiculo
	@IDVehiculo	BIGINT
AS
BEGIN
	--Eliminación Lógica
	UPDATE [dbo].[Vehiculo]
	SET Estado = 0
	WHERE IDVehiculo = @IDVehiculo
END
GO

CREATE PROC USPValidarUsuario
	 @Usuario	VARCHAR(64)
	,@Contrasena	VARCHAR(64)
AS
BEGIN
	SELECT 
		IDUsuario
	FROM [dbo].[Usuario]
	WHERE Usuario = @Usuario
	AND Contrasena = @Contrasena
END