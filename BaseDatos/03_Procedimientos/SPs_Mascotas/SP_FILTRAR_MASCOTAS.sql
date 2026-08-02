USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_MASCOTAS
(
@Filtro VARCHAR(200)
)
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
	WHERE Nombre LIKE '%' + @Filtro + '%'
END
GO