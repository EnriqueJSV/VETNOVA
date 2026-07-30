USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_CITAS
(
@Filtro VARCHAR(200)
)
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
	WHERE Motivo LIKE '%' + @Filtro + '%'
END
GO