USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_MASCOTAS
(
@Id_Mascota INT,
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
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Mascotas WHERE Id_Mascota=@Id_Mascota)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	BEGIN
		UPDATE Mascotas
		SET Id_Propietario=@Id_Propietario, Id_Raza=@Id_Raza, Nombre=@Nombre, Sexo=@Sexo, Fecha_Nacimiento=@Fecha_Nacimiento, Peso=@Peso, Color=@Color, Estado=@Estado
		WHERE Id_Mascota=@Id_Mascota

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Mascota) + ' de Mascotas'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Mascota
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO