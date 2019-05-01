--EXECUTE udsp_ins_usuario 'Maikel','Matamoroz','Zuñiga', 89754825, 1551, 'TEC', 'usussarrio1@hotmail.com', 'monkey'
CREATE PROCEDURE udsp_ins_usuario(
	@Nombre			VARCHAR(20),
	@Apellido1		VARCHAR(20),
	@Apellido2		VARCHAR(20),
	@Telefono		INT,
	@Carne			INT,
	@Universidad	VARCHAR(4),
	@Correo			VARCHAR(35),
	@Contraseña		VARCHAR(10))
AS 
BEGIN
	IF EXISTS (SELECT Correo FROM Usuario WHERE Correo = @Correo)
		BEGIN
			RAISERROR('Este correo ya ha sido registrado',1,1)
			RETURN 1
		END
	IF @Carne IS NOT NULL
	BEGIN
		DECLARE @ID_Universidad INT;
		IF NOT EXISTS (SELECT Identificador FROM Universidad WHERE  Nombre = @Universidad)
		BEGIN
			RAISERROR('Esta universidad no existe',1,1)
			RETURN 2
		END
		IF EXISTS (SELECT Correo FROM Usuario WHERE  Carne = @Carne)
		BEGIN
			RAISERROR('Este número de carné ya ha sido registrado',1,1)
			RETURN 3
		END
		ELSE
		BEGIN
			INSERT INTO	Usuario(Nombre, Apellido1, Apellido2, Telefono, Carne, Universidad, Correo, Contraseña) 
				VALUES(
					@Nombre,
					@Apellido1,
					@Apellido2,
					@Telefono,
					@Carne,
					@Universidad,
					@Correo,
					@Contraseña)
			SET @ID_Universidad = (
			SELECT	Identificador 
			FROM	Universidad 
			WHERE	Nombre = @Universidad);
			INSERT INTO Programa(C_Usuario, ID_Universidad, Millas) 
				VALUES(
					@Correo,			
					@ID_Universidad,
					0)
		RETURN 0
		END
	END
	ELSE
	BEGIN
		INSERT INTO	Usuario(Nombre, Apellido1, Apellido2, Telefono, Carne, Universidad, Correo, Contraseña) 
				VALUES(
					@Nombre,
					@Apellido1,
					@Apellido2,
					@Telefono,
					@Carne,
					@Universidad,
					@Correo,
					@Contraseña)
	RETURN 0
	END
END
GO
--EXECUTE udsp_ins_vuelo 'ADD2', 98784, 458445, '09/11/19 13:30:00.0', '10/11/19 13:30:00.0', 1, 1
CREATE PROCEDURE udsp_ins_vuelo(
	@Codigo			VARCHAR(4),
	@C_Economico	INT,
	@C_Ejecutivo	INT,
	@F_Salida		DATETIME,
	@F_Llegada		DATETIME,
	@A_Salida		VARCHAR(3),
	@A_Llegada		VARCHAR(3),
	@Millas			INT,
	@ID_Aeronave	INT)
AS
BEGIN
INSERT INTO Vuelo(Codigo, C_Economico, C_Ejecutivo,  F_Salida, F_Llegada, A_Salida, A_Llegada, Millas, ID_Aeronave)
	VALUES(@Codigo, @C_Economico, @C_Ejecutivo, @F_Llegada, @F_Salida, @A_Salida, @A_Llegada, @Millas, @ID_Aeronave)
RETURN 4
END
GO
--EXECUTE udsp_ins_escala 1, 'AAA', 'AAE', '09/11/19 13:30:00.0', '09/15/19 13:30:00.0'
CREATE PROCEDURE udsp_ins_escala(
	@C_Vuelo		VARCHAR(4),
	@A_Salida		VARCHAR(3),
	@A_Llegada		VARCHAR(3),
	@F_Salida		DATETIME,	
	@F_Llegada		DATETIME)
AS
BEGIN
IF NOT EXISTS (SELECT Codigo FROM Vuelo WHERE Codigo = @C_Vuelo)
BEGIN
	RAISERROR('Este vuelo no existe',1,1)
	RETURN 5
END
DECLARE @Contador INT
SET @Contador = (
	SELECT	COUNT(*)  C_Vuelo
	FROM	Escala 
	WHERE	C_Vuelo = @C_Vuelo);
IF @Contador > 3
BEGIN
	RAISERROR('No se pueden agregar mas escalas para este vuelo',1,1)
	RETURN 6
END
IF(@A_Salida = @A_Llegada)
BEGIN
	RAISERROR('El aeropuerto de llegada no puede ser el mismo de salida',1,1)
	RETURN 7
END
IF EXISTS (SELECT C_Vuelo FROM Escala WHERE A_Salida = @A_Salida and A_Llegada = @A_Llegada and C_Vuelo = @C_Vuelo)
BEGIN
	RAISERROR('Esta escala ya existe',1,1)
	RETURN 8
END
IF (NOT EXISTS (SELECT Nombre FROM airports WHERE Codigo = @A_Salida) OR 
	NOT EXISTS (SELECT Nombre FROM airports WHERE Codigo = @A_Llegada))
BEGIN
	RAISERROR('Aeropuerto(s) inexistente(s)',1,1)
	RETURN 9
END
INSERT INTO Escala(C_Vuelo, A_Salida, A_Llegada, F_Salida, F_Llegada)
	VALUES(@C_Vuelo, @A_Salida, @A_Llegada, @F_Salida, @F_Llegada)
RETURN 10
END
GO
--EXECUTE udsp_ins_universidad 'UACA'
CREATE PROCEDURE udsp_ins_universidad(
	@Nombre			VARCHAR(4))
