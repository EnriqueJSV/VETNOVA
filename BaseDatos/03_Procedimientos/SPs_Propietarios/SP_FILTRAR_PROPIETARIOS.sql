USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_PROPIETARIOS
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Propietario,
	Id_Tipo_Identificacion,
	Nombre,
	Apellido1,
	Apellido2,
	Telefono,
	Email,
	Direccion,
	Estado
	FROM Propietarios
	WHERE Nombre LIKE '%' + @Filtro + '%'
END
GO