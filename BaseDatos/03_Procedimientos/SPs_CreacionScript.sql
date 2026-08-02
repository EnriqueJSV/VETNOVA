/*
  VETNOVA - SCRIPT 2 DE 4: PROCEDIMIENTOS ALMACENADOS
  ------------------------------------------------------------
  Instrucciones:
  1) Ejecutar PRIMERO el script "BD&Tablas_CreacionScript.sql"
  2) Luego abrir este archivo en SSMS y presionar F5 (Ejecutar)
  3) Al terminar, todos los procedimientos almacenados quedan creados

  Incluye los procedimientos de: Usuarios, Tipos_Identificacion,
  Especialidades, Especies, Razas, Propietarios, Veterinarios,
  Mascotas, Citas y Consultas.

  ------------------------------------------------------------
  NOTA DE VALIDACION (agregada):
  Todos los SP_ACTUALIZA_X y SP_ELIMINA_X ahora validan PRIMERO
  que el registro (@Id_X) exista antes de intentar el UPDATE/DELETE
  y antes de escribir en Auditoria. Si no existe, se corta la
  ejecucion con RETURN y se devuelve el codigo -2, sin tocar la
  tabla de auditoria.

  Codigos de retorno estandar:
    > 0  -> Exito (Id del registro afectado)
    -1   -> No se puede completar: nombre duplicado o registros dependientes
    -2   -> No se puede completar: el registro no existe
     0   -> Error de ejecucion (CATCH)
  ------------------------------------------------------------
*/

-- ===============================================================
-- MODULO: USUARIOS
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INICIAR_SESION
(
@Nombre_Usuario varchar(100),
@Contrasena varchar(100)
)
AS BEGIN
	BEGIN TRY 
		IF EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena)
		BEGIN

			DECLARE @IdUsuario INT
			SET  @IdUsuario=(SELECT Id_Usuario
			FROM Usuarios 
			WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena)


			SELECT Id_Usuario
			FROM Usuarios 
			WHERE Nombre_Usuario=@Nombre_Usuario AND Contrasena=@Contrasena

			-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
			DECLARE @DSC VARCHAR(MAX)
			DECLARE @USRNOM VARCHAR(300)
			DECLARE @ACC CHAR(1)

			SELECT @USRNOM = Email FROM Usuarios Where Id_Usuario=@IdUsuario
			SET @DSC = 'Inicio de Sesión del Usuario: ' + CONVERT(VARCHAR,@USRNOM)
			SET @ACC = 'I'

			INSERT INTO Auditoria
			(
			Id_Usuario, Accion, Descripcion, Fecha
			)
			SELECT
			@IdUsuario, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
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

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INFO_USUARIOS
(
@Id_Usuario INT
)
AS BEGIN
	SELECT USR.Id_Usuario, USR.Id_Usuario, USR.Email,  USR.Contrasena, USR.Id_Rol, ROL.Rol
	FROM Usuarios USR
	INNER JOIN Roles ROL ON ROL.Id_Rol=USR.Id_Rol
	WHERE USR.Id_Usuario=@Id_Usuario
END
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_USUARIOS
AS BEGIN
	SELECT USR.Id_Usuario, USR.Id_Rol, ROL.Rol, USR.Nombre_Usuario, USR.Email, USR.Contrasena, USR.Estado
	FROM Usuarios USR
	INNER JOIN Roles ROL ON ROL.Id_Rol=USR.Id_Rol
END

GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_USUARIOS
(
@Nombre_Usuario varchar(100)
)
AS BEGIN
	SELECT USR.Id_Usuario, USR.Id_Rol, ROL.Rol, USR.Nombre_Usuario, USR.Email, USR.Contrasena, USR.Estado
	FROM Usuarios USR
	INNER JOIN Roles ROL ON ROL.Id_Rol=USR.Id_Rol
	WHERE USR.Nombre_Usuario LIKE '%' + @Nombre_Usuario + '%' 
