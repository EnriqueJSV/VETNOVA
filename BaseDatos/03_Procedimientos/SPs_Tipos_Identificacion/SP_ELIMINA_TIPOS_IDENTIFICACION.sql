USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_TIPOS_IDENTIFICACION
(
@Id_Tipo_Identificacion INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Tipos_Identificacion WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Tipo_Identificacion FROM Propietarios WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion) OR EXISTS (SELECT Id_Tipo_Identificacion FROM Veterinarios WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion))
	BEGIN
		DELETE FROM Tipos_Identificacion
		WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Tipo_Identificacion) + ' de Tipos_Identificacion'
		SET @ACC = 'E'

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
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO