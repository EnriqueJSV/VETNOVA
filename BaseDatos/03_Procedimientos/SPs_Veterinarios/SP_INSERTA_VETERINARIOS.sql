USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_VETERINARIOS
(
@Id_Tipo_Identificacion INT,
@Identificacion VARCHAR(50),
@Nombre VARCHAR(100),
@Apellido1 VARCHAR(100),
@Apellido2 VARCHAR(100),
@Id_Especialidad INT,
@Telefono VARCHAR(100),
@Email VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Veterinario FROM Veterinarios WHERE Identificacion=@Identificacion)
	BEGIN
		INSERT INTO Veterinarios
		(
		[Id_Tipo_Identificacion], [Identificacion], [Nombre], [Apellido1], [Apellido2], [Id_Especialidad], [Telefono], [Email], [Estado]
		)
		VALUES
		(
		@Id_Tipo_Identificacion, @Identificacion, @Nombre, @Apellido1, @Apellido2, @Id_Especialidad, @Telefono, @Email, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Veterinarios (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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