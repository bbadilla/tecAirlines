CREATE TABLE Usuario(
	Nombre			VARCHAR(20),
	Apellido1		VARCHAR(20),
	Apellido2		VARCHAR(20),
	Telefono		INT				NOT NULL,
	Carne			INT,
	Correo			VARCHAR(35)		NOT NULL,
	Contraseña		VARCHAR(10)		NOT NULL
);
CREATE TABLE Programa(
	Carne			INT				NOT NULL,
	ID_Universidad	INT				NOT NULL,	--ID de la universidad donde esta matriculado
	Millas			INT
);
CREATE TABLE Universidad(
	Identificador	INT				NOT NULL,
	Nombre			VARCHAR(10)		NOT NULL	
);
CREATE TABLE Promocion(
	Carne			INT				NOT NULL,
	C_Vuelo			CHAR(7)			NOT NULL,	--Codigo del vuelo
	F_Inicio		TIME			NOT NULL,	--Fecha de inicio del vuelo
	F_Fin			TIME			NOT NULL,	--Fecha de finalizacion del vuelo
	Porcentaje		INT				NOT NULL,
	Imagen			VARCHAR(50)		NOT NULL
);
CREATE TABLE Vuelo(
	Codigo			CHAR(7)			NOT NULL,	
	Estado			BIT,
	Categoria		INT				NOT NULL,
	Costo			INT				NOT NULL,
	F_Salida		TIME			NOT NULL,
	F_Llegada		TIME			NOT NULL,
	Distancia		INT				NOT NULL,  
	ID_Aeronave		INT				NOT NULL	--ID del avion que realizara el vuelo
);
CREATE TABLE Aeronave(
	Identificador	INT				NOT NULL,
	Modelo			VARCHAR(10)		NOT NULL,
	Capacidad		INT				NOT NULL,
);	--Falta incluir el "mapa" del avion pero no se como lo vamos a guardar, por lo que no se que tipo ponerle
CREATE TABLE Escala(
	C_Vuelo			CHAR(7)			NOT NULL,	--Codigo del vuelo al que se asocia la escala
	Salida			VARCHAR(3)		NOT NULL,
	Llegada			VARCHAR(3)		NOT NULL,
	Millas			INT				NOT NULL
);
CREATE TABLE Tiquete(
	C_Reserva		INT				NOT NULL,	--Codigo de reserva asociada al tiquete
	N_Asiento		INT				NOT NULL
);
CREATE TABLE Reserva(
	Codigo			INT				NOT NULL,
	Chequeo			BIT				NOT NULL,
	Equipaje		INT				NOT NULL,
	C_Vuelo			CHAR(7)			NOT NULL	--Codigo del vuelo al que se asocia la escala
);
CREATE TABLE Reservaciones(
	C_Reserva		INT				NOT NULL,	--Codigo de reserva asociada al cliente
	C_Usuario		VARCHAR(35)		NOT NULL	--Correo del cliente que hizo la reserva
);