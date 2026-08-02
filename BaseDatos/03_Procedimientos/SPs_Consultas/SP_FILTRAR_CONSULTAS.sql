USE VetNova
GO
 
CREATE OR ALTER PROCEDURE SP_FILTRAR_CONSULTAS
(
@Id_Cita INT
)
AS BEGIN
	SELECT
	Id_Consulta,
	Id_Cita,
	Diagnostico,
	Tratamiento,
	Observaciones
	FROM Consultas
	WHERE Id_Cita = @Id_Cita
END
GO