USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_USUARIOS
(
@Nombre_Usuario varchar(100)
)
AS BEGIN
	SELECT USR.Id_Usuario, USR.Id_Rol, ROL.Rol, USR.Nombre_Usuario, USR.Email, USR.Contrasena, USR.Estado
	FROM Usuarios USR
	INNER JOIN Roles ROL ON ROL.Id_Rol=USR.Id_Rol
	WHERE USR.Nombre_Usuario LIKE '%' + @Nombre_Usuario + '%' 
END
