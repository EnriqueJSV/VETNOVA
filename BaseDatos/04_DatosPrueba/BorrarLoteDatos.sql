/*
  VETNOVA - LIMPIEZA COMPLETA DE LOS DATOS INSERTADOS POR LoteDatos.sql
  -----------------------------------------------------------------------
  Este script borra TODOS los registros que inserto el script LoteDatos.sql
  (via los SP_INSERTA_X), dejando las tablas vacias pero SIN borrar la
  estructura (tablas, procedimientos, etc. quedan intactos).

  Tambien reinicia los contadores IDENTITY de cada tabla a 0, para que la
  proxima vez que corras LoteDatos.sql, los IDs vuelvan a empezar desde 1
  (igual que en una base de datos recien creada).

  ORDEN: se borra de "hijo" a "padre" (children first) para no violar
  las llaves foraneas. Es el orden inverso al que se usa para INSERTAR.

  ADVERTENCIA: esto borra TODOS los datos de estas tablas, incluyendo
  cualquier dato que hayas agregado manualmente despues de correr
  LoteDatos.sql (como usuarios de prueba, citas nuevas, etc.). Si tienes
  algo que quieras conservar, respaldalo antes de correr este script.
*/

USE VetNova
GO

PRINT '-> Borrando Consultas...'
DELETE FROM Consultas
GO

PRINT '-> Borrando Citas...'
DELETE FROM Citas
GO

PRINT '-> Borrando Auditoria...'
DELETE FROM Auditoria
GO

PRINT '-> Borrando Mascotas...'
DELETE FROM Mascotas
GO

PRINT '-> Borrando Veterinarios...'
DELETE FROM Veterinarios
GO

PRINT '-> Borrando Propietarios...'
DELETE FROM Propietarios
GO

PRINT '-> Borrando Usuarios...'
DELETE FROM Usuarios
GO

PRINT '-> Borrando Razas...'
DELETE FROM Razas
GO

PRINT '-> Borrando Especialidades...'
DELETE FROM Especialidades
GO

PRINT '-> Borrando Especies...'
DELETE FROM Especies
GO

PRINT '-> Borrando Tipos_Identificacion...'
DELETE FROM Tipos_Identificacion
GO

PRINT '-> Borrando Roles...'
DELETE FROM Roles
GO

-- ============================================================
-- Reiniciar los IDENTITY de cada tabla para que el proximo
-- INSERT/EXEC empiece de nuevo en Id = 1
-- ============================================================
PRINT '-> Reiniciando contadores IDENTITY...'
DBCC CHECKIDENT ('Consultas', RESEED, 0)
DBCC CHECKIDENT ('Citas', RESEED, 0)
DBCC CHECKIDENT ('Auditoria', RESEED, 0)
DBCC CHECKIDENT ('Mascotas', RESEED, 0)
DBCC CHECKIDENT ('Veterinarios', RESEED, 0)
DBCC CHECKIDENT ('Propietarios', RESEED, 0)
DBCC CHECKIDENT ('Usuarios', RESEED, 0)
DBCC CHECKIDENT ('Razas', RESEED, 0)
DBCC CHECKIDENT ('Especialidades', RESEED, 0)
DBCC CHECKIDENT ('Especies', RESEED, 0)
DBCC CHECKIDENT ('Tipos_Identificacion', RESEED, 0)
DBCC CHECKIDENT ('Roles', RESEED, 0)
GO

-- ============================================================
-- Verificacion final: todas las tablas deben quedar en 0
-- ============================================================
PRINT '-> Verificando que todas las tablas quedaron vacias:'
SELECT 'Roles' AS Tabla, COUNT(*) AS Cantidad FROM Roles
UNION ALL SELECT 'Tipos_Identificacion', COUNT(*) FROM Tipos_Identificacion
UNION ALL SELECT 'Especialidades', COUNT(*) FROM Especialidades
UNION ALL SELECT 'Especies', COUNT(*) FROM Especies
UNION ALL SELECT 'Razas', COUNT(*) FROM Razas
UNION ALL SELECT 'Propietarios', COUNT(*) FROM Propietarios
UNION ALL SELECT 'Usuarios', COUNT(*) FROM Usuarios
UNION ALL SELECT 'Veterinarios', COUNT(*) FROM Veterinarios
UNION ALL SELECT 'Mascotas', COUNT(*) FROM Mascotas
UNION ALL SELECT 'Citas', COUNT(*) FROM Citas
UNION ALL SELECT 'Consultas', COUNT(*) FROM Consultas
UNION ALL SELECT 'Auditoria', COUNT(*) FROM Auditoria
ORDER BY Tabla ASC
GO

PRINT '-> Listo. Todas las tablas deben mostrar Cantidad = 0.'
PRINT '-> Ahora puedes volver a correr LoteDatos.sql para recargar datos frescos.'
GO