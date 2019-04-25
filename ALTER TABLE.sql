ALTER TABLE Usuario
	ADD PRIMARY KEY	(Correo),
		UNIQUE		(Carne);

ALTER TABLE Programa
	ADD FOREIGN KEY (Carne)				REFERENCES	Usuario(Carne),
		PRIMARY KEY	(Carne),
		FOREIGN KEY (ID_Universidad)	REFERENCES	Universidad(Identificador),
		DEFAULT		0					FOR			Millas;

ALTER TABLE Universidad
	ADD PRIMARY KEY	(Identificador);

ALTER TABLE Aeronave
	ADD PRIMARY KEY (Identificador);

ALTER TABLE Vuelo
	ADD PRIMARY KEY	(Codigo),
		FOREIGN KEY (ID_Aeronave)		REFERENCES	Aeronave(Identificador),
		DEFAULT		0					FOR			Estado;

ALTER TABLE Promocion
	ADD FOREIGN KEY (Carne)				REFERENCES	Programa(Carne),
		FOREIGN KEY (C_Vuelo)			REFERENCES	Vuelo(Codigo);

ALTER TABLE Escala
	ADD FOREIGN KEY (C_Vuelo)			REFERENCES	Vuelo(Codigo);

ALTER TABLE Reserva
	ADD	PRIMARY KEY (Codigo),
		FOREIGN KEY (C_Vuelo)			REFERENCES	Vuelo(Codigo);

ALTER TABLE Tiquete
	ADD FOREIGN KEY (C_Reserva)			REFERENCES	Reserva(Codigo);

ALTER TABLE Reservaciones
	ADD FOREIGN KEY (C_Reserva)			REFERENCES	Reserva(Codigo),
		FOREIGN KEY (C_Usuario)			REFERENCES	Usuario(Correo);