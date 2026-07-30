USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_CITAS
(
@Id_Cita INT,
@Id_Mascota INT,
@Id_Veterinario INT,
@Fecha DATE,
@Hora TIME,
@Motivo VARCHAR(500),
@Estado_Cita VARCHAR(50),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	BEGIN
		UPDATE Citas
		SET Id_Mascota=@Id_Mascota, Id_Veterinario=@Id_Veterinario, Fecha=@Fecha, Hora=@Hora, Motivo=@Motivo, Estado_Cita=@Estado_Cita
		WHERE Id_Cita=@Id_Cita

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Cita) + ' de Citas'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Cita
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO