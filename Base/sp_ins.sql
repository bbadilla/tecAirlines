-- EXECUTE sp_ins_usuario 'Maikel','Matamoroz','Zuñiga', 89754825, 1551, 'TEC', 'usussarrio1@hotmail.com', 'monkey'
CREATE PROCEDURE sp_ins_usuario(
	@Nombre			VARCHAR(20),
	@Apellido1		VARCHAR(20),
	@Apellido2		VARCHAR(20),
	@Telefono		INT,
	@Carne			INT,
	@Universidad	VARCHAR(4),
	@Correo			VARCHAR(35),
	@Contraseña		VARCHAR(10))
AS 
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
--EXECUTE sp_ins_vuelo 98784, 458445, '09/11/19 13:30:00.0', '10/11/19 13:30:00.0', 1, 1
CREATE PROCEDURE sp_ins_vuelo(
	@C_Economico	INT,
	@C_Ejecutivo	INT,
	@F_Salida		DATETIME,
	@F_Llegada		DATETIME,
	@Millas			INT,
	@ID_Aeronave	INT)
AS
INSERT INTO Vuelo(C_Economico, C_Ejecutivo,  F_Salida, F_Llegada, Millas, ID_Aeronave)
	VALUES(@C_Economico, @C_Ejecutivo, @F_Llegada, @F_Salida, @Millas, @ID_Aeronave)
RETURN 4

--EXECUTE sp_ins_escala 1, 'AAA', 'AAE', '09/11/19 13:30:00.0', '09/15/19 13:30:00.0'
--EXECUTE sp_ins_escala 5, 'AAE', 'AAA', '09/15/19 13:30:00.0', '10/11/19 13:30:00.0'
CREATE PROCEDURE sp_ins_escala(
	@C_Vuelo		CHAR(7),
	@A_Salida		VARCHAR(3),
	@A_Llegada		VARCHAR(3),
	@F_Salida		DATETIME,	
	@F_Llegada		DATETIME)
AS	
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
--EXECUTE sp_ins_universidad 'UACA'
CREATE PROCEDURE sp_ins_universidad(
	@Nombre			VARCHAR(4))
AS
IF EXISTS (SELECT Identificador FROM Universidad WHERE Nombre = @Nombre)
BEGIN
	RAISERROR('Esta universidad ya existe',1,1)
	RETURN 11
END
INSERT INTO Universidad(Nombre)
	VALUES
		(@Nombre)
RETURN 12
--EXECUTE sp_up_abrirvuelo 1
CREATE PROCEDURE sp_up_abrirvuelo(
	@C_Vuelo	INT)
AS
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
--EXECUTE sp_up_cerrarvuelo 1
CREATE PROCEDURE sp_up_cerrarvuelo(
	@C_Vuelo	INT)
AS
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
--EXECUTE sp_ins_reserva 'usussario1@hotmail.com', 1, 0
CREATE PROCEDURE sp_ins_reserva(
	@C_Usuario		VARCHAR(35),
	@C_Vuelo		INT,
	@Categoria		INT)
AS
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
	SELECT	COUNT(*)  Codigo
	FROM	Reserva)
INSERT INTO Tiquete (C_Reserva, Categoria)
	VALUES
	(@Contador, @Categoria)
Return 19
