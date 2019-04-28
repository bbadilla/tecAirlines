--Glosario
--0 ak14
--1 Este correo ya ha sido registrado
--2 Esta universidad no existe

CREATE PROCEDURE Insertar_Usuario(
	@Nombre			VARCHAR(20),
	@Apellido1		VARCHAR(20),
	@Apellido2		VARCHAR(20),
	@Telefono		INT,
	@Carne			INT,
	@Universidad	INT,
	@Correo			VARCHAR(35),
	@Contraseña		VARCHAR(10))
AS 
BEGIN
	IF EXISTS (SELECT Correo FROM Usuario WHERE Correo = @Correo)
			RAISERROR('Este correo ya ha sido registrado',1,1)
			RETURN 1
	IF(@Carne != NULL)
			DECLARE @ID_Universidad INT;
			IF NOT EXISTS (SELECT Identificador FROM Universidad WHERE  Nombre = @Universidad)
				RAISERROR('Esta universidad no existe',1,1)
				RETURN 2
			SET @ID_Universidad = (
				SELECT Identificador 
				FROM Universidad 
				WHERE  Identificador = @Universidad);
			INSERT INTO Programa(Carne,ID_Universidad,Millas) VALUES(
			@Carne,			
			@ID_Universidad,
			0)
	INSERT INTO	Usuario(Nombre, Apellido1, Apellido2, Telefono, Carne, Correo, Contraseña) 
		VALUES(
			@Nombre,
			@Apellido1,
			@Apellido2,
			@Telefono,
			@Carne,
			@Correo,
			@Contraseña)
	RETURN 0
END;

CREATE PROCEDURE Insertar_Universidad(
	@Identificador	INT,
	@Nombre			VARCHAR(10))
AS
BEGIN
	INSERT INTO Universidad(Identificador, Nombre) VALUES(
	@Identificador,			
	@Nombre)
END;

CREATE PROCEDURE Insertar_Promocion
AS
BEGIN
	INSERT INTO Promocion(Carne,C_Vuelo,F_Inicio,F_Fin,Porcentaje,Imagen) VALUES(
	'Carne',
	'C_Vuelo',
	'F_Inicio',
	'F_Fin',
	'Porcentaje',
	'Imagen'
	);

END;

CREATE PROCEDURE Insertar_Vuelo
AS
BEGIN
	INSERT INTO Vuelo(Codigo,Estado,Categoria,Costo,F_Salida,Distancia,ID_Aeronave) VALUES(
	'Codigo',
	'Estado',
	'Categoria',
	'Costo',
	'F_Salidad',
	'Distancia',
	'ID_Aeronave'
	);

END;

CREATE PROCEDURE Insertar_Aeronave
AS
BEGIN
	INSERT INTO Aeronave(Identificador, Modelo, Capacidad) VALUES(
	'Identificador',
	'Modelo',
	'Capacidad'
	);

END;

CREATE PROCEDURE Insertar_Escala
AS
BEGIN
	INSERT INTO Escala(C_Vuelo,Salida,Llegada,Millas) VALUES(
	'C_Vuelo',
	'Salida',
	'Llegada',
	'Millas'
	);

END;

CREATE PROCEDURE Insertar_Tiquete
AS
BEGIN
	INSERT INTO Tiquete(C_Reserva,N_Asiento) VALUES(
	'C_Reserva',
	'N_Asiento'
	);

END;

CREATE PROCEDURE Insertar_Reserva
AS
BEGIN
	INSERT INTO Reserva(Codigo,Chequeo,Equipaje,C_Vuelo) VALUES(
	'Codigo',
	'Chequeo',
	'Equipaje',
	'C_Vuelo'
	);

END;

CREATE PROCEDURE Insertar_Reservaciones
AS
BEGIN
	INSERT INTO Reservaciones(C_Reserva,C_Usuario) VALUES(
	'C_Reserva',
	'C_Usuario'
	);

END;