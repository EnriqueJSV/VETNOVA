USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_USUARIOS
(
@Id_Usuario int,
@IdUsuarioGlobal int
)
AS BEGIN
	BEGIN TRY
		-- Validamos primero que el registro exista antes de intentar eliminarlo
		IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Id_Usuario=@Id_Usuario)
		BEGIN
			SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
			RETURN
		END

		IF NOT EXISTS (SELECT Id_Usuario FROM Auditoria WHERE Id_Usuario=@Id_Usuario)
			BEGIN
				DECLARE @NOMBRE VARCHAR(100) 
				SET @NOMBRE = (SELECT Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@Id_Usuario)

				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
				DECLARE @DSC VARCHAR(MAX)
				DECLARE @USRNOM VARCHAR(300)
				DECLARE @ACC CHAR(1)

				SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
				SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' elimina la información del usuario ' + @NOMBRE
				SET @ACC = 'E'

				INSERT INTO Auditoria
				(
				Id_Usuario, Accion, Descripcion, Fecha
				)
				SELECT
				@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

				DELETE FROM Usuarios 
				WHERE Id_Usuario=@Id_Usuario

				SELECT @Id_Usuario
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

GO