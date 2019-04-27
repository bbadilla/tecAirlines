CREATE TABLE Usuario(
	Nombre			VARCHAR(20)		NOT NULL,
	Apellido1		VARCHAR(20)		NOT NULL,
	Apellido2		VARCHAR(20)		NOT NULL,
	Telefono		INT				NOT NULL,
	Carne			INT,
	Universidad		INT,
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
	Costo			INT				NOT NULL,
	F_Salida		DATETIME2,
	F_Llegada		DATETIME2,
	Millas			INT				NOT NULL,
	ID_Aeronave		INT				NOT NULL,	--ID del avion que realizara el vuelo
	A_Economicos	INT				NOT NULL,
	A_Ejecutivos	INT				NOT NULL
);
CREATE TABLE Aeronave(
	Identificador	INT				NOT NULL,
	Modelo			VARCHAR(10)		NOT NULL,
	Capacidad		INT				NOT NULL,
	--Falta incluir el "mapa" del avion pero no se como lo vamos a guardar, por lo que no se que tipo ponerle
);	
CREATE TABLE Escala(
	C_Vuelo			CHAR(7)			NOT NULL,	--Codigo del vuelo al que se asocia la escala
	A_Salida		VARCHAR(3)		NOT NULL,
	A_Llegada		VARCHAR(3)		NOT NULL,
	F_Salida		DATETIME2		NOT NULL,	
	F_Llegada		DATETIME2		NOT NULL,
);
CREATE TABLE airports(
	Nombre			VARCHAR(100),
	Codigo			VARCHAR(3)		NOT NULL,
	C_Estado		VARCHAR(3),
	C_Pais			VARCHAR(2)		NOT NULL,
	N_Pais			VARCHAR(50)		NOT NULL
);
CREATE TABLE Tiquete(
	C_Reserva		INT				NOT NULL,	--Codigo de reserva asociada al tiquete
	Categoria		INT				NOT NULL,
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
CREATE TABLE Tarjeta(
	Numero			INT				NOT NULL,
	Contraseña		INT				NOT NULL,
	Expiracion		DATE			NOT NULL,
	Titular			VARCHAR(40)		NOT NULL,
	C_Reserva		INT				NOT NULL
);