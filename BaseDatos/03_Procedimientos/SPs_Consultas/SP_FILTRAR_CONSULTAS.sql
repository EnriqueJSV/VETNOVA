USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_CONSULTAS
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Consulta,
	Id_Cita,
	Diagnostico,
	Tratamiento,
	Observaciones
	FROM Consultas
	WHERE Diagnostico LIKE '%' + @Filtro + '%'
END
GO