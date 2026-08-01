USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_CITAS
(
@Nombre varchar(100)
)
AS BEGIN
	SELECT CIT.Id_Cita, MASC.Nombre AS Mascota, CIT.Fecha, CIT.Hora, CIT.Motivo, CIT.Estado_Cita
	FROM Mascotas MASC
	INNER JOIN Citas CIT ON CIT.Id_Mascota=MASC.Id_Mascota
	WHERE MASC.Nombre LIKE '%' + @Nombre + '%' 
	ORDER BY CIT.Fecha, CIT.Hora
END