END

GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_USUARIOS
(
@Id_Rol int,
@Nombre_Usuario varchar(100),
@Email varchar(100),
@Contrasena varchar(100),
@Estado char(1),
@IdUsuarioGlobal int
)
AS BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario) 
			BEGIN --SI NO EXISTE, ENTONCES LO INSERTA
		
				INSERT INTO Usuarios
				(
				[Id_Rol], [Nombre_Usuario], [Email], [Contrasena], [Estado]
				)
				VALUES
				(
				@Id_Rol, @Nombre_Usuario, @Email, @Contrasena, @Estado
				)

				SELECT @@IDENTITY

				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
				DECLARE @DSC VARCHAR(MAX)
				DECLARE @USRNOM VARCHAR(300)
				DECLARE @ACC CHAR(1)

				SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
				SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' inserta la información del usuario ' + @Nombre_Usuario
				SET @ACC = 'I'

				INSERT INTO Auditoria
				(
				Id_Usuario, Accion, Descripcion, Fecha
				)
				SELECT
				@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
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

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_USUARIOS
(
@Id_Usuario int,
@Id_Rol int,
@Nombre_Usuario varchar(100),
@Email varchar(100),
@Contrasena varchar(100),
@Estado char(1),
@IdUsuarioGlobal INT
)
AS BEGIN 

BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Id_Usuario=@Id_Usuario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario and Id_Usuario<>@Id_Usuario) 
	BEGIN 
		UPDATE Usuarios
		SET Id_Rol=@Id_Rol, Nombre_Usuario=@Nombre_Usuario, Email=@Email, Contrasena=@Contrasena, Estado=@Estado
		WHERE Id_Usuario=@Id_Usuario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' actualiza la información del usuario ' + @Nombre_Usuario
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Usuario
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

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_USUARIOS
(
@Id_Usuario int,
@IdUsuarioGlobal int
)
AS BEGIN
	BEGIN TRY
		-- Validamos primero que el registro exista antes de intentar eliminarlo
		IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Id_Usuario=@Id_Usuario)
		BEGIN
			SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
			RETURN
		END

		IF NOT EXISTS (SELECT Id_Usuario FROM Auditoria WHERE Id_Usuario=@Id_Usuario)
			BEGIN
				DECLARE @NOMBRE VARCHAR(100) 
				SET @NOMBRE = (SELECT Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@Id_Usuario)

				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
				DECLARE @DSC VARCHAR(MAX)
				DECLARE @USRNOM VARCHAR(300)
				DECLARE @ACC CHAR(1)

				SELECT @USRNOM = Nombre_Usuario FROM Usuarios Where Id_Usuario=@IdUsuarioGlobal
				SET @DSC = 'El Usuario: ' + CONVERT(VARCHAR,@USRNOM) + ' elimina la información del usuario ' + @NOMBRE
				SET @ACC = 'E'

				INSERT INTO Auditoria
				(
				Id_Usuario, Accion, Descripcion, Fecha
				)
				SELECT
				@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

				DELETE FROM Usuarios 
				WHERE Id_Usuario=@Id_Usuario

				SELECT @Id_Usuario
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

-- ===============================================================
-- MODULO: TIPOS_IDENTIFICACION
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_TIPOS_IDENTIFICACION
AS BEGIN
	SELECT
	Id_Tipo_Identificacion,
	Tipo_Identificacion,
	Estado
	FROM Tipos_Identificacion
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_TIPOS_IDENTIFICACION
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Tipo_Identificacion,
	Tipo_Identificacion,
	Estado
	FROM Tipos_Identificacion
	WHERE Tipo_Identificacion LIKE '%' + @Filtro + '%'
END
GO

GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_TIPOS_IDENTIFICACION
(
@Tipo_Identificacion VARCHAR(50),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Tipo_Identificacion FROM Tipos_Identificacion WHERE Tipo_Identificacion=@Tipo_Identificacion)
	BEGIN
		INSERT INTO Tipos_Identificacion
		(
		[Tipo_Identificacion], [Estado]
		)
		VALUES
		(
		@Tipo_Identificacion, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Tipos_Identificacion (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_TIPOS_IDENTIFICACION
(
@Id_Tipo_Identificacion INT,
@Tipo_Identificacion VARCHAR(50),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Tipos_Identificacion WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Tipo_Identificacion FROM Tipos_Identificacion WHERE Tipo_Identificacion=@Tipo_Identificacion AND Id_Tipo_Identificacion<>@Id_Tipo_Identificacion)
	BEGIN
		UPDATE Tipos_Identificacion
		SET Tipo_Identificacion=@Tipo_Identificacion, Estado=@Estado
		WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Tipo_Identificacion) + ' de Tipos_Identificacion'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Tipo_Identificacion
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

GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_TIPOS_IDENTIFICACION
(
@Id_Tipo_Identificacion INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Tipos_Identificacion WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Tipo_Identificacion FROM Propietarios WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion) OR EXISTS (SELECT Id_Tipo_Identificacion FROM Veterinarios WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion))
	BEGIN
		DELETE FROM Tipos_Identificacion
		WHERE Id_Tipo_Identificacion=@Id_Tipo_Identificacion

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Tipo_Identificacion) + ' de Tipos_Identificacion'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Tipo_Identificacion
	END
	ELSE
	BEGIN
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO

-- ===============================================================
-- MODULO: ESPECIALIDADES
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_ESPECIALIDADES
AS BEGIN
	SELECT
	Id_Especialidad,
	Especialidad,
	Estado
	FROM Especialidades
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_ESPECIALIDADES
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Especialidad,
	Especialidad,
	Estado
	FROM Especialidades
	WHERE Especialidad LIKE '%' + @Filtro + '%'
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_ESPECIALIDADES
(
@Especialidad VARCHAR(50),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Especialidad FROM Especialidades WHERE Especialidad=@Especialidad)
	BEGIN
		INSERT INTO Especialidades
		(
		[Especialidad], [Estado]
		)
		VALUES
		(
		@Especialidad, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Especialidades (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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
GO

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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_ESPECIALIDADES
(
@Id_Especialidad INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Especialidades WHERE Id_Especialidad=@Id_Especialidad)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Especialidad FROM Veterinarios WHERE Id_Especialidad=@Id_Especialidad))
	BEGIN
		DELETE FROM Especialidades
		WHERE Id_Especialidad=@Id_Especialidad

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Especialidad) + ' de Especialidades'
		SET @ACC = 'E'

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
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO

-- ===============================================================
-- MODULO: ESPECIES
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_ESPECIES
AS BEGIN
	SELECT
	Id_Especie,
	Especie,
	Estado
	FROM Especies
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_ESPECIES
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Especie,
	Especie,
	Estado
	FROM Especies
	WHERE Especie LIKE '%' + @Filtro + '%'
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_ESPECIES
(
@Especie VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Especie FROM Especies WHERE Especie=@Especie)
	BEGIN
		INSERT INTO Especies
		(
		[Especie], [Estado]
		)
		VALUES
		(
		@Especie, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Especies (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_ESPECIES
(
@Id_Especie INT,
@Especie VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Especies WHERE Id_Especie=@Id_Especie)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Especie FROM Especies WHERE Especie=@Especie AND Id_Especie<>@Id_Especie)
	BEGIN
		UPDATE Especies
		SET Especie=@Especie, Estado=@Estado
		WHERE Id_Especie=@Id_Especie

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Especie) + ' de Especies'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Especie
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_ESPECIES
(
@Id_Especie INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Especies WHERE Id_Especie=@Id_Especie)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Especie FROM Razas WHERE Id_Especie=@Id_Especie))
	BEGIN
		DELETE FROM Especies
		WHERE Id_Especie=@Id_Especie

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Especie) + ' de Especies'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Especie
	END
	ELSE
	BEGIN
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO

-- ===============================================================
-- MODULO: RAZAS
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_RAZAS
AS BEGIN
	SELECT
	Id_Raza,
	Id_Especie,
	Raza,
	Estado
	FROM Razas
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_RAZAS
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Raza,
	Id_Especie,
	Raza,
	Estado
	FROM Razas
	WHERE Raza LIKE '%' + @Filtro + '%'
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_RAZAS
(
@Id_Especie INT,
@Raza VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Raza FROM Razas WHERE Raza=@Raza AND Id_Especie=@Id_Especie)
	BEGIN
		INSERT INTO Razas
		(
		[Id_Especie], [Raza], [Estado]
		)
		VALUES
		(
		@Id_Especie, @Raza, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Razas (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_RAZAS
(
@Id_Raza INT,
@Id_Especie INT,
@Raza VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Razas WHERE Id_Raza=@Id_Raza)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Raza FROM Razas WHERE Raza=@Raza AND Id_Especie=@Id_Especie AND Id_Raza<>@Id_Raza)
	BEGIN
		UPDATE Razas
		SET Id_Especie=@Id_Especie, Raza=@Raza, Estado=@Estado
		WHERE Id_Raza=@Id_Raza

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Raza) + ' de Razas'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Raza
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_RAZAS
(
@Id_Raza INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Razas WHERE Id_Raza=@Id_Raza)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Raza FROM Mascotas WHERE Id_Raza=@Id_Raza))
	BEGIN
		DELETE FROM Razas
		WHERE Id_Raza=@Id_Raza

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Raza) + ' de Razas'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Raza
	END
	ELSE
	BEGIN
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO

-- ===============================================================
-- MODULO: PROPIETARIOS
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_PROPIETARIOS
AS BEGIN
	SELECT
	Id_Propietario,
	Id_Tipo_Identificacion,
	Nombre,
	Apellido1,
	Apellido2,
	Telefono,
	Email,
	Direccion,
	Estado
	FROM Propietarios
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_PROPIETARIOS
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Propietario,
	Id_Tipo_Identificacion,
	Nombre,
	Apellido1,
	Apellido2,
	Telefono,
	Email,
	Direccion,
	Estado
	FROM Propietarios
	WHERE Nombre LIKE '%' + @Filtro + '%'
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_INSERTA_PROPIETARIOS
(
@Id_Tipo_Identificacion INT,
@Nombre VARCHAR(100),
@Apellido1 VARCHAR(100),
@Apellido2 VARCHAR(100),
@Telefono VARCHAR(100),
@Email VARCHAR(100),
@Direccion VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT Id_Propietario FROM Propietarios WHERE Email=@Email)
	BEGIN
		INSERT INTO Propietarios
		(
		[Id_Tipo_Identificacion], [Nombre], [Apellido1], [Apellido2], [Telefono], [Email], [Direccion], [Estado]
		)
		VALUES
		(
		@Id_Tipo_Identificacion, @Nombre, @Apellido1, @Apellido2, @Telefono, @Email, @Direccion, @Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se inserta un nuevo registro en Propietarios (Id: ' + CONVERT(VARCHAR,@@IDENTITY) + ')'
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_PROPIETARIOS
(
@Id_Propietario INT,
@Id_Tipo_Identificacion INT,
@Nombre VARCHAR(100),
@Apellido1 VARCHAR(100),
@Apellido2 VARCHAR(100),
@Telefono VARCHAR(100),
@Email VARCHAR(100),
@Direccion VARCHAR(100),
@Estado CHAR(1),
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Propietarios WHERE Id_Propietario=@Id_Propietario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Propietario FROM Propietarios WHERE Email=@Email AND Id_Propietario<>@Id_Propietario)
	BEGIN
		UPDATE Propietarios
		SET Id_Tipo_Identificacion=@Id_Tipo_Identificacion, Nombre=@Nombre, Apellido1=@Apellido1, Apellido2=@Apellido2, Telefono=@Telefono, Email=@Email, Direccion=@Direccion, Estado=@Estado
		WHERE Id_Propietario=@Id_Propietario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Propietario) + ' de Propietarios'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Propietario
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_PROPIETARIOS
(
@Id_Propietario INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Propietarios WHERE Id_Propietario=@Id_Propietario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Propietario FROM Mascotas WHERE Id_Propietario=@Id_Propietario))
	BEGIN
		DELETE FROM Propietarios
		WHERE Id_Propietario=@Id_Propietario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Propietario) + ' de Propietarios'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Propietario
	END
	ELSE
	BEGIN
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO

