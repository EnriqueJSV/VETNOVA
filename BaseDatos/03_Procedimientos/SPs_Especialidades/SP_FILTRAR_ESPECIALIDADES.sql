USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_ESPECIALIDADES
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Especialidad,
	Especialidad,
	Estado
	FROM Especialidades
	WHERE Especialidad LIKE '%' + @Filtro + '%'
END
GO