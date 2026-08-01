USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_CITAS
AS BEGIN
	SELECT CIT.Id_Cita, MASC.Nombre AS Mascota, VET.Nombre AS Veterinario, CIT.Fecha, CIT.Hora, CIT.Motivo, CIT.Estado_Cita
	FROM Citas CIT
	INNER JOIN Mascotas MASC ON MASC.Id_Mascota=CIT.Id_Mascota
	INNER JOIN Veterinarios VET ON VET.Id_Veterinario=CIT.Id_Veterinario
	ORDER BY CIT.Fecha, CIT.Hora
END
