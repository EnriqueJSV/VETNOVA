USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_CITAS
(
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
		INSERT INTO Citas
		(
		[Id_Mascota], [Id_Veterinario], [Fecha], [Hora], [Motivo], [Estado_Cita]
		)
		VALUES
		(
		@Id_Mascota, @Id_Veterinario, @Fecha, @Hora, @Motivo, @Estado_Cita
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Citas (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
		SET @ACC = 'I'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO