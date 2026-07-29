USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_USUARIOS
(
@Id_Rol int,
@Nombre_Usuario varchar(100),
@Email varchar(100),
@Contrasena varchar(100),
@Estado char(1),
@IdUsuarioGlobal int
)
AS BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario) 
			BEGIN --SI NO EXISTE, ENTONCES LO INSERTA
		
				INSERT INTO Usuarios
				(
				[Id_Rol], [Nombre_Usuario], [Email], [Contrasena], [Estado]
				)
				VALUES
				(
				@Id_Rol, @Nombre_Usuario, @Email, @Contrasena, @Estado
				)

				SELECT @@IDENTITY

				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
				DECLARE @DSC VARCHAR(MAX)
				DECLARE @USRNOM VARCHAR(300)
				DECLARE @ACC CHAR(1)

				SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
				SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' inserta la información del usuario ' + @Nombre_Usuario
				SET @ACC = 'I'

				INSERT INTO Auditoria
				(
				Id_Usuario, Accion, Descripcion, Fecha
				)
				SELECT
				@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
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
