USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_VETERINARIOS
(
@Filtro VARCHAR(200)
)
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
	WHERE Nombre LIKE '%' + @Filtro + '%'
END
GO