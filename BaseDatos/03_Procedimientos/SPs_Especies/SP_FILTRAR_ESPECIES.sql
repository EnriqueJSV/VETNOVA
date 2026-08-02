USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_ESPECIES
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Especie,
	Especie,
	Estado
	FROM Especies
	WHERE Especie LIKE '%' + @Filtro + '%'
END
GO