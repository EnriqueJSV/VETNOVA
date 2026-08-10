/*
  VETNOVA - SCRIPT PARA EL PROFESOR: SISTEMA VACIO, SOLO ACCESOS BASICOS
  ------------------------------------------------------------------------------------

  Este script NO carga datos de prueba masivos. Unicamente crea:
    - Los 3 Roles del sistema (Administrador, Veterinario, Recepcionista)
    - 3 cuentas de Usuario para poder iniciar sesion y probar cada rol:
        1 Administrador, 1 Veterinario, 1 Recepcionista
    - Los catalogos minimos indispensables (1 Tipo de Identificacion,
      1 Especialidad) y 1 registro en la ficha de negocio Veterinarios,
      para que el combo de veterinarios en frmCitas NO se vea vacio.

  OJO - Usuarios vs Veterinarios son DOS TABLAS DISTINTAS sin relacion
  entre si: Usuarios es la cuenta de login (usuario/contraseña/rol).
  Veterinarios es la ficha de negocio del doctor (nombre, especialidad,
  telefono) que usa frmCitas para llenar su combo. Por eso el script
  inserta AMBAS cosas para el veterinario: la cuenta para loguearse Y
  el registro de negocio para que aparezca en los combos.

  Todo lo demas (Propietarios, Mascotas, Citas, Consultas, y el resto
  de catalogos: Especies, Razas) queda completamente vacio, para que
  el profesor vea el sistema arrancando desde cero y pueda ir cargando
  datos el mismo desde la aplicacion.

  Instrucciones:
  1) Ejecutar PRIMERO "BD&Tablas_CreacionScript.sql"
  2) Ejecutar SEGUNDO "SPs_CreacionScript.sql"
  3) Ejecutar este script en SSMS con F5

  Requiere que las tablas esten VACIAS antes de correr este script.
*/

USE VetNova
GO

-- ============================================================
-- ROLES (INSERT directo: aun no existe SP_INSERTA_ROLES)
-- ============================================================
INSERT INTO Roles (Rol, Estado) VALUES
('Administrador', 'A'),
('Veterinario', 'A'),
('Recepcionista', 'A')
GO

-- ============================================================
-- USUARIO ADMINISTRADOR (INSERT directo, es el primer usuario del
-- sistema y se necesita para que exista un Id_UsuarioGlobal valido
-- antes de poder usar los SP normales, que exigen ese dato para
-- registrar en Auditoria)
-- ============================================================
INSERT INTO Usuarios (Id_Rol, Nombre_Usuario, Email, Contrasena, Estado)
VALUES (1, 'admin', 'admin@vetnova.com', 'admin123', 'A')
GO

-- ============================================================
-- USUARIO VETERINARIO (via SP_INSERTA_USUARIOS)
-- Esto es la cuenta de LOGIN (usuario/contraseña/rol). Es un usuario
-- del sistema, NO es lo mismo que la ficha de negocio del doctor -
-- ver seccion "VETERINARIO (ficha de negocio)" mas abajo.
-- ============================================================
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='veterinario', @Email='veterinario@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- USUARIO RECEPCIONISTA (via SP_INSERTA_USUARIOS)
-- ============================================================
EXEC SP_INSERTA_USUARIOS @Id_Rol=3, @Nombre_Usuario='recepcionista', @Email='recepcionista@vetnova.com', @Contrasena='recep123', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- CATALOGOS MINIMOS DE SOPORTE (Veterinarios tiene FK a estas 2 tablas,
-- asi que necesitamos al menos 1 fila en cada una para poder insertar
-- el veterinario de negocio de abajo)
-- ============================================================
EXEC SP_INSERTA_TIPOS_IDENTIFICACION @Tipo_Identificacion='Cedula Fisica', @Estado='A', @IdUsuarioGlobal=1
GO
EXEC SP_INSERTA_ESPECIALIDADES @Especialidad='Medicina General', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- VETERINARIO (ficha de negocio, via SP_INSERTA_VETERINARIOS)
-- Esta es la tabla que usa frmCitas para llenar el combo de
-- veterinarios - es DISTINTA de la cuenta de login de arriba (no hay
-- FK entre Usuarios y Veterinarios). Sin esto, el profesor podria
-- loguearse como veterinario pero el combo de frmCitas se veria vacio.
-- ============================================================
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-1111-1111', @Nombre='Veterinario', @Apellido1='Prueba', @Apellido2='Sistema', @Id_Especialidad=1, @Telefono='8888-0000', @Email='veterinario@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- VERIFICACION
-- ============================================================
SELECT 'Roles' AS Tabla, COUNT(*) AS Cantidad FROM Roles
UNION ALL SELECT 'Usuarios', COUNT(*) FROM Usuarios
UNION ALL SELECT 'Tipos_Identificacion', COUNT(*) FROM Tipos_Identificacion
UNION ALL SELECT 'Especialidades', COUNT(*) FROM Especialidades
UNION ALL SELECT 'Especies', COUNT(*) FROM Especies
UNION ALL SELECT 'Razas', COUNT(*) FROM Razas
UNION ALL SELECT 'Propietarios', COUNT(*) FROM Propietarios
UNION ALL SELECT 'Veterinarios', COUNT(*) FROM Veterinarios
UNION ALL SELECT 'Mascotas', COUNT(*) FROM Mascotas
UNION ALL SELECT 'Citas', COUNT(*) FROM Citas
UNION ALL SELECT 'Consultas', COUNT(*) FROM Consultas
UNION ALL SELECT 'Auditoria', COUNT(*) FROM Auditoria
ORDER BY Tabla ASC
GO

-- Cantidades esperadas: Roles: 3 | Usuarios: 3 | Tipos_Identificacion: 1 |
-- Especialidades: 1 | Veterinarios: 1 | todo lo demas: 0
-- (Auditoria va a tener 5 filas: las 5 inserciones hechas via SP)

SELECT Nombre_Usuario, Email, Id_Rol, Estado FROM Usuarios ORDER BY Id_Usuario