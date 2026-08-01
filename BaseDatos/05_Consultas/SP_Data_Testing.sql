/*
  VETNOVA - SCRIPT 4 DE 4: PRUEBAS DE SP_LISTAR / SP_FILTRAR / SP_ACTUALIZA / SP_ELIMINA
  ---------------------------------------------------------------------------------------
  Este script NO prueba los SP_INSERTA_X (esos ya se probaron en el script 3).
  Para cada tabla, el patron es:
    1) Se crea un registro de PRUEBA propio (INSERT directo, para no depender
       del SP_INSERTA que ya sabemos que funciona)
    2) Se llama SP_LISTAR_X (solo para confirmar que no truena)
    3) Se llama SP_FILTRAR_X buscando ese registro de prueba
    4) Se llama SP_ACTUALIZA_X sobre el registro de prueba
    5) Se hace un SELECT para mostrar como quedo despues del UPDATE
    6) Se llama SP_ELIMINA_X sobre el registro de prueba
    7) Se hace un SELECT para confirmar que ya no existe

  Los registros de prueba estan aislados: no tocan tus datos reales del
  script 3 (Propietarios, Mascotas, Citas, etc. de la demo se quedan intactos).

  IMPORTANTE: Roles y Auditoria NO se prueban aqui porque todavia no existen
  sus procedimientos (SP_LISTAR_ROLES y SP_FILTRAR_AUDITORIA estan pendientes).

  Requiere: haber corrido ya los scripts 01, 02 y 03 (o al menos 01 y 02).
*/

USE VetNova
GO

-- ============================================================
-- PRUEBA: TIPOS_IDENTIFICACION
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: TIPOS_IDENTIFICACION'
PRINT '=============================================='

PRINT '-> Creando registro de prueba...'
INSERT INTO Tipos_Identificacion (Tipo_Identificacion, Estado) VALUES ('TEST_TipoIdentificacion', 'A')
DECLARE @Id_Test_TIPOS_IDENTIFICACION INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_TIPOS_IDENTIFICACION...'
EXEC SP_LISTAR_TIPOS_IDENTIFICACION

PRINT '-> Ejecutando SP_FILTRAR_TIPOS_IDENTIFICACION (buscando "TEST")...'
EXEC SP_FILTRAR_TIPOS_IDENTIFICACION @Filtro='TEST'

PRINT '-> Ejecutando SP_ACTUALIZA_TIPOS_IDENTIFICACION...'
EXEC SP_ACTUALIZA_TIPOS_IDENTIFICACION @Id_Tipo_Identificacion=@Id_Test_TIPOS_IDENTIFICACION, @Tipo_Identificacion='TEST_TipoIdentificacion_MOD', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Tipo_Identificacion, Tipo_Identificacion, Estado FROM Tipos_Identificacion WHERE Id_Tipo_Identificacion=@Id_Test_TIPOS_IDENTIFICACION

PRINT '-> Ejecutando SP_ELIMINA_TIPOS_IDENTIFICACION...'
EXEC SP_ELIMINA_TIPOS_IDENTIFICACION @Id_Tipo_Identificacion=@Id_Test_TIPOS_IDENTIFICACION, @IdUsuarioGlobal=1

PRINT '-> Verificando que el registro ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Tipos_Identificacion WHERE Id_Tipo_Identificacion=@Id_Test_TIPOS_IDENTIFICACION
GO

-- ============================================================
-- PRUEBA: ESPECIALIDADES
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: ESPECIALIDADES'
PRINT '=============================================='

PRINT '-> Creando registro de prueba...'
INSERT INTO Especialidades (Especialidad, Estado) VALUES ('TEST_Especialidad', 'A')
DECLARE @Id_Test_ESPECIALIDADES INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_ESPECIALIDADES...'
EXEC SP_LISTAR_ESPECIALIDADES

PRINT '-> Ejecutando SP_FILTRAR_ESPECIALIDADES (buscando "TEST")...'
EXEC SP_FILTRAR_ESPECIALIDADES @Filtro='TEST'

PRINT '-> Ejecutando SP_ACTUALIZA_ESPECIALIDADES...'
EXEC SP_ACTUALIZA_ESPECIALIDADES @Id_Especialidad=@Id_Test_ESPECIALIDADES, @Especialidad='TEST_Especialidad_MOD', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Especialidad, Especialidad, Estado FROM Especialidades WHERE Id_Especialidad=@Id_Test_ESPECIALIDADES