-- ===============================================================
-- MODULO: VETERINARIOS
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_VETERINARIOS
AS BEGIN
	SELECT
	Id_Veterinario,
	Id_Tipo_Identificacion,
	Identificacion,
	Nombre,
	Apellido1,
	Apellido2,
	Id_Especialidad,
	Telefono,
	Email,
	Estado
	FROM Veterinarios
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_VETERINARIOS
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Veterinario,
	Id_Tipo_Identificacion,
	Identificacion,
	Nombre,
	Apellido1,
	Apellido2,
	Id_Especialidad,
	Telefono,
	Email,
	Estado
	FROM Veterinarios
	WHERE Nombre LIKE '%' + @Filtro + '%'
END
GO
GO

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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_VETERINARIOS
(
@Id_Veterinario INT,
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
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Veterinarios WHERE Id_Veterinario=@Id_Veterinario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT EXISTS (SELECT Id_Veterinario FROM Veterinarios WHERE Identificacion=@Identificacion AND Id_Veterinario<>@Id_Veterinario)
	BEGIN
		UPDATE Veterinarios
		SET Id_Tipo_Identificacion=@Id_Tipo_Identificacion, Identificacion=@Identificacion, Nombre=@Nombre, Apellido1=@Apellido1, Apellido2=@Apellido2, Id_Especialidad=@Id_Especialidad, Telefono=@Telefono, Email=@Email, Estado=@Estado
		WHERE Id_Veterinario=@Id_Veterinario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se actualiza el registro Id: ' + CONVERT(VARCHAR,@Id_Veterinario) + ' de Veterinarios'
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Veterinario
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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_VETERINARIOS
(
@Id_Veterinario INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Veterinarios WHERE Id_Veterinario=@Id_Veterinario)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Veterinario FROM Citas WHERE Id_Veterinario=@Id_Veterinario))
	BEGIN
		DELETE FROM Veterinarios
		WHERE Id_Veterinario=@Id_Veterinario

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Veterinario) + ' de Veterinarios'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Veterinario
	END
	ELSE
	BEGIN
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO

-- ===============================================================
-- MODULO: MASCOTAS
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_MASCOTAS
AS BEGIN
	SELECT
	Id_Mascota,
	Id_Propietario,
	Id_Raza,
	Nombre,
	Sexo,
	Fecha_Nacimiento,
	Peso,
	Color,
	Estado
	FROM Mascotas
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_MASCOTAS
(
@Filtro VARCHAR(200)
)
AS BEGIN
	SELECT
	Id_Mascota,
	Id_Propietario,
	Id_Raza,
	Nombre,
	Sexo,
	Fecha_Nacimiento,
	Peso,
	Color,
	Estado
	FROM Mascotas
	WHERE Nombre LIKE '%' + @Filtro + '%'
END
GO
GO

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
GO

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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_MASCOTAS
(
@Id_Mascota INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Mascotas WHERE Id_Mascota=@Id_Mascota)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Mascota FROM Citas WHERE Id_Mascota=@Id_Mascota))
	BEGIN
		DELETE FROM Mascotas
		WHERE Id_Mascota=@Id_Mascota

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Mascota) + ' de Mascotas'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Mascota
	END
	ELSE
	BEGIN
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO

