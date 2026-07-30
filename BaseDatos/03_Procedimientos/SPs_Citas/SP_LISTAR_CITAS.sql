USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_CITAS
AS BEGIN
	SELECT
	Id_Cita,
	Id_Mascota,
	Id_Veterinario,
	Fecha,
	Hora,
	Motivo,
	Estado_Cita
	FROM Citas
END
GO