USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_TIPOS_IDENTIFICACION
AS BEGIN
	SELECT
	Id_Tipo_Identificacion,
	Tipo_Identificacion,
	Estado
	FROM Tipos_Identificacion
END
GO