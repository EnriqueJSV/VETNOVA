/*
  VETNOVA - SCRIPT 3 DE 4 (VERSION EXEC): DATOS DE PRUEBA VIA PROCEDIMIENTOS ALMACENADOS
  ------------------------------------------------------------------------------------
  
  usa EXEC sobre cada SP_INSERTA_X que ya construyeron. Esto sirve para
  validar que los 40+ procedimientos de insercion funcionan correctamente
  de principio a fin (incluye la insercion automatica en Auditoria).

  Instrucciones:
  1) Ejecutar PRIMERO "BD&Tablas_CreacionScript.sql"
  2) Ejecutar SEGUNDO "SPs_CreacionScript.sql"
  3) Ejecutar este script (3) en SSMS con F5

  IMPORTANTE - Excepciones:
  - ROLES: todavia no existe SP_INSERTA_ROLES, asi que esta tabla se llena
    con INSERT directo (son solo 3 filas fijas del catalogo).
  - USUARIOS: el PRIMER usuario (admin) se inserta DIRECTO, no con el SP,
    porque el SP exige un @IdUsuarioGlobal que ya debe existir en Usuarios
    (para la auditoria), y al inicio la tabla esta vacia. A partir del
    segundo usuario en adelante, SI se usa el SP normalmente.
  - Todos los EXEC siguientes usan @IdUsuarioGlobal = 1 (el usuario admin).

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
-- USUARIO SEMILLA (INSERT directo, unico caso especial)
-- ============================================================
INSERT INTO Usuarios (Id_Rol, Nombre_Usuario, Email, Contrasena, Estado)
VALUES (1, 'admin', 'admin@vetnova.com', 'admin123', 'A')
GO

-- ============================================================
-- USUARIOS (resto, via SP_INSERTA_USUARIOS)
-- ============================================================
EXEC SP_INSERTA_USUARIOS @Id_Rol=3, @Nombre_Usuario='recepcion1', @Email='recepcion1@vetnova.com', @Contrasena='recep123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=3, @Nombre_Usuario='recepcion2', @Email='recepcion2@vetnova.com', @Contrasena='recep123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.jimenez', @Email='jjimenez@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.mora', @Email='amora@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.solano', @Email='lsolano@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.castro', @Email='fcastro@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.rojas', @Email='krojas@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.vargas', @Email='vvargas@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.chacon', @Email='echacon@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.zuniga', @Email='yzuniga@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=1, @Nombre_Usuario='supervisor', @Email='supervisor@vetnova.com', @Contrasena='super123', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- TIPOS DE IDENTIFICACION (via SP_INSERTA_TIPOS_IDENTIFICACION)
-- ============================================================
EXEC SP_INSERTA_TIPOS_IDENTIFICACION @Tipo_Identificacion='Cedula Fisica', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_TIPOS_IDENTIFICACION @Tipo_Identificacion='Cedula Juridica', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_TIPOS_IDENTIFICACION @Tipo_Identificacion='DIMEX', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_TIPOS_IDENTIFICACION @Tipo_Identificacion='Pasaporte', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- ESPECIALIDADES (via SP_INSERTA_ESPECIALIDADES)
-- ============================================================
EXEC SP_INSERTA_ESPECIALIDADES @Especialidad='Medicina General', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIALIDADES @Especialidad='Cirugia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIALIDADES @Especialidad='Dermatologia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIALIDADES @Especialidad='Cardiologia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIALIDADES @Especialidad='Odontologia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIALIDADES @Especialidad='Oftalmologia', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- ESPECIES (via SP_INSERTA_ESPECIES)
-- ============================================================
EXEC SP_INSERTA_ESPECIES @Especie='Perro', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIES @Especie='Gato', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIES @Especie='Ave', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIES @Especie='Conejo', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_ESPECIES @Especie='Reptil', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- RAZAS (via SP_INSERTA_RAZAS)
-- ============================================================
EXEC SP_INSERTA_RAZAS @Id_Especie=1, @Raza='Labrador', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=1, @Raza='Poodle', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=1, @Raza='Chihuahua', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=1, @Raza='Bulldog Frances', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=1, @Raza='Pastor Aleman', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=1, @Raza='Schnauzer', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=2, @Raza='Siames', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=2, @Raza='Persa', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=2, @Raza='Angora', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=2, @Raza='Comun Europeo', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=2, @Raza='Maine Coon', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=3, @Raza='Canario', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=3, @Raza='Periquito', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=3, @Raza='Loro Amazona', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=3, @Raza='Cacatua', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=4, @Raza='Holandes Enano', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=4, @Raza='Cabeza de Leon', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=4, @Raza='Angora Ingles', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=5, @Raza='Iguana Verde', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_RAZAS @Id_Especie=5, @Raza='Tortuga de Tierra', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- PROPIETARIOS (via SP_INSERTA_PROPIETARIOS)
-- ============================================================
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=4, @Identificacion='1-111-111', @Nombre='Melissa', @Apellido1='Araya', @Apellido2='Rojas', @Telefono='81109031', @Email='melissa.araya1@correo.com', @Direccion='Guanacaste, 462 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=1, @Identificacion='2-111-111', @Nombre='Esteban', @Apellido1='Gonzalez', @Apellido2='Rojas', @Telefono='83608513', @Email='esteban.gonzalez2@correo.com', @Direccion='Alajuela, 440 metros este de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='2-121-451', @Nombre='Kenneth', @Apellido1='Mora', @Apellido2='Salazar', @Telefono='82622631', @Email='kenneth.mora3@correo.com', @Direccion='Heredia, 483 metros este de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='2-222-222', @Nombre='Mauricio', @Apellido1='Jimenez', @Apellido2='Quesada', @Telefono='89996414', @Email='mauricio.jimenez4@correo.com', @Direccion='San Jose, 243 metros norte de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=2, @Identificacion='3-433-333', @Nombre='Jorge', @Apellido1='Duran', @Apellido2='Chaves', @Telefono='84226067', @Email='jorge.duran5@correo.com', @Direccion='Limon, 85 metros norte de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='4-444-444', @Nombre='Diego', @Apellido1='Fernandez', @Apellido2='Mora', @Telefono='84905582', @Email='diego.fernandez6@correo.com', @Direccion='Guanacaste, 101 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='1-111-111', @Nombre='Laura', @Apellido1='Quesada', @Apellido2='Chaves', @Telefono='83728882', @Email='laura.quesada7@correo.com', @Direccion='Heredia, 231 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=2, @Identificacion='1-111-111', @Nombre='Ricardo', @Apellido1='Mora', @Apellido2='Duran', @Telefono='83871230', @Email='ricardo.mora8@correo.com', @Direccion='Puntarenas, 423 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='1-111-111', @Nombre='Gabriela', @Apellido1='Quesada', @Apellido2='Salazar', @Telefono='85528972', @Email='gabriela.quesada9@correo.com', @Direccion='Limon, 402 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='1-111-111', @Nombre='Vanessa', @Apellido1='Jimenez', @Apellido2='Alvarado', @Telefono='81538552', @Email='vanessa.jimenez10@correo.com', @Direccion='Guanacaste, 211 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=4, @Identificacion='1-324-111', @Nombre='Karla', @Apellido1='Mora', @Apellido2='Chacon', @Telefono='86279418', @Email='karla.mora11@correo.com', @Direccion='Alajuela, 385 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=4, @Identificacion='1-111-111', @Nombre='Yolanda', @Apellido1='Quesada', @Apellido2='Solano', @Telefono='85443951', @Email='yolanda.quesada12@correo.com', @Direccion='Alajuela, 176 metros este de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=1, @Identificacion='7-111-111', @Nombre='Sofia', @Apellido1='Araya', @Apellido2='Salazar', @Telefono='87073292', @Email='sofia.araya13@correo.com', @Direccion='Alajuela, 120 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-111-111', @Nombre='Paola', @Apellido1='Jimenez', @Apellido2='Vargas', @Telefono='83564251', @Email='paola.jimenez14@correo.com', @Direccion='Limon, 131 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-111-111', @Nombre='Federico', @Apellido1='Salazar', @Apellido2='Salazar', @Telefono='88852574', @Email='federico.salazar15@correo.com', @Direccion='Puntarenas, 178 metros norte de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=2, @Identificacion='4-111-111', @Nombre='Karen', @Apellido1='Camacho', @Apellido2='Rojas', @Telefono='86707197', @Email='karen.camacho16@correo.com', @Direccion='San Jose, 200 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-111-111', @Nombre='Jose', @Apellido1='Quesada', @Apellido2='Rodriguez', @Telefono='85418934', @Email='jose.quesada17@correo.com', @Direccion='Puntarenas, 440 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-111-111', @Nombre='Mariela', @Apellido1='Fernandez', @Apellido2='Villalobos', @Telefono='84337174', @Email='mariela.fernandez18@correo.com', @Direccion='Alajuela, 241 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='7-111-111', @Nombre='Alejandro', @Apellido1='Duran', @Apellido2='Gonzalez', @Telefono='89197443', @Email='alejandro.duran19@correo.com', @Direccion='San Jose, 107 metros este de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=4, @Identificacion='1-111-111', @Nombre='Carlos', @Apellido1='Alvarado', @Apellido2='Jimenez', @Telefono='85041154', @Email='carlos.alvarado20@correo.com', @Direccion='Puntarenas, 90 metros norte de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=2, @Identificacion='8-111-111', @Nombre='Silvia', @Apellido1='Mora', @Apellido2='Camacho', @Telefono='83109911', @Email='silvia.mora21@correo.com', @Direccion='Alajuela, 387 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='1-111-111', @Nombre='Oscar', @Apellido1='Rojas', @Apellido2='Villalobos', @Telefono='88099076', @Email='oscar.rojas22@correo.com', @Direccion='Alajuela, 326 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=2, @Identificacion='1-111-111', @Nombre='Luis', @Apellido1='Salazar', @Apellido2='Chaves', @Telefono='88350099', @Email='luis.salazar23@correo.com', @Direccion='Puntarenas, 281 metros norte de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=2, @Identificacion='1-111-111', @Nombre='Rodrigo', @Apellido1='Alvarado', @Apellido2='Mora', @Telefono='86672134', @Email='rodrigo.alvarado24@correo.com', @Direccion='San Jose, 351 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=3, @Identificacion='3-111-111', @Nombre='Fabiola', @Apellido1='Rodriguez', @Apellido2='Mora', @Telefono='81987737', @Email='fabiola.rodriguez25@correo.com', @Direccion='Alajuela, 84 metros norte de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=2, @Identificacion='1-111-111', @Nombre='Andres', @Apellido1='Mora', @Apellido2='Villalobos', @Telefono='84993055', @Email='andres.mora26@correo.com', @Direccion='Heredia, 392 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=4, @Identificacion='1-111-111', @Nombre='Natalia', @Apellido1='Camacho', @Apellido2='Solano', @Telefono='88930103', @Email='natalia.camacho27@correo.com', @Direccion='Alajuela, 451 metros oeste de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=4, @Identificacion='5-111-111', @Nombre='Maria', @Apellido1='Chacon', @Apellido2='Vargas', @Telefono='82626229', @Email='maria.chacon28@correo.com', @Direccion='Limon, 270 metros este de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-111-111', @Nombre='Ana', @Apellido1='Zuniga', @Apellido2='Quesada', @Telefono='81908841', @Email='ana.zuniga29@correo.com', @Direccion='Limon, 384 metros norte de la iglesia', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_PROPIETARIOS @Id_Tipo_Identificacion=4, @Identificacion='1-111-111', @Nombre='Manuel', @Apellido1='Salazar', @Apellido2='Gonzalez', @Telefono='82833230', @Email='manuel.salazar30@correo.com', @Direccion='Alajuela, 148 metros sur de la iglesia', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- VETERINARIOS (via SP_INSERTA_VETERINARIOS)
-- ============================================================
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-1111-1111', @Nombre='Jose', @Apellido1='Jimenez', @Apellido2='Rodriguez', @Id_Especialidad=1, @Telefono='8811-0001', @Email='jjimenez@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='2-2222-2222', @Nombre='Ana', @Apellido1='Mora', @Apellido2='Vargas', @Id_Especialidad=2, @Telefono='8811-0002', @Email='amora@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='3-3333-3333', @Nombre='Luis', @Apellido1='Solano', @Apellido2='Castro', @Id_Especialidad=3, @Telefono='8811-0003', @Email='lsolano@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='4-4444-4444', @Nombre='Fabiola', @Apellido1='Castro', @Apellido2='Chacon', @Id_Especialidad=4, @Telefono='8811-0004', @Email='fcastro@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='5-5555-5555', @Nombre='Kenneth', @Apellido1='Rojas', @Apellido2='Alvarado', @Id_Especialidad=5, @Telefono='8811-0005', @Email='krojas@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='6-6666-6666', @Nombre='Vanessa', @Apellido1='Vargas', @Apellido2='Salazar', @Id_Especialidad=6, @Telefono='8811-0006', @Email='vvargas@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='7-7777-7777', @Nombre='Esteban', @Apellido1='Chacon', @Apellido2='Quesada', @Id_Especialidad=1, @Telefono='8811-0007', @Email='echacon@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='8-8888-8888', @Nombre='Yolanda', @Apellido1='Zuniga', @Apellido2='Duran', @Id_Especialidad=2, @Telefono='8811-0008', @Email='yzuniga@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- MASCOTAS (via SP_INSERTA_MASCOTAS)
-- ============================================================
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=5, @Id_Raza=14, @Nombre='Firulais', @Sexo='Macho', @Fecha_Nacimiento='2023-03-18', @Peso='18.8', @Color='Blanco', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=15, @Id_Raza=18, @Nombre='Luna', @Sexo='Macho', @Fecha_Nacimiento='2025-10-06', @Peso='26.3', @Color='Negro', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=3, @Id_Raza=8, @Nombre='Max', @Sexo='Macho', @Fecha_Nacimiento='2021-10-10', @Peso='19.7', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=28, @Id_Raza=13, @Nombre='Bella', @Sexo='Macho', @Fecha_Nacimiento='2024-06-26', @Peso='15.5', @Color='Atigrado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=9, @Id_Raza=15, @Nombre='Rocky', @Sexo='Hembra', @Fecha_Nacimiento='2021-08-03', @Peso='28.0', @Color='Beige', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=5, @Id_Raza=7, @Nombre='Nala', @Sexo='Hembra', @Fecha_Nacimiento='2023-11-22', @Peso='38.8', @Color='Negro', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=24, @Id_Raza=11, @Nombre='Toby', @Sexo='Macho', @Fecha_Nacimiento='2025-10-08', @Peso='23.6', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=2, @Id_Raza=17, @Nombre='Coco', @Sexo='Macho', @Fecha_Nacimiento='2016-10-13', @Peso='7.8', @Color='Blanco', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=22, @Id_Raza=8, @Nombre='Simba', @Sexo='Hembra', @Fecha_Nacimiento='2024-12-26', @Peso='37.7', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=19, @Id_Raza=20, @Nombre='Kiara', @Sexo='Macho', @Fecha_Nacimiento='2019-05-22', @Peso='3.7', @Color='Dorado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=30, @Id_Raza=9, @Nombre='Zeus', @Sexo='Macho', @Fecha_Nacimiento='2018-10-27', @Peso='28.8', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=9, @Id_Raza=13, @Nombre='Milo', @Sexo='Macho', @Fecha_Nacimiento='2018-10-19', @Peso='26.0', @Color='Beige', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=11, @Id_Raza=3, @Nombre='Lola', @Sexo='Macho', @Fecha_Nacimiento='2021-03-11', @Peso='25.0', @Color='Blanco', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=3, @Id_Raza=18, @Nombre='Thor', @Sexo='Macho', @Fecha_Nacimiento='2020-08-28', @Peso='11.0', @Color='Dorado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=29, @Id_Raza=3, @Nombre='Nina', @Sexo='Macho', @Fecha_Nacimiento='2022-03-10', @Peso='11.8', @Color='Beige', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=27, @Id_Raza=18, @Nombre='Duke', @Sexo='Hembra', @Fecha_Nacimiento='2019-06-22', @Peso='39.4', @Color='Negro', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=22, @Id_Raza=18, @Nombre='Maya', @Sexo='Hembra', @Fecha_Nacimiento='2015-11-19', @Peso='26.7', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=9, @Id_Raza=4, @Nombre='Rex', @Sexo='Macho', @Fecha_Nacimiento='2018-01-03', @Peso='22.4', @Color='Manchado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=10, @Id_Raza=20, @Nombre='Sasha', @Sexo='Macho', @Fecha_Nacimiento='2018-04-14', @Peso='14.0', @Color='Manchado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=17, @Id_Raza=16, @Nombre='Bruno', @Sexo='Hembra', @Fecha_Nacimiento='2016-03-06', @Peso='36.4', @Color='Negro', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=3, @Id_Raza=14, @Nombre='Chispa', @Sexo='Hembra', @Fecha_Nacimiento='2025-11-02', @Peso='0.6', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=21, @Id_Raza=9, @Nombre='Canela', @Sexo='Macho', @Fecha_Nacimiento='2018-01-07', @Peso='18.0', @Color='Atigrado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=18, @Id_Raza=1, @Nombre='Pelusa', @Sexo='Macho', @Fecha_Nacimiento='2025-06-27', @Peso='37.8', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=18, @Id_Raza=2, @Nombre='Rambo', @Sexo='Hembra', @Fecha_Nacimiento='2019-10-20', @Peso='22.3', @Color='Atigrado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=5, @Id_Raza=2, @Nombre='Pipo', @Sexo='Hembra', @Fecha_Nacimiento='2022-03-30', @Peso='36.0', @Color='Negro', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=29, @Id_Raza=12, @Nombre='Kira', @Sexo='Macho', @Fecha_Nacimiento='2018-09-07', @Peso='10.4', @Color='Blanco', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=12, @Id_Raza=18, @Nombre='Buddy', @Sexo='Hembra', @Fecha_Nacimiento='2019-05-16', @Peso='30.1', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=28, @Id_Raza=6, @Nombre='Daisy', @Sexo='Macho', @Fecha_Nacimiento='2016-06-12', @Peso='16.8', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=24, @Id_Raza=11, @Nombre='Oreo', @Sexo='Hembra', @Fecha_Nacimiento='2017-05-03', @Peso='27.0', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=9, @Id_Raza=6, @Nombre='Sombra', @Sexo='Macho', @Fecha_Nacimiento='2022-01-16', @Peso='35.0', @Color='Beige', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=8, @Id_Raza=7, @Nombre='Lucky', @Sexo='Hembra', @Fecha_Nacimiento='2022-05-30', @Peso='12.6', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=8, @Id_Raza=1, @Nombre='Mia', @Sexo='Macho', @Fecha_Nacimiento='2021-11-11', @Peso='13.5', @Color='Blanco', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=25, @Id_Raza=9, @Nombre='Zoe', @Sexo='Hembra', @Fecha_Nacimiento='2019-02-20', @Peso='20.6', @Color='Dorado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=1, @Id_Raza=4, @Nombre='Loki', @Sexo='Hembra', @Fecha_Nacimiento='2024-04-30', @Peso='23.4', @Color='Manchado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=2, @Id_Raza=4, @Nombre='Nube', @Sexo='Hembra', @Fecha_Nacimiento='2022-06-16', @Peso='29.3', @Color='Dorado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=14, @Id_Raza=20, @Nombre='Tigre', @Sexo='Macho', @Fecha_Nacimiento='2022-01-05', @Peso='36.0', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=9, @Id_Raza=2, @Nombre='Perla', @Sexo='Hembra', @Fecha_Nacimiento='2026-04-25', @Peso='21.0', @Color='Gris', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=12, @Id_Raza=14, @Nombre='Bongo', @Sexo='Macho', @Fecha_Nacimiento='2015-09-10', @Peso='26.7', @Color='Dorado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=20, @Id_Raza=11, @Nombre='Frida', @Sexo='Macho', @Fecha_Nacimiento='2018-04-05', @Peso='36.1', @Color='Manchado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=22, @Id_Raza=14, @Nombre='Rufus', @Sexo='Hembra', @Fecha_Nacimiento='2021-10-26', @Peso='28.0', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=7, @Id_Raza=14, @Nombre='Peque', @Sexo='Hembra', @Fecha_Nacimiento='2018-09-26', @Peso='30.1', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=20, @Id_Raza=19, @Nombre='Manchas', @Sexo='Hembra', @Fecha_Nacimiento='2021-10-11', @Peso='22.1', @Color='Negro', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=10, @Id_Raza=10, @Nombre='Copito', @Sexo='Macho', @Fecha_Nacimiento='2021-07-06', @Peso='31.5', @Color='Dorado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=15, @Id_Raza=15, @Nombre='Bimbo', @Sexo='Hembra', @Fecha_Nacimiento='2018-10-03', @Peso='8.9', @Color='Beige', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=26, @Id_Raza=6, @Nombre='Estrella', @Sexo='Macho', @Fecha_Nacimiento='2023-02-24', @Peso='20.9', @Color='Dorado', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=3, @Id_Raza=8, @Nombre='Chester', @Sexo='Hembra', @Fecha_Nacimiento='2023-10-24', @Peso='32.4', @Color='Cafe', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=1, @Id_Raza=2, @Nombre='Princesa', @Sexo='Macho', @Fecha_Nacimiento='2021-01-01', @Peso='24.6', @Color='Blanco', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=15, @Id_Raza=14, @Nombre='Bandido', @Sexo='Macho', @Fecha_Nacimiento='2018-04-11', @Peso='28.0', @Color='Beige', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=13, @Id_Raza=8, @Nombre='Fiona', @Sexo='Macho', @Fecha_Nacimiento='2018-12-22', @Peso='27.7', @Color='Blanco', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_MASCOTAS @Id_Propietario=25, @Id_Raza=14, @Nombre='Chico', @Sexo='Macho', @Fecha_Nacimiento='2024-05-11', @Peso='32.3', @Color='Beige', @Estado='A', @IdUsuarioGlobal=1
GO

-- ============================================================
-- CITAS (via SP_INSERTA_CITAS)
-- ============================================================
EXEC SP_INSERTA_CITAS @Id_Mascota=4, @Id_Veterinario=4, @Fecha='2026-05-02', @Hora='15:15', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=6, @Fecha='2026-07-23', @Hora='16:45', @Motivo='Consulta por cojera', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=29, @Id_Veterinario=3, @Fecha='2026-07-31', @Hora='15:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=5, @Fecha='2026-08-12', @Hora='15:15', @Motivo='Desparasitacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=5, @Id_Veterinario=5, @Fecha='2026-05-31', @Hora='12:30', @Motivo='Cirugia menor', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=6, @Id_Veterinario=3, @Fecha='2026-05-09', @Hora='11:45', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=14, @Id_Veterinario=2, @Fecha='2026-07-16', @Hora='14:30', @Motivo='Emergencia', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=4, @Id_Veterinario=4, @Fecha='2026-07-17', @Hora='14:00', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=37, @Id_Veterinario=7, @Fecha='2026-08-01', @Hora='08:30', @Motivo='Desparasitacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=27, @Id_Veterinario=4, @Fecha='2026-08-03', @Hora='11:30', @Motivo='Limpieza dental', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=2, @Id_Veterinario=7, @Fecha='2026-06-26', @Hora='14:15', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=9, @Id_Veterinario=1, @Fecha='2026-07-10', @Hora='08:00', @Motivo='Consulta por vomito', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=30, @Id_Veterinario=3, @Fecha='2026-04-13', @Hora='12:45', @Motivo='Cirugia menor', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=21, @Id_Veterinario=6, @Fecha='2026-07-07', @Hora='12:45', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=31, @Id_Veterinario=1, @Fecha='2026-08-17', @Hora='08:30', @Motivo='Revision de piel', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=50, @Id_Veterinario=1, @Fecha='2026-04-08', @Hora='11:15', @Motivo='Consulta por cojera', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=10, @Id_Veterinario=4, @Fecha='2026-05-03', @Hora='15:00', @Motivo='Control post-operatorio', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=30, @Id_Veterinario=5, @Fecha='2026-07-04', @Hora='10:00', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=2, @Fecha='2026-08-27', @Hora='08:30', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=26, @Id_Veterinario=4, @Fecha='2026-04-20', @Hora='11:00', @Motivo='Revision de oido', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=44, @Id_Veterinario=2, @Fecha='2026-08-23', @Hora='08:30', @Motivo='Emergencia', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=6, @Fecha='2026-04-18', @Hora='16:30', @Motivo='Consulta general', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=32, @Id_Veterinario=2, @Fecha='2026-07-20', @Hora='13:45', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=12, @Id_Veterinario=5, @Fecha='2026-09-05', @Hora='16:45', @Motivo='Chequeo cardiaco', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=47, @Id_Veterinario=5, @Fecha='2026-06-22', @Hora='11:00', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=16, @Id_Veterinario=8, @Fecha='2026-08-24', @Hora='14:30', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=21, @Id_Veterinario=3, @Fecha='2026-08-03', @Hora='11:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=22, @Id_Veterinario=5, @Fecha='2026-08-31', @Hora='12:00', @Motivo='Emergencia', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=6, @Id_Veterinario=4, @Fecha='2026-07-14', @Hora='15:15', @Motivo='Revision de oido', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=46, @Id_Veterinario=8, @Fecha='2026-07-24', @Hora='08:00', @Motivo='Desparasitacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=45, @Id_Veterinario=4, @Fecha='2026-06-18', @Hora='13:45', @Motivo='Emergencia', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=28, @Id_Veterinario=6, @Fecha='2026-06-30', @Hora='15:30', @Motivo='Desparasitacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=8, @Id_Veterinario=4, @Fecha='2026-06-20', @Hora='09:15', @Motivo='Revision de piel', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=31, @Id_Veterinario=5, @Fecha='2026-08-29', @Hora='16:30', @Motivo='Vacunacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=19, @Id_Veterinario=4, @Fecha='2026-07-02', @Hora='10:30', @Motivo='Consulta general', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=9, @Id_Veterinario=5, @Fecha='2026-04-12', @Hora='08:30', @Motivo='Revision de oido', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=8, @Fecha='2026-04-27', @Hora='08:30', @Motivo='Chequeo cardiaco', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=22, @Id_Veterinario=3, @Fecha='2026-04-14', @Hora='12:45', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=26, @Id_Veterinario=8, @Fecha='2026-04-19', @Hora='08:15', @Motivo='Control de peso', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=2, @Fecha='2026-06-03', @Hora='09:45', @Motivo='Control post-operatorio', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=40, @Id_Veterinario=4, @Fecha='2026-08-12', @Hora='14:45', @Motivo='Chequeo cardiaco', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=38, @Id_Veterinario=7, @Fecha='2026-06-18', @Hora='08:00', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=14, @Id_Veterinario=5, @Fecha='2026-09-17', @Hora='09:15', @Motivo='Revision de piel', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=2, @Fecha='2026-05-11', @Hora='08:45', @Motivo='Chequeo cardiaco', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=31, @Id_Veterinario=5, @Fecha='2026-04-09', @Hora='11:30', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=30, @Id_Veterinario=2, @Fecha='2026-09-23', @Hora='11:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=28, @Id_Veterinario=2, @Fecha='2026-08-18', @Hora='11:15', @Motivo='Desparasitacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=5, @Id_Veterinario=1, @Fecha='2026-05-13', @Hora='12:30', @Motivo='Chequeo cardiaco', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=45, @Id_Veterinario=5, @Fecha='2026-09-27', @Hora='14:30', @Motivo='Emergencia', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=29, @Id_Veterinario=2, @Fecha='2026-09-01', @Hora='08:45', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=39, @Id_Veterinario=5, @Fecha='2026-04-07', @Hora='09:15', @Motivo='Consulta por vomito', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=37, @Id_Veterinario=1, @Fecha='2026-09-20', @Hora='12:00', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=31, @Id_Veterinario=8, @Fecha='2026-06-11', @Hora='10:45', @Motivo='Consulta por vomito', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=6, @Id_Veterinario=8, @Fecha='2026-06-29', @Hora='14:30', @Motivo='Cirugia menor', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=11, @Id_Veterinario=6, @Fecha='2026-07-15', @Hora='15:30', @Motivo='Consulta por vomito', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=1, @Fecha='2026-07-26', @Hora='09:30', @Motivo='Desparasitacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=50, @Id_Veterinario=7, @Fecha='2026-08-10', @Hora='08:45', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=13, @Id_Veterinario=6, @Fecha='2026-09-07', @Hora='15:45', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=14, @Id_Veterinario=5, @Fecha='2026-08-19', @Hora='10:30', @Motivo='Chequeo cardiaco', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=8, @Id_Veterinario=1, @Fecha='2026-09-09', @Hora='11:15', @Motivo='Desparasitacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=7, @Fecha='2026-04-24', @Hora='11:00', @Motivo='Chequeo cardiaco', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=42, @Id_Veterinario=3, @Fecha='2026-08-06', @Hora='12:30', @Motivo='Limpieza dental', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=31, @Id_Veterinario=4, @Fecha='2026-07-26', @Hora='16:15', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=39, @Id_Veterinario=3, @Fecha='2026-04-18', @Hora='12:45', @Motivo='Cirugia menor', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=33, @Id_Veterinario=5, @Fecha='2026-04-01', @Hora='12:30', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=8, @Fecha='2026-05-09', @Hora='15:45', @Motivo='Cirugia menor', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=7, @Fecha='2026-07-26', @Hora='13:15', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=25, @Id_Veterinario=4, @Fecha='2026-07-15', @Hora='08:30', @Motivo='Revision de oido', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=25, @Id_Veterinario=7, @Fecha='2026-09-17', @Hora='10:45', @Motivo='Consulta general', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=33, @Id_Veterinario=6, @Fecha='2026-04-26', @Hora='15:00', @Motivo='Emergencia', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=1, @Id_Veterinario=3, @Fecha='2026-07-14', @Hora='10:00', @Motivo='Chequeo cardiaco', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=6, @Fecha='2026-09-07', @Hora='14:00', @Motivo='Consulta por cojera', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=44, @Id_Veterinario=7, @Fecha='2026-06-21', @Hora='15:00', @Motivo='Control post-operatorio', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=5, @Fecha='2026-05-29', @Hora='09:45', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=46, @Id_Veterinario=2, @Fecha='2026-07-23', @Hora='10:30', @Motivo='Consulta general', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=4, @Id_Veterinario=5, @Fecha='2026-07-01', @Hora='13:45', @Motivo='Control de peso', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=27, @Id_Veterinario=3, @Fecha='2026-05-14', @Hora='10:00', @Motivo='Control post-operatorio', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=40, @Id_Veterinario=4, @Fecha='2026-08-06', @Hora='10:15', @Motivo='Chequeo cardiaco', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=30, @Id_Veterinario=5, @Fecha='2026-09-18', @Hora='08:45', @Motivo='Desparasitacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=5, @Id_Veterinario=8, @Fecha='2026-06-28', @Hora='12:45', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
GO

-- ============================================================
-- CONSULTAS (via SP_INSERTA_CONSULTAS, una por cada cita 'Atendida')
-- ============================================================
EXEC SP_INSERTA_CONSULTAS @Id_Cita=1, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=5, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=7, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=8, @Diagnostico='Gingivitis', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=11, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=14, @Diagnostico='Conjuntivitis', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=18, @Diagnostico='Fractura en recuperacion', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=20, @Diagnostico='Conjuntivitis', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=22, @Diagnostico='Sobrepeso moderado', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=25, @Diagnostico='Otitis leve', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=29, @Diagnostico='Fractura en recuperacion', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=31, @Diagnostico='Parasitos intestinales', @Tratamiento='Aplicacion de vacuna y desparasitante', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=35, @Diagnostico='Gingivitis', @Tratamiento='Suero y control en 48 horas', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=37, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=38, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=39, @Diagnostico='Deshidratacion leve', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=40, @Diagnostico='Gingivitis', @Tratamiento='Control quirurgico en 15 dias', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=44, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=51, @Diagnostico='Otitis leve', @Tratamiento='Aplicacion de vacuna y desparasitante', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=53, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=54, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=65, @Diagnostico='Deshidratacion leve', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=68, @Diagnostico='Parasitos intestinales', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=71, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=74, @Diagnostico='Sobrepeso moderado', @Tratamiento='Control quirurgico en 15 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CONSULTAS @Id_Cita=77, @Diagnostico='Conjuntivitis', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=1
GO

-- ============================================================
-- VERIFICACION: revisa que las cantidades coincidan con lo esperado
-- ============================================================
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
order by Tabla Asc
GO

-- Cantidades esperadas SOLO SI la base de datos estaba COMPLETAMENTE VACIA
-- RESULTADO REAL OBTENIDO (30/07/2026), confirmado como CORRECTO:
-- Roles: 4 | Tipos_Identificacion: 4 | Especialidades: 6 | Especies: 5
-- Razas: 20 | Propietarios: 30 | Usuarios: 14
-- Veterinarios: 8 | Mascotas: 50 | Citas: 80
-- Consultas: 26 | Auditoria: 240

SELECT Accion, COUNT(*) AS Cantidad FROM Auditoria GROUP BY Accion