PRINT '-> Ejecutando SP_ELIMINA_ESPECIALIDADES...'
EXEC SP_ELIMINA_ESPECIALIDADES @Id_Especialidad=@Id_Test_ESPECIALIDADES, @IdUsuarioGlobal=1

PRINT '-> Verificando que el registro ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Especialidades WHERE Id_Especialidad=@Id_Test_ESPECIALIDADES
GO

-- ============================================================
-- PRUEBA: ESPECIES
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: ESPECIES'
PRINT '=============================================='

PRINT '-> Creando registro de prueba...'
INSERT INTO Especies (Especie, Estado) VALUES ('TEST_Especie', 'A')
DECLARE @Id_Test_ESPECIES INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_ESPECIES...'
EXEC SP_LISTAR_ESPECIES

PRINT '-> Ejecutando SP_FILTRAR_ESPECIES (buscando "TEST")...'
EXEC SP_FILTRAR_ESPECIES @Filtro='TEST'

PRINT '-> Ejecutando SP_ACTUALIZA_ESPECIES...'
EXEC SP_ACTUALIZA_ESPECIES @Id_Especie=@Id_Test_ESPECIES, @Especie='TEST_Especie_MOD', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Especie, Especie, Estado FROM Especies WHERE Id_Especie=@Id_Test_ESPECIES

PRINT '-> Ejecutando SP_ELIMINA_ESPECIES...'
EXEC SP_ELIMINA_ESPECIES @Id_Especie=@Id_Test_ESPECIES, @IdUsuarioGlobal=1

PRINT '-> Verificando que el registro ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Especies WHERE Id_Especie=@Id_Test_ESPECIES
GO

-- ============================================================
-- PRUEBA: RAZAS
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: RAZAS'
PRINT '=============================================='

PRINT '-> Creando registro de prueba...'
INSERT INTO Razas (Id_Especie, Raza, Estado) VALUES (1, 'TEST_Raza', 'A')
DECLARE @Id_Test_RAZAS INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_RAZAS...'
EXEC SP_LISTAR_RAZAS

PRINT '-> Ejecutando SP_FILTRAR_RAZAS (buscando "TEST")...'
EXEC SP_FILTRAR_RAZAS @Filtro='TEST'

PRINT '-> Ejecutando SP_ACTUALIZA_RAZAS...'
EXEC SP_ACTUALIZA_RAZAS @Id_Raza=@Id_Test_RAZAS, @Id_Especie=1, @Raza='TEST_Raza_MOD', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Raza, Id_Especie, Raza, Estado FROM Razas WHERE Id_Raza=@Id_Test_RAZAS

PRINT '-> Ejecutando SP_ELIMINA_RAZAS...'
EXEC SP_ELIMINA_RAZAS @Id_Raza=@Id_Test_RAZAS, @IdUsuarioGlobal=1

PRINT '-> Verificando que el registro ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Razas WHERE Id_Raza=@Id_Test_RAZAS
GO

-- ============================================================
-- PRUEBA: PROPIETARIOS
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: PROPIETARIOS'
PRINT '=============================================='

PRINT '-> Creando registro de prueba...'
INSERT INTO Propietarios (Id_Tipo_Identificacion, Nombre, Apellido1, Apellido2, Telefono, Email, Direccion, Estado) VALUES (1, 'TEST_Nombre', 'TEST_Apellido1', 'TEST_Apellido2', '80000000', 'test.propietario@correo.com', 'Direccion de prueba', 'A')
DECLARE @Id_Test_PROPIETARIOS INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_PROPIETARIOS...'
EXEC SP_LISTAR_PROPIETARIOS

PRINT '-> Ejecutando SP_FILTRAR_PROPIETARIOS (buscando "TEST")...'
EXEC SP_FILTRAR_PROPIETARIOS @Filtro='TEST'

PRINT '-> Ejecutando SP_ACTUALIZA_PROPIETARIOS...'
EXEC SP_ACTUALIZA_PROPIETARIOS @Id_Propietario=@Id_Test_PROPIETARIOS, @Id_Tipo_Identificacion=1, @Nombre='TEST_Nombre_MOD', @Apellido1='TEST_Apellido1', @Apellido2='TEST_Apellido2', @Telefono='80000001', @Email='test.propietario.mod@correo.com', @Direccion='Direccion modificada', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Propietario, Nombre, Apellido1, Telefono, Email, Estado FROM Propietarios WHERE Id_Propietario=@Id_Test_PROPIETARIOS

