USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_MASCOTAS
AS BEGIN
	SELECT
	Id_Mascota,
	Id_Propietario,
	Id_Raza,
	Nombre,
	Sexo,
	Fecha_Nacimiento,
	Peso,
	Color,
	Estado
	FROM Mascotas
END
GO