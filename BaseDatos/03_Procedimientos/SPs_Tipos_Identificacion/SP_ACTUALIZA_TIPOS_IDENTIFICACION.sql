USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_TIPOS_IDENTIFICACION
(
@Id_Tipo_Identificacion INT,
@Tipo_Identificacion VARCHAR(50),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Tipos_Identificacion WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Tipo_Identificacion FROM Tipos_Identificacion WHERE Tipo_Identificacion=@Tipo_Identificacion AND Id_Tipo_Identificacion<>@Id_Tipo_Identificacion)
	BEGIN
		UPDATE Tipos_Identificacion
		SET Tipo_Identificacion=@Tipo_Identificacion, Estado=@Estado
		WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Tipo_Identificacion) + ' de Tipos_Identificacion'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Tipo_Identificacion
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