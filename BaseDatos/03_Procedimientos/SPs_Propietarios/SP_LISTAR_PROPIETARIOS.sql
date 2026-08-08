SE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_PROPIETARIOS
AS BEGIN
	SELECT
	Id_Propietario,
	Id_Tipo_Identificacion,
	Identificacion,
	Nombre,
	Apellido1,
	Apellido2,
	Telefono,
	Email,
	Direccion,
	Estado
	FROM Propietarios
END
GO