PRINT '-> Ejecutando SP_ELIMINA_PROPIETARIOS...'
EXEC SP_ELIMINA_PROPIETARIOS @Id_Propietario=@Id_Test_PROPIETARIOS, @IdUsuarioGlobal=1

PRINT '-> Verificando que el registro ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Propietarios WHERE Id_Propietario=@Id_Test_PROPIETARIOS
GO

-- ============================================================
-- PRUEBA: VETERINARIOS
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: VETERINARIOS'
PRINT '=============================================='

PRINT '-> Creando registro de prueba...'
INSERT INTO Veterinarios (Id_Tipo_Identificacion, Identificacion, Nombre, Apellido1, Apellido2, Id_Especialidad, Telefono, Email, Estado) VALUES (1, '9-9999-9999', 'TEST_Veterinario', 'TEST_Apellido1', 'TEST_Apellido2', 1, '80000002', 'test.veterinario@correo.com', 'A')
DECLARE @Id_Test_VETERINARIOS INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_VETERINARIOS...'
EXEC SP_LISTAR_VETERINARIOS

PRINT '-> Ejecutando SP_FILTRAR_VETERINARIOS (buscando "TEST")...'
EXEC SP_FILTRAR_VETERINARIOS @Filtro='TEST'

PRINT '-> Ejecutando SP_ACTUALIZA_VETERINARIOS...'
EXEC SP_ACTUALIZA_VETERINARIOS @Id_Veterinario=@Id_Test_VETERINARIOS, @Id_Tipo_Identificacion=1, @Identificacion='9-9999-9999', @Nombre='TEST_Veterinario_MOD', @Apellido1='TEST_Apellido1', @Apellido2='TEST_Apellido2', @Id_Especialidad=1, @Telefono='80000003', @Email='test.veterinario.mod@correo.com', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Veterinario, Nombre, Identificacion, Telefono, Email, Estado FROM Veterinarios WHERE Id_Veterinario=@Id_Test_VETERINARIOS

PRINT '-> Ejecutando SP_ELIMINA_VETERINARIOS...'
EXEC SP_ELIMINA_VETERINARIOS @Id_Veterinario=@Id_Test_VETERINARIOS, @IdUsuarioGlobal=1

PRINT '-> Verificando que el registro ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Veterinarios WHERE Id_Veterinario=@Id_Test_VETERINARIOS
GO

-- ============================================================
-- PRUEBA: MASCOTAS
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: MASCOTAS'
PRINT '=============================================='

PRINT '-> Creando registro de prueba...'
INSERT INTO Mascotas (Id_Propietario, Id_Raza, Nombre, Sexo, Fecha_Nacimiento, Peso, Color, Estado) VALUES (1, 1, 'TEST_Mascota', 'Macho', '2023-01-01', '5.0', 'Negro', 'A')
DECLARE @Id_Test_MASCOTAS INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_MASCOTAS...'
EXEC SP_LISTAR_MASCOTAS

PRINT '-> Ejecutando SP_FILTRAR_MASCOTAS (buscando "TEST")...'
EXEC SP_FILTRAR_MASCOTAS @Filtro='TEST'

PRINT '-> Ejecutando SP_ACTUALIZA_MASCOTAS...'
EXEC SP_ACTUALIZA_MASCOTAS @Id_Mascota=@Id_Test_MASCOTAS, @Id_Propietario=1, @Id_Raza=1, @Nombre='TEST_Mascota_MOD', @Sexo='Hembra', @Fecha_Nacimiento='2023-02-15', @Peso='6.2', @Color='Blanco', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Mascota, Nombre, Sexo, Peso, Color, Estado FROM Mascotas WHERE Id_Mascota=@Id_Test_MASCOTAS

PRINT '-> Ejecutando SP_ELIMINA_MASCOTAS...'
EXEC SP_ELIMINA_MASCOTAS @Id_Mascota=@Id_Test_MASCOTAS, @IdUsuarioGlobal=1

PRINT '-> Verificando que el registro ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Mascotas WHERE Id_Mascota=@Id_Test_MASCOTAS
GO

-- ============================================================
-- PRUEBA: CITAS + CONSULTAS (combinado por la dependencia entre ambas)
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: CITAS'
PRINT '=============================================='

PRINT '-> Creando cita de prueba (Id_Mascota=1, Id_Veterinario=1)...'
INSERT INTO Citas (Id_Mascota, Id_Veterinario, Fecha, Hora, Motivo, Estado_Cita)
VALUES (1, 1, '2026-08-01', '09:00', 'TEST_Motivo', 'Pendiente')
DECLARE @Id_Test_Cita INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_CITAS...'
EXEC SP_LISTAR_CITAS

PRINT '-> Ejecutando SP_FILTRAR_CITAS (busca todas las citas que tenga la mascota)...'
EXEC SP_FILTRAR_CITAS @Nombre='Firulais'

PRINT '-> Ejecutando SP_ACTUALIZA_CITAS...'
EXEC SP_ACTUALIZA_CITAS @Id_Cita=@Id_Test_Cita, @Id_Mascota=1, @Id_Veterinario=1, @Fecha='2026-08-02', @Hora='10:30', @Motivo='TEST_Motivo_MOD', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Cita, Fecha, Hora, Motivo, Estado_Cita FROM Citas WHERE Id_Cita=@Id_Test_Cita

PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: CONSULTAS'
PRINT '=============================================='

PRINT '-> Creando consulta de prueba (ligada a la cita de prueba)...'
INSERT INTO Consultas (Id_Cita, Diagnostico, Tratamiento, Observaciones)
VALUES (@Id_Test_Cita, 'TEST_Diagnostico', 'TEST_Tratamiento', 'TEST_Observaciones')
DECLARE @Id_Test_Consulta INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_CONSULTAS...'
EXEC SP_LISTAR_CONSULTAS

PRINT '-> Ejecutando SP_FILTRAR_CONSULTAS (consulta la info de la cita)...'
EXEC SP_FILTRAR_CONSULTAS @Id_Cita='43'

PRINT '-> Ejecutando SP_ACTUALIZA_CONSULTAS...'
EXEC SP_ACTUALIZA_CONSULTAS @Id_Consulta=@Id_Test_Consulta, @Id_Cita=@Id_Test_Cita, @Diagnostico='TEST_Diagnostico_MOD', @Tratamiento='TEST_Tratamiento_MOD', @Observaciones='TEST_Observaciones_MOD', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Consulta, Id_Cita, Diagnostico, Tratamiento, Observaciones FROM Consultas WHERE Id_Consulta=@Id_Test_Consulta

PRINT '-> Ejecutando SP_ELIMINA_CONSULTAS...'
EXEC SP_ELIMINA_CONSULTAS @Id_Consulta=@Id_Test_Consulta, @IdUsuarioGlobal=1

PRINT '-> Verificando que la consulta ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Consultas WHERE Id_Consulta=@Id_Test_Consulta

PRINT '-> Ahora si, ejecutando SP_ELIMINA_CITAS (la consulta ya se borro, no deberia haber bloqueo)...'
EXEC SP_ELIMINA_CITAS @Id_Cita=@Id_Test_Cita, @IdUsuarioGlobal=1

PRINT '-> Verificando que la cita ya no existe (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes FROM Citas WHERE Id_Cita=@Id_Test_Cita
GO

-- ============================================================
-- PRUEBA: USUARIOS
-- ============================================================
PRINT '=============================================='
PRINT 'PROBANDO PROCEDIMIENTOS DE: USUARIOS'
PRINT '=============================================='

PRINT '-> Creando usuario de prueba (Id_Rol=1, Administrador)...'
INSERT INTO Usuarios (Id_Rol, Nombre_Usuario, Email, Contrasena, Estado)
VALUES (1, 'TEST_usuario', 'test.usuario@vetnova.com', 'clave123', 'A')
DECLARE @Id_Test_Usuario INT = SCOPE_IDENTITY()

PRINT '-> Ejecutando SP_LISTAR_USUARIOS...'
EXEC SP_LISTAR_USUARIOS

PRINT '-> Ejecutando SP_FILTRAR_USUARIOS (buscando "TEST")...'
EXEC SP_FILTRAR_USUARIOS @Nombre_Usuario='TEST'

PRINT '-> Ejecutando SP_INFO_USUARIOS...'
EXEC SP_INFO_USUARIOS @Id_Usuario=@Id_Test_Usuario

PRINT '-> Ejecutando SP_INICIAR_SESION con credenciales correctas (deberia devolver el Id_Usuario)...'
EXEC SP_INICIAR_SESION @Nombre_Usuario='TEST_usuario', @Contrasena='clave123'