-- ===============================================================
-- MODULO: CITAS
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_CITAS
AS BEGIN
	SELECT
	Id_Cita,
	Id_Mascota,
	Id_Veterinario,
	Fecha,
	Hora,
	Motivo,
	Estado_Cita
	FROM Citas
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_CITAS
(
@Nombre varchar(100)
)
AS BEGIN
	SELECT CIT.Id_Cita, MASC.Nombre AS Mascota, VET.Nombre AS Veterinario, CIT.Fecha, CIT.Hora, CIT.Motivo, CIT.Estado_Cita
	FROM Citas CIT
	INNER JOIN Mascotas MASC ON MASC.Id_Mascota=CIT.Id_Mascota
	INNER JOIN Veterinarios VET ON VET.Id_Veterinario=CIT.Id_Veterinario
	WHERE MASC.Nombre LIKE '%' + @Nombre + '%' 
	ORDER BY CIT.Fecha, CIT.Hora
END
GO

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
GO

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
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Citas WHERE Id_Cita=@Id_Cita)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_CITAS
(
@Id_Cita INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Citas WHERE Id_Cita=@Id_Cita)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	IF NOT (EXISTS (SELECT Id_Cita FROM Consultas WHERE Id_Cita=@Id_Cita))
	BEGIN
		DELETE FROM Citas
		WHERE Id_Cita=@Id_Cita

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Cita) + ' de Citas'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @Id_Cita
	END
	ELSE
	BEGIN
		SELECT -1 /*NO SE PUEDE ELIMINAR: TIENE REGISTROS DEPENDIENTES*/
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO

GO

-- ===============================================================
-- MODULO: CONSULTAS
-- ===============================================================

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_LISTAR_CONSULTAS
AS BEGIN
	SELECT
	Id_Consulta,
	Id_Cita,
	Diagnostico,
	Tratamiento,
	Observaciones
	FROM Consultas
END
GO
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_FILTRAR_CONSULTAS
(
@Id_Cita INT
)
AS BEGIN
	SELECT
	Id_Consulta,
	Id_Cita,
	Diagnostico,
	Tratamiento,
	Observaciones
	FROM Consultas
	WHERE Id_Cita = @Id_Cita
END
GO

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
GO

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
	-- Validamos primero que el registro exista antes de intentar actualizarlo
	IF NOT EXISTS (SELECT 1 FROM Consultas WHERE Id_Consulta=@Id_Consulta)
	BEGIN
		SELECT -2 /*NO SE PUEDE ACTUALIZAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

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
GO

USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_CONSULTAS
(
@Id_Consulta INT,
@IdUsuarioGlobal INT
)
AS BEGIN
	BEGIN TRY
	-- Validamos primero que el registro exista antes de intentar borrarlo
	IF NOT EXISTS (SELECT 1 FROM Consultas WHERE Id_Consulta=@Id_Consulta)
	BEGIN
		SELECT -2 /*NO SE PUEDE ELIMINAR: EL REGISTRO NO EXISTE*/
		RETURN
	END

	DELETE FROM Consultas
	WHERE Id_Consulta=@Id_Consulta

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @USRNOM VARCHAR(300)
		DECLARE @ACC CHAR(1)

		SELECT @USRNOM = Nombre_Usuario FROM Usuarios WHERE Id_Usuario=@IdUsuarioGlobal
		SET @DSC = 'Se elimina el registro Id: ' + CONVERT(VARCHAR,@Id_Consulta) + ' de Consultas'
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripcion, Fecha
		)
		SELECT
		@IdUsuarioGlobal, @ACC, RTRIM(LTRIM(@DSC)), GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

	SELECT @Id_Consulta
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
GO