USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_USUARIOS
(
@Id_Usuario int,
@Id_Rol int,
@Nombre_Usuario varchar(100),
@Email varchar(100),
@Contrasena varchar(100),
@Estado char(1),
@IdUsuarioGlobal INT
)
AS BEGIN 

BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Id_Usuario=@Id_Usuario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario and Id_Usuario<>@Id_Usuario) 
	BEGIN 
		UPDATE Usuarios
		SET Id_Rol=@Id_Rol, Nombre_Usuario=@Nombre_Usuario, Email=@Email, Contrasena=@Contrasena, Estado=@Estado
		WHERE Id_Usuario=@Id_Usuario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' actualiza la información del usuario ' + @Nombre_Usuario
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Usuario
	END
	ELSE
	BEGIN 
		SELECT  -1
	END
END TRY
BEGIN CATCH
	SELECT 0
END CATCH

END

GO