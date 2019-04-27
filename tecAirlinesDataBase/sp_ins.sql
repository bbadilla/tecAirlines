CREATE PROCEDURE sp_ins_vuelo(
	@Codigo			CHAR(7),
	@Costo			INT,
	@F_Salida		TIME,
	@F_Llegada		TIME,
	@Distancia		INT,
	@ID_Aeronave	INT,
	@A_Economicos	INT,
	@A_Ejecutivos	INT)
AS
	IF EXISTS (SELECT Codigo FROM Vuelo WHERE Codigo = @Codigo)
	BEGIN
		RAISERROR('Este código ya ha sido registrado para otro vuelo',1,1)
		RETURN 1
	END
	DECLARE @C_Asientos INT;
	SET @C_Asientos = (
				SELECT Capacidad 
				FROM Aeronave 
				WHERE  Identificador = @ID_Aeronave);
	IF (@A_Economicos  + @A_Ejecutivos > @C_Asientos)
	BEGIN
		RAISERROR('La distribucion de asientos sugerida es superior a la de la aeronave',1,1)
		RETURN 2
	END
	INSERT INTO Vuelo(Codigo, Estado, Costo, F_Salida, F_Llegada, Distancia, ID_Aeronave, A_Economicos, A_Ejecutivos)
		VALUES(@Codigo, 1, @Costo, @F_Llegada, @F_Salida, @Distancia, @ID_Aeronave, @A_Economicos, @A_Ejecutivos)
	RETURN 0

CREATE PROCEDURE sp_ins_escala(
	@C_Vuelo		CHAR(7),
	@A_Salida		VARCHAR(3),
	@A_Llegada		VARCHAR(3),
	@F_Salida		TIME,	
	@F_Llegada		TIME,
	@Millas			INT)
AS	
	IF NOT EXISTS (SELECT Codigo FROM Vuelo WHERE Codigo = @C_Vuelo)
	BEGIN
		RAISERROR('Este vuelo no existe',1,1)
		RETURN 3
	END
	IF(@A_Salida = @A_Llegada)
	BEGIN
		RAISERROR('El aeropuerto de llegada no puede ser el mismo de salida',1,1)
		RETURN 4
	END
	IF EXISTS (SELECT C_Vuelo FROM Escala WHERE A_Salida = @A_Salida and A_Llegada = @A_Llegada and C_Vuelo = @C_Vuelo)
	BEGIN
		RAISERROR('Esta escala ya existe',1,1)
		RETURN 5
	END
	IF (NOT EXISTS (SELECT Nombre FROM airports WHERE Codigo = @A_Salida) OR 
		NOT EXISTS (SELECT Nombre FROM airports WHERE Codigo = @A_Llegada))
	BEGIN
		RAISERROR('Aeropuerto(s) inexistente(s)',1,1)
		RETURN 6
	END
	INSERT INTO Escala(C_Vuelo, A_Salida, A_Llegada, F_Salida, F_Llegada, Millas)
		VALUES(@C_Vuelo, @A_Salida, @A_Llegada, @F_Salida, @F_Llegada, @Millas)