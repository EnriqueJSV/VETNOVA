USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_ESPECIES
(
@Especie VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Especie FROM Especies WHERE Especie=@Especie)
	BEGIN
		INSERT INTO Especies
		(
		[Especie], [Estado]
		)
		VALUES
		(
		@Especie, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Especies (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
		SET @ACC = 'I'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
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
GO