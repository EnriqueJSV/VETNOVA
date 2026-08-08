USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_VETERINARIOS
AS
BEGIN
    SELECT
        V.Id_Veterinario,
        V.Id_Tipo_Identificacion,
        V.Identificacion,
        V.Nombre,
        V.Apellido1,
        V.Apellido2,
        V.Id_Especialidad,
        E.Especialidad,
        V.Telefono,
        V.Email,
        V.Estado
    FROM Veterinarios V
    INNER JOIN Especialidades E
        ON V.Id_Especialidad = E.Id_Especialidad;
END
GO