CREATE PROCEDURE Insertar_Usuario
AS
BEGIN

	INSERT INTO Usuario(Nombre,Apellido1,Apellido2,Telefono,Carne,Correo,Contraseña) VALUES(
	'Nombre',			
	'Apellido1'	,	               --Se cambian 
	'Apellido2'	,				   --estos valores
	'Telefono'	,	               --con datos
	'Carne'		,	               --a agregar
	'Correo'		,	
	'Contraseña'		
	);

END;

CREATE PROCEDURE Insertar_Programa
AS
BEGIN
	INSERT INTO Programa(Carne,ID_Universidad,Millas) VALUES(
	'Carne',			
	'ID_Universidad'	,	       --Se cambian 
	'Millas'					   --estos valores con datos 
								   --a agregar		
	);

END;

CREATE PROCEDURE Insertar_Universidad
AS
BEGIN
	INSERT INTO Universidad(Identificador,Nombre) VALUES(
	'Identificador',			
	'Nombre'	       
	);

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