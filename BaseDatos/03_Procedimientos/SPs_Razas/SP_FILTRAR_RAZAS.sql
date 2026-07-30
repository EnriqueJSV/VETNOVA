USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_RAZAS
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Raza,
	Id_Especie,
	Raza,
	Estado
	FROM Razas
	WHERE Raza LIKE '%' + @Filtro + '%'
END
GO