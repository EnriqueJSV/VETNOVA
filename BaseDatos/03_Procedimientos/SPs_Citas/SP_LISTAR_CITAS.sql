USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_CITAS
AS BEGIN
	BEGIN TRY
		SELECT 
			CIT.Id_Cita,
			MASC.Nombre AS Mascota,
			PROP.Nombre + ' ' + PROP.Apellido1 AS Propietario,
			VET.Nombre + ' ' + VET.Apellido1 AS Veterinario,
			CONVERT(VARCHAR(10), CIT.Fecha, 103) AS Fecha,
			CONVERT(VARCHAR(5), CIT.Hora, 108) AS Hora,
			CIT.Motivo AS Motivo,
			CIT.Estado_Cita AS Estado
		FROM Citas CIT
		INNER JOIN Mascotas MASC ON MASC.Id_Mascota = CIT.Id_Mascota
		INNER JOIN Propietarios PROP ON PROP.Id_Propietario = MASC.Id_Propietario
		INNER JOIN Veterinarios VET ON VET.Id_Veterinario = CIT.Id_Veterinario
		ORDER BY CIT.Fecha DESC, CIT.Hora DESC
	END TRY
	BEGIN CATCH
		SELECT CAST(NULL AS INT) AS Id_Cita, CAST(NULL AS VARCHAR(100)) AS Mascota, CAST(NULL AS VARCHAR(200)) AS Propietario,
		       CAST(NULL AS VARCHAR(200)) AS Veterinario, CAST(NULL AS VARCHAR(10)) AS Fecha,
		       CAST(NULL AS VARCHAR(5)) AS Hora, CAST(NULL AS VARCHAR(500)) AS Motivo,
		       CAST(NULL AS VARCHAR(50)) AS Estado
		WHERE 1=0
	END CATCH
END
GO