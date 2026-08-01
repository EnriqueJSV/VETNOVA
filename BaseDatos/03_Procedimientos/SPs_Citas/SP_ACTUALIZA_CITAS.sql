USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_CITAS
(
@Id_Cita int,
@Id_Mascota int,
@Id_Veterinario int,
@Fecha date,
@Hora time,
@Motivo varchar(500),
@Estado_Cita varchar(50),
@IdUsuarioGlobal INT
)
AS BEGIN 

BEGIN TRY
	IF NOT EXISTS (SELECT @Id_Cita FROM Citas WHERE Id_Mascota=@Id_Mascota and Id_Veterinario=@Id_Veterinario AND Id_Cita<>@Id_Cita) 
	AND 
	NOT EXISTS (SELECT Id_Cita FROM Citas WHERE Fecha=@Fecha AND Hora=@Hora AND Id_Cita<>@Id_Cita) -- VALIDA SI EXISTE UNA CITA EN LA MISMA FECHA Y HORA
	BEGIN 
		UPDATE Citas
		SET Id_Mascota=@Id_Mascota, Id_Veterinario=@Id_Veterinario, Fecha=@Fecha, Hora=@Hora, Motivo=@Motivo, Estado_Cita=@Estado_Cita
		WHERE Id_Cita=@Id_Cita

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' actualiza la información de la cita con ID ' + @Id_Cita
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Cita
	END
	ELSE
	BEGIN 
		SELECT  -1
	END
END TRY
BEGIN CATCH
	SELECT 0
END CATCH

END
GO
