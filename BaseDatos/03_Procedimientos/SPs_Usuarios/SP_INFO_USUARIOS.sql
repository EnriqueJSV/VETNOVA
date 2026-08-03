USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INFO_USUARIOS
(
@Id_Usuario INT
)
AS BEGIN
	SELECT USR.Id_Usuario, USR.Id_Usuario, USR.Nombre_Usuario,  USR.Contrasena, USR.Id_Rol, ROL.Rol
	FROM Usuarios USR
	INNER JOIN Roles ROL ON ROL.Id_Rol=USR.Id_Rol
	WHERE USR.Id_Usuario=@Id_Usuario
END