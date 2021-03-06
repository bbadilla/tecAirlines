ALTER TABLE Usuario
	ADD PRIMARY KEY	(Correo);

ALTER TABLE Universidad
	ADD PRIMARY KEY	(Identificador);

ALTER TABLE Programa
	ADD FOREIGN KEY (C_Usuario)			REFERENCES	Usuario(Correo),
		FOREIGN KEY (ID_Universidad)	REFERENCES	Universidad(Identificador),
		DEFAULT		0					FOR			Millas;

ALTER TABLE Aeronave
	ADD PRIMARY KEY (Identificador);

ALTER TABLE Vuelo
	ADD PRIMARY KEY	(Codigo),
		FOREIGN KEY (ID_Aeronave)		REFERENCES	Aeronave(Identificador),
		FOREIGN KEY (A_Salida)			REFERENCES	airports(Codigo),
		FOREIGN KEY (A_Llegada)			REFERENCES	airports(Codigo),
		DEFAULT		1					FOR			Estado;

ALTER TABLE Promocion
	ADD FOREIGN KEY (C_Usuario)			REFERENCES	Usuario(Correo),
		FOREIGN KEY (C_Vuelo)			REFERENCES	Vuelo(Codigo);

ALTER TABLE airports
	ADD	PRIMARY KEY (Codigo);

ALTER TABLE Escala
	ADD FOREIGN KEY (C_Vuelo)			REFERENCES	Vuelo(Codigo),
		FOREIGN KEY (A_Salida)			REFERENCES	airports(Codigo),
		FOREIGN KEY (A_Llegada)			REFERENCES	airports(Codigo);

ALTER TABLE Reserva
	ADD	PRIMARY KEY (Codigo),
		FOREIGN KEY (C_Vuelo)			REFERENCES	Vuelo(Codigo),
		FOREIGN KEY (C_Usuario)			REFERENCES	Usuario(Correo),
		DEFAULT		0					FOR			Chequeo,
		DEFAULT		0					FOR			Pago,
		DEFAULT		0					FOR			Equipaje;

ALTER TABLE Tiquete
	ADD FOREIGN KEY (C_Reserva)			REFERENCES	Reserva(Codigo);

ALTER TABLE Pago
	ADD PRIMARY KEY (Numero),
		FOREIGN KEY (C_Reserva)			REFERENCES	Reserva(Codigo);