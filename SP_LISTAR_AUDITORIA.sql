USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_AUDITORIA
AS BEGIN
	BEGIN TRY
		SELECT
			AUD.Id_Auditoria,
			USR.Nombre_Usuario AS Usuario,
			CASE AUD.Accion
				WHEN 'I' THEN 'Insertar'
				WHEN 'A' THEN 'Actualizar'
				WHEN 'E' THEN 'Eliminar'
				WHEN 'L' THEN 'Inicio sesion'
				WHEN 'X' THEN 'Cerrar sesion'
				ELSE AUD.Accion
			END AS Accion,
			AUD.Descripcion AS Detalle,
			CONVERT(VARCHAR(10), AUD.Fecha, 103) + ' ' + CONVERT(VARCHAR(5), AUD.Fecha, 108) AS FechaHora
		FROM Auditoria AUD
		INNER JOIN Usuarios USR ON USR.Id_Usuario = AUD.Id_Usuario
		ORDER BY AUD.Id_Auditoria DESC
	END TRY
	BEGIN CATCH
		SELECT CAST(NULL AS INT) AS Id_Auditoria, CAST(NULL AS VARCHAR(100)) AS Usuario,
		       CAST(NULL AS VARCHAR(50)) AS Accion, CAST(NULL AS VARCHAR(MAX)) AS Detalle,
		       CAST(NULL AS VARCHAR(20)) AS FechaHora
		WHERE 1=0
	END CATCH
END
GO