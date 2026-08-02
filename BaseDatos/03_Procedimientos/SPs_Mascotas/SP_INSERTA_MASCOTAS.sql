USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_MASCOTAS
(
@Id_Propietario INT,
@Id_Raza INT,
@Nombre VARCHAR(100),
@Sexo VARCHAR(30),
@Fecha_Nacimiento DATETIME,
@Peso VARCHAR(30),
@Color VARCHAR(30),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	BEGIN
		INSERT INTO Mascotas
		(
		[Id_Propietario], [Id_Raza], [Nombre], [Sexo], [Fecha_Nacimiento], [Peso], [Color], [Estado]
		)
		VALUES
		(
		@Id_Propietario, @Id_Raza, @Nombre, @Sexo, @Fecha_Nacimiento, @Peso, @Color, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Mascotas (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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