PRINT '-> Ejecutando SP_INICIAR_SESION con contrasena incorrecta (debe fallar / no devolver Id)...'
EXEC SP_INICIAR_SESION @Nombre_Usuario='TEST_usuario', @Contrasena='clave_incorrecta'

PRINT '-> Ejecutando SP_ACTUALIZA_USUARIOS...'
EXEC SP_ACTUALIZA_USUARIOS @Id_Usuario=@Id_Test_Usuario, @Id_Rol=1, @Nombre_Usuario='TEST_usuario_MOD', @Email='test.usuario.mod@vetnova.com', @Contrasena='clave456', @Estado='I', @IdUsuarioGlobal=1

PRINT '-> Verificando que el UPDATE se aplico correctamente:'
SELECT Id_Usuario, Id_Rol, Nombre_Usuario, Email, Estado FROM Usuarios WHERE Id_Usuario=@Id_Test_Usuario

-- REGLA DE NEGOCIO CONFIRMADA CON EL EQUIPO: SP_ELIMINA_USUARIOS NO elimina
-- usuarios que ya tengan historial en Auditoria (es decir, que ya hayan
-- iniciado sesion o hecho alguna accion). Esto es INTENCIONAL: la decision
-- del equipo fue que "eliminar" un usuario con auditoria no debe ser posible
-- desde este SP; en su lugar, se debe usar SP_ACTUALIZA_USUARIOS para poner
-- Estado='I' (inactivar) y conservar el historial de auditoria intacto.
--
-- En este script de pruebas, el usuario de prueba SI genero auditoria
-- (por el EXEC SP_INICIAR_SESION de arriba, que registra el login usando
-- el propio Id_Usuario del que inicia sesion), asi que el resultado
-- esperado AQUI es que el SP se niegue a borrarlo.
PRINT '-> Ejecutando SP_ELIMINA_USUARIOS...'
EXEC SP_ELIMINA_USUARIOS @Id_Usuario=@Id_Test_Usuario, @IdUsuarioGlobal=1
-- El resultado de este EXEC debe ser -1 (no 0 ni el Id del usuario):
-- -1 = bloqueado porque el usuario ya tiene registros en Auditoria (esperado)
--  0 = hubo un error inesperado (revisar el BEGIN CATCH)
-- Id_Usuario = se elimino correctamente (solo pasaria si el usuario NUNCA
--              hizo login ni ninguna otra accion registrada en Auditoria)

PRINT '-> Verificando si el usuario sigue existiendo:'
-- OJO: aqui el resultado esperado es 1, NO 0. Como el SP bloqueo el borrado
-- (por la regla de negocio de arriba), el usuario de prueba SIGUE existiendo
-- en la tabla. Un valor de 1 en este caso es el comportamiento CORRECTO,
-- no un error. (Si quisieras forzar que de 0 para probar un borrado real,
-- tendrias que usar un usuario de prueba que NUNCA haya iniciado sesion
-- ni aparecido en Auditoria por ningun otro motivo).
SELECT COUNT(*) AS Filas_Restantes FROM Usuarios WHERE Id_Usuario=@Id_Test_Usuario

-- Limpieza manual del usuario de prueba: como el SP lo bloqueo a proposito
-- (comportamiento correcto), lo limpiamos aqui de forma directa para no
-- dejar datos de prueba residuales en la base. Primero borramos su rastro
-- en Auditoria (para no dejar huerfanos) y despues el usuario.
PRINT '-> Limpieza: borrando manualmente el usuario de prueba bloqueado...'
DELETE FROM Auditoria WHERE Id_Usuario=@Id_Test_Usuario
DELETE FROM Usuarios WHERE Id_Usuario=@Id_Test_Usuario

PRINT '-> Verificando limpieza final (debe dar 0):'
SELECT COUNT(*) AS Filas_Restantes_Tras_Limpieza FROM Usuarios WHERE Id_Usuario=@Id_Test_Usuario
GO

-- ============================================================
-- FIN DE PRUEBAS
-- ============================================================
PRINT '=============================================='
PRINT 'PRUEBAS FINALIZADAS. Revisa arriba cada seccion:'
PRINT '- Los SELECT despues de cada ACTUALIZA deben mostrar los datos _MOD'
PRINT '- Los SELECT despues de cada ELIMINA deben mostrar 0 en Filas_Restantes'
PRINT '- Tus datos reales del script 3 (Propietarios, Mascotas, Citas, etc.)'
PRINT '  NO fueron tocados: todo lo de aqui uso registros TEST_ dedicados.'
PRINT '=============================================='
GO