USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_CONSULTAS
AS BEGIN
	SELECT
	Id_Consulta,
	Id_Cita,
	Diagnostico,
	Tratamiento,
	Observaciones
	FROM Consultas
END
GO