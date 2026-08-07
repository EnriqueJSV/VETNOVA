USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INICIAR_SESION
(
@Nombre_Usuario varchar(100),
@Contrasena varchar(100)
)
AS BEGIN
	BEGIN TRY

		IF NOT EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena)
		BEGIN
			SELECT -1 /*CREDENCIALES INCORRECTAS*/
			RETURN
		END

		-- Las credenciales son correctas, pero el usuario esta inactivo.
		-- Ajusta 'Estado<>''A''' si tu columna usa otro valor para "inactivo".
		IF EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena AND Estado<>'A')
		BEGIN
			SELECT -3 /*USUARIO INACTIVO*/
			RETURN
		END

		DECLARE @IdUsuario INT
		SET @IdUsuario=(SELECT Id_Usuario
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
		SET @ACC = 'L'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuario, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH

END