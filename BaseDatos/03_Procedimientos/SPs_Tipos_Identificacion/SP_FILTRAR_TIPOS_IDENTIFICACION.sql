USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_TIPOS_IDENTIFICACION
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Tipo_Identificacion,
	Tipo_Identificacion,
	Estado
	FROM Tipos_Identificacion
	WHERE Tipo_Identificacion LIKE '%' + @Filtro + '%'
END
GO
