USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_PROPIETARIOS
(
@Id_Propietario INT,
@Id_Tipo_Identificacion INT,
@Identificacion VARCHAR(100),
@Nombre VARCHAR(100),
@Apellido1 VARCHAR(100),
@Apellido2 VARCHAR(100),
@Telefono VARCHAR(100),
@Email VARCHAR(100),
@Direccion VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Propietarios WHERE Id_Propietario=@Id_Propietario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Propietario FROM Propietarios WHERE Email=@Email AND Id_Propietario<>@Id_Propietario)
	BEGIN
		UPDATE Propietarios
		SET Id_Tipo_Identificacion=@Id_Tipo_Identificacion, Identificacion=@Identificacion, Nombre=@Nombre, Apellido1=@Apellido1, Apellido2=@Apellido2, Telefono=@Telefono, Email=@Email, Direccion=@Direccion, Estado=@Estado
		WHERE Id_Propietario=@Id_Propietario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Propietario) + ' de Propietarios'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Propietario
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