USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_CITAS
(
@Id_Cita int,
@IdUsuarioGlobal int
)
AS BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT Id_Cita FROM Consultas WHERE Id_Cita=@Id_Cita)
			BEGIN
				DECLARE @NOMBRE VARCHAR(100) 
				SET @NOMBRE = (SELECT Id_Cita FROM Citas WHERE Id_Cita=@Id_Cita)

				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
				DECLARE @DSC VARCHAR(MAX)
				DECLARE @USRNOM VARCHAR(300)
				DECLARE @ACC CHAR(1)

				SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
				SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' elimina la información de la cita con ID ' + @NOMBRE
				SET @ACC = 'E'

				INSERT INTO Auditoria
				(
				Id_Usuario, Accion, Descripcion, Fecha
				)
				SELECT
				@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

				DELETE FROM Citas 
				WHERE Id_Cita=@Id_Cita

				SELECT @Id_Cita
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
