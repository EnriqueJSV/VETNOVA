USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_PROPIETARIOS
(
@Id_Propietario INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT (EXISTS (SELECT Id_Propietario FROM Mascotas WHERE Id_Propietario=@Id_Propietario))
	BEGIN
		DELETE FROM Propietarios
		WHERE Id_Propietario=@Id_Propietario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Propietario) + ' de Propietarios'
		SET @ACC = 'E'

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
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO