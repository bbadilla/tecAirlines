--De las tablas ya creadas, se aplica el metodo de eliminar valores a dichas tablas


DELETE Usuario , Reservaciones 
	FROM Usuario
        INNER JOIN
		Reservaciones as r ON r.C_Usuario = Usuario.Correo
	WHERE
		Usuario.Correo = 'Correo del usuario a eliminar';

	--Lo anterior elimina el usuario deseado y las reservaciones asociadas a este.

