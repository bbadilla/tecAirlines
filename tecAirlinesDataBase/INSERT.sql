--De las tablas ya creadas, se aplica el metodo de añadir valores a dichas tablas


INSERT INTO Usuario(Nombre,Apellido1,Apellido2,Telefono,Carne,Correo,Contraseña) VALUES(
	'Nombre',			
	'Apellido1'	,	               --Se cambian 
	'Apellido2'	,				   --estos valores
	'Telefono'	,	               --con datos
	'Carne'		,	               --a agregar
	'Correo'		,	
	'Contraseña'		
);

INSERT INTO Programa(Carne,ID_Universidad,Millas) VALUES(
	'Carne',			
	'ID_Universidad'	,	       --Se cambian 
	'Millas'					   --estos valores con datos 
								   --a agregar		
);

INSERT INTO Universidad(Identificador,Nombre) VALUES(
	'Identificador',			
	'Nombre'	       
);

INSERT INTO Promocion(Carne,C_Vuelo,F_Inicio,F_Fin,Porcentaje,Imagen) VALUES(
	'Carne',
	'C_Vuelo',
	'F_Inicio',
	'F_Fin',
	'Porcentaje',
	'Imagen'
);


INSERT INTO Vuelo(Codigo,Estado,Categoria,Costo,F_Salida,Distancia,ID_Aeronave) VALUES(
	'Codigo',
	'Estado',
	'Categoria',
	'Costo',
	'F_Salidad',
	'Distancia',
	'ID_Aeronave'
);


INSERT INTO Aeronave(Identificador,Capacidad) VALUES(
	'Identificador',
	'Modelo',
	'Capacidad'
);

INSERT INTO Escala(C_Vuelo,Salida,Llegada,Millas) VALUES(
	'C_Vuelo',
	'Salida',
	'Llegada',
	'Millas'
);


INSERT INTO Tiquete(C_Reserva,N_Asiento) VALUES(
	'C_Reserva',
	'N_Asiento'
);

INSERT INTO Reserva(Codigo,Chequeo,Equipaje,C_Vuelo) VALUES(
	'Codigo',
	'Chequeo',
	'Equipaje',
	'C_Vuelo'
);

INSERT INTO Reservaciones(C_Reserva,C_Usuario) VALUES(
	'C_Reserva',
	'C_Usuario'
);