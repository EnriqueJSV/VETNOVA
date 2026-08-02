USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_ESPECIALIDADES
(
@Id_Especialidad INT,
@Especialidad VARCHAR(50),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Especialidades WHERE Id_Especialidad=@Id_Especialidad)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Especialidad FROM Especialidades WHERE Especialidad=@Especialidad AND Id_Especialidad<>@Id_Especialidad)
	BEGIN
		UPDATE Especialidades
		SET Especialidad=@Especialidad, Estado=@Estado
		WHERE Id_Especialidad=@Id_Especialidad

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Especialidad) + ' de Especialidades'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Especialidad
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