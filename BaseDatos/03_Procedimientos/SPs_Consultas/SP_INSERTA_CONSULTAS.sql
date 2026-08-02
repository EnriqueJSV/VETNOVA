USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_CONSULTAS
(
@Id_Cita INT,
@Diagnostico VARCHAR(500),
@Tratamiento VARCHAR(500),
@Observaciones VARCHAR(500),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Consulta FROM Consultas WHERE Id_Cita=@Id_Cita)
	BEGIN
		INSERT INTO Consultas
		(
		[Id_Cita], [Diagnostico], [Tratamiento], [Observaciones]
		)
		VALUES
		(
		@Id_Cita, @Diagnostico, @Tratamiento, @Observaciones
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Consultas (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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