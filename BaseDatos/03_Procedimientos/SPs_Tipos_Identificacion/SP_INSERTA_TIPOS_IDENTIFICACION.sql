USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_TIPOS_IDENTIFICACION
(
@Tipo_Identificacion VARCHAR(50),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Tipo_Identificacion FROM Tipos_Identificacion WHERE Tipo_Identificacion=@Tipo_Identificacion)
	BEGIN
		INSERT INTO Tipos_Identificacion
		(
		[Tipo_Identificacion], [Estado]
		)
		VALUES
		(
		@Tipo_Identificacion, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Tipos_Identificacion (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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