AS
BEGIN
IF EXISTS (SELECT Identificador FROM Universidad WHERE Nombre = @Nombre)
BEGIN
	RAISERROR('Esta universidad ya existe',1,1)
	RETURN 11
END
INSERT INTO Universidad(Nombre)
	VALUES
		(@Nombre)
RETURN 12
END
GO
--EXECUTE udsp_up_abrirvuelo 1
CREATE PROCEDURE udsp_up_abrirvuelo(
	@C_Vuelo	VARCHAR(4))
AS
BEGIN
DECLARE @Estado BIT;
SET @Estado = (
SELECT	Estado
FROM	Vuelo 
WHERE	Codigo = @C_Vuelo)
IF @Estado = 1
BEGIN
	RAISERROR('Este vuelo ya esta abierto',1,1)
	RETURN 13
END
UPDATE Vuelo
SET Estado = 1
WHERE Codigo = @C_Vuelo
RETURN 14
END
GO
--EXECUTE udsp_up_cerrarvuelo 1
CREATE PROCEDURE udsp_up_cerrarvuelo(
	@C_Vuelo	VARCHAR(4))
AS
BEGIN
DECLARE @Estado BIT;
SET @Estado = (
SELECT	Estado
FROM	Vuelo 
WHERE	Codigo = @C_Vuelo)
IF @Estado = 0
BEGIN
	RAISERROR('Este vuelo ya esta cerrado',1,1)
	RETURN 15
END
UPDATE Vuelo
SET Estado = 0
WHERE Codigo = @C_Vuelo
RETURN 16
END
GO
--EXECUTE udsp_ins_reserva 'usussarrio1@hotmail.com', 6, 1, 1
CREATE PROCEDURE udsp_ins_tiquete(
	@Iteraciones	INT,
	@C_Reserva		INT, 
	@Categoria		INT
	)
AS
BEGIN
	IF @Iteraciones > 0
	BEGIN
		INSERT INTO Tiquete (C_Reserva, Categoria)
		VALUES
		(@C_Reserva, @Categoria)
		DECLARE @Iteracion INT
		SET @Iteracion = @Iteraciones - 1
		EXECUTE udsp_ins_tiquete @Iteracion, @C_Reserva, @Categoria
	END
END
GO
CREATE PROCEDURE udsp_ins_reserva(
	@C_Usuario		VARCHAR(35),
	@C_Vuelo		INT,
	@C_Economico	INT,	--Cantidad de tiquetes economicos
	@C_Ejecutivo	INT)	--Cantidad de tiquetes ejecutivos
AS
BEGIN
IF NOT EXISTS (SELECT Codigo FROM Vuelo WHERE Codigo = @C_Vuelo)
BEGIN
	RAISERROR('Este vuelo no existe',1,1)
	RETURN 17
END	
IF NOT EXISTS (SELECT Correo FROM Usuario WHERE Correo = @C_Usuario)
BEGIN
	RAISERROR('Este usuario no existe',1,1)
	RETURN 18
END
INSERT INTO Reserva (C_Usuario,C_Vuelo)
	VALUES
	(@C_Usuario, @C_Vuelo)
DECLARE @Contador INT
SET @Contador = (
	SELECT	MAX(Codigo)
	FROM	Reserva)
EXECUTE udsp_ins_tiquete @C_Economico, @Contador, 0
EXECUTE udsp_ins_tiquete @C_Ejecutivo, @Contador, 1
Return 19
END
GO
CREATE PROCEDURE udsp_ins_pago(
	@Numero			INT,
	@Contraseña		INT,
	@Expiracion		DATE,
	@Titular		VARCHAR(40),
	@C_Reserva		INT)
AS
BEGIN
	DECLARE @Pago BIT;
	SET @Pago = (
	SELECT	Pago
	FROM	Reserva 
	WHERE	Codigo = @C_Reserva)
	IF @Pago = 0
	BEGIN
		UPDATE Reserva
		SET Pago = 1
		WHERE Codigo = @C_Reserva
		INSERT INTO Pago(Numero, Contraseña, Expiracion, Titular, C_Reserva)
			VALUES(@Numero, @Contraseña, @Expiracion, @Titular, @C_Reserva)
		RETURN 20
	END
	ELSE
	BEGIN
		RAISERROR('Esta reserva ya ha sido pagada',1,1)
		RETURN 21
	END
END
GO
--EXECUTE udsp_up_reserva 8, 2
CREATE PROCEDURE udsp_up_reserva(
	@C_Reserva		INT,
	@C_Maletas		INT)
AS
BEGIN
	IF EXISTS (SELECT Codigo FROM Reserva WHERE Codigo = @C_Reserva)
	BEGIN
		UPDATE Reserva
		SET Chequeo = 1,
			Equipaje = @C_Maletas
		WHERE Codigo = @C_Reserva
		RETURN 22
	END
END
GO
--EXECUTE udsp_up_tiquete 2, 4
CREATE PROCEDURE udsp_up_tiquete(
	@Identificador	INT,
	@N_Asiento		INT)
AS
BEGIN
	IF EXISTS (SELECT Identificador FROM Tiquete WHERE Identificador = @Identificador)
	BEGIN
		IF EXISTS (SELECT Identificador FROM Tiquete WHERE N_Asiento = @N_Asiento)
		BEGIN
			RAISERROR('El asiento ya esta ocupado',1,1)
			RETURN 23
		END
		ELSE
		BEGIN
			UPDATE Tiquete
			SET N_Asiento = @N_Asiento
			WHERE Identificador = @Identificador
			RETURN 24
		END
	END
END
GO
