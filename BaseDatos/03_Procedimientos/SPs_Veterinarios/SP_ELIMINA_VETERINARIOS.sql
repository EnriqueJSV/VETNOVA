USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_VETERINARIOS
(
@Id_Veterinario INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Veterinarios WHERE Id_Veterinario=@Id_Veterinario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Veterinario FROM Citas WHERE Id_Veterinario=@Id_Veterinario))
	BEGIN
		DELETE FROM Veterinarios
		WHERE Id_Veterinario=@Id_Veterinario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Veterinario) + ' de Veterinarios'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Veterinario
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