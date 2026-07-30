USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_CONSULTAS
(
@Id_Consulta INT,
@Id_Cita INT,
@Diagnostico VARCHAR(500),
@Tratamiento VARCHAR(500),
@Observaciones VARCHAR(500),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Consulta FROM Consultas WHERE Id_Cita=@Id_Cita AND Id_Consulta<>@Id_Consulta)
	BEGIN
		UPDATE Consultas
		SET Id_Cita=@Id_Cita, Diagnostico=@Diagnostico, Tratamiento=@Tratamiento, Observaciones=@Observaciones
		WHERE Id_Consulta=@Id_Consulta

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Consulta) + ' de Consultas'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Consulta
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