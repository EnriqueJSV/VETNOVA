USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_VETERINARIOS
AS BEGIN
	SELECT
	Id_Veterinario,
	Id_Tipo_Identificacion,
	Identificacion,
	Nombre,
	Apellido1,
	Apellido2,
	Id_Especialidad,
	Telefono,
	Email,
	Estado
	FROM Veterinarios
END
GO