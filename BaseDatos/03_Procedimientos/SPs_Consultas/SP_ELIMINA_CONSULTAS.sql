USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_CONSULTAS
(
@Id_Consulta INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	DELETE FROM Consultas
	WHERE Id_Consulta=@Id_Consulta

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Consulta) + ' de Consultas'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

	SELECT @Id_Consulta
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO