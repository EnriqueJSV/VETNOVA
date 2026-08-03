USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INICIAR_SESION
(
@Nombre_Usuario varchar(100),
@Contrasena varchar(100)
)
AS BEGIN
	BEGIN TRY 
		IF EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena)
		BEGIN

			DECLARE @IdUsuario INT
			SET  @IdUsuario=(SELECT Id_Usuario
			FROM Usuarios 
			WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena)


			SELECT Id_Usuario, Id_Rol
			FROM Usuarios 
			WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena

			-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
			DECLARE @DSC VARCHAR(MAX)
			DECLARE @USRNOM VARCHAR(300)
			DECLARE @ACC CHAR(1)

			SELECT @USRNOM = Email FROM Usuarios Where Id_Usuario=@IdUsuario
			SET @DSC = 'Inicio de Sesión del Usuario: ' + CONVERT(VARCHAR,@USRNOM)
			SET @ACC = 'I'

			INSERT INTO Auditoria
			(
			Id_Usuario, Accion, Descripcion, Fecha
			)
			SELECT
			@IdUsuario, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
			-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
	
END