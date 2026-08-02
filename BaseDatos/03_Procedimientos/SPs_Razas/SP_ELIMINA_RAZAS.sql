USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_RAZAS
(
@Id_Raza INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Razas WHERE Id_Raza=@Id_Raza)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Raza FROM Mascotas WHERE Id_Raza=@Id_Raza))
	BEGIN
		DELETE FROM Razas
		WHERE Id_Raza=@Id_Raza

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Raza) + ' de Razas'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Raza
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