/*
  VETNOVA - SCRIPT 3 DE 4 (VERSION EXEC) - LOTE V4: AUDITORIA VARIADA + PICOS
  ------------------------------------------------------------------------------------

  Cambios respecto al V3:
    - Citas y Consultas ya NO se registran todas con @IdUsuarioGlobal=1 (admin).
      Las Citas se reparten entre recepcionistas (mayoria), administradores
      y algun veterinario agendando directo. Las Consultas quedan registradas
      con el USUARIO DEL PROPIO VETERINARIO que atendio esa cita (ej. si
      Ana Mora atendio, la consulta queda a nombre de 'dra.mora'), para que
      Auditoria se vea como un sistema que realmente lleva meses en uso,
      no como si todo lo hubiera hecho el admin.
    - Catalogos/Usuarios/Propietarios/Veterinarios/Mascotas se siguen
      registrando con @IdUsuarioGlobal=1 (admin) porque es carga inicial
      del sistema, tiene sentido que la haya hecho el administrador.
    - Picos de citas el dia 17 de agosto (candidato a dia de
      la defensa), para que ese dia el grafico del dashboard se vea bien
      cargado sin importar cual de los tres termine siendo.

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
-- USUARIO SEMILLA (INSERT directo, unico caso especial)
-- ============================================================
INSERT INTO Usuarios (Id_Rol, Nombre_Usuario, Email, Contrasena, Estado)
VALUES (1, 'admin', 'admin@vetnova.com', 'admin123', 'A')
GO

-- ============================================================
-- USUARIOS (resto, via SP_INSERTA_USUARIOS)
-- Orden de insercion (importa para los Id_Usuario que se usan mas abajo
-- en Citas/Consultas):
--   1 admin (semilla)
--   2 gabriela.administradora | 3 andres.administrador
--   4 melissa.recepcionista | 5 esteban.recepcionista | 6 karla.recepcionista | 7 diego.recepcionista
--   8 dr.jimenez | 9 dra.mora | 10 dr.solano | 11 dra.castro | 12 dr.rojas
--   13 dra.vargas | 14 dr.chacon | 15 dra.zuniga | 16 dr.alvarado | 17 dra.quesada
-- ============================================================
EXEC SP_INSERTA_USUARIOS @Id_Rol=1, @Nombre_Usuario='gabriela.administradora', @Email='gabriela.administradora@vetnova.com', @Contrasena='admin123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=1, @Nombre_Usuario='andres.administrador', @Email='andres.administrador@vetnova.com', @Contrasena='admin123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=3, @Nombre_Usuario='melissa.recepcionista', @Email='melissa.recepcionista@vetnova.com', @Contrasena='recep123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=3, @Nombre_Usuario='esteban.recepcionista', @Email='esteban.recepcionista@vetnova.com', @Contrasena='recep123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=3, @Nombre_Usuario='karla.recepcionista', @Email='karla.recepcionista@vetnova.com', @Contrasena='recep123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=3, @Nombre_Usuario='diego.recepcionista', @Email='diego.recepcionista@vetnova.com', @Contrasena='recep123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.jimenez', @Email='jjimenez@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.mora', @Email='amora@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.solano', @Email='lsolano@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.castro', @Email='fcastro@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.rojas', @Email='krojas@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.vargas', @Email='vvargas@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.chacon', @Email='echacon@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.zuniga', @Email='yzuniga@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dr.alvarado', @Email='malvarado@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_USUARIOS @Id_Rol=2, @Nombre_Usuario='dra.quesada', @Email='pquesada@vetnova.com', @Contrasena='vet123', @Estado='A', @IdUsuarioGlobal=1
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
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='9-9999-9999', @Nombre='Mauricio', @Apellido1='Alvarado', @Apellido2='Jimenez', @Id_Especialidad=3, @Telefono='8811-0009', @Email='malvarado@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
EXEC SP_INSERTA_VETERINARIOS @Id_Tipo_Identificacion=1, @Identificacion='1-0101-0101', @Nombre='Paola', @Apellido1='Quesada', @Apellido2='Rojas', @Id_Especialidad=4, @Telefono='8811-0010', @Email='pquesada@vetnova.com', @Estado='A', @IdUsuarioGlobal=1
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
-- @IdUsuarioGlobal variado: mayoria recepcionistas (agendan citas),
-- algunos administradores, y ocasionalmente el propio veterinario.
-- Picos de citas los dias 9, 10 y 17 de agosto (candidatos a dia de
-- la defensa del proyecto).
-- ============================================================
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=8, @Fecha='2026-07-02', @Hora='15:15', @Motivo='Cirugia menor', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=15, @Id_Veterinario=2, @Fecha='2026-07-02', @Hora='17:00', @Motivo='Control post-operatorio', @Estado_Cita='Atendida', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=44, @Id_Veterinario=8, @Fecha='2026-07-04', @Hora='12:45', @Motivo='Cirugia menor', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=25, @Id_Veterinario=6, @Fecha='2026-07-04', @Hora='16:15', @Motivo='Chequeo cardiaco', @Estado_Cita='Cancelada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=42, @Id_Veterinario=3, @Fecha='2026-07-06', @Hora='12:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=6, @Id_Veterinario=7, @Fecha='2026-07-06', @Hora='14:30', @Motivo='Revision de piel', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=32, @Id_Veterinario=10, @Fecha='2026-07-07', @Hora='14:30', @Motivo='Consulta por vomito', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=9, @Fecha='2026-07-08', @Hora='07:45', @Motivo='Revision de piel', @Estado_Cita='Cancelada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=9, @Fecha='2026-07-08', @Hora='09:00', @Motivo='Consulta general', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=18, @Id_Veterinario=5, @Fecha='2026-07-10', @Hora='07:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=2, @Fecha='2026-07-10', @Hora='15:30', @Motivo='Chequeo cardiaco', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=5, @Fecha='2026-07-10', @Hora='16:15', @Motivo='Consulta general', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=9, @Fecha='2026-07-11', @Hora='08:00', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=13, @Id_Veterinario=6, @Fecha='2026-07-11', @Hora='11:30', @Motivo='Consulta general', @Estado_Cita='Cancelada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=6, @Id_Veterinario=1, @Fecha='2026-07-12', @Hora='07:30', @Motivo='Limpieza dental', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=32, @Id_Veterinario=5, @Fecha='2026-07-12', @Hora='14:00', @Motivo='Consulta por cojera', @Estado_Cita='Cancelada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=9, @Fecha='2026-07-12', @Hora='15:15', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CITAS @Id_Mascota=10, @Id_Veterinario=6, @Fecha='2026-07-13', @Hora='07:30', @Motivo='Emergencia', @Estado_Cita='Atendida', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=40, @Id_Veterinario=2, @Fecha='2026-07-13', @Hora='08:00', @Motivo='Control de peso', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=19, @Id_Veterinario=9, @Fecha='2026-07-14', @Hora='08:45', @Motivo='Control post-operatorio', @Estado_Cita='Cancelada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=45, @Id_Veterinario=8, @Fecha='2026-07-14', @Hora='09:30', @Motivo='Consulta por vomito', @Estado_Cita='Cancelada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=1, @Id_Veterinario=7, @Fecha='2026-07-15', @Hora='09:00', @Motivo='Control post-operatorio', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=33, @Id_Veterinario=5, @Fecha='2026-07-15', @Hora='14:45', @Motivo='Control post-operatorio', @Estado_Cita='Cancelada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=32, @Id_Veterinario=2, @Fecha='2026-07-16', @Hora='15:30', @Motivo='Revision de piel', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=2, @Id_Veterinario=1, @Fecha='2026-07-16', @Hora='16:15', @Motivo='Limpieza dental', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=40, @Id_Veterinario=7, @Fecha='2026-07-17', @Hora='13:15', @Motivo='Limpieza dental', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=9, @Id_Veterinario=1, @Fecha='2026-07-18', @Hora='16:30', @Motivo='Cirugia menor', @Estado_Cita='Atendida', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=3, @Id_Veterinario=3, @Fecha='2026-07-18', @Hora='16:45', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=23, @Id_Veterinario=3, @Fecha='2026-07-19', @Hora='10:15', @Motivo='Revision de oido', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=25, @Id_Veterinario=3, @Fecha='2026-07-19', @Hora='11:45', @Motivo='Control post-operatorio', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=21, @Id_Veterinario=3, @Fecha='2026-07-19', @Hora='16:30', @Motivo='Limpieza dental', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=1, @Id_Veterinario=4, @Fecha='2026-07-20', @Hora='08:45', @Motivo='Limpieza dental', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=2, @Id_Veterinario=3, @Fecha='2026-07-20', @Hora='13:45', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=47, @Id_Veterinario=10, @Fecha='2026-07-22', @Hora='10:45', @Motivo='Revision de piel', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=7, @Id_Veterinario=3, @Fecha='2026-07-22', @Hora='11:30', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CITAS @Id_Mascota=33, @Id_Veterinario=2, @Fecha='2026-07-25', @Hora='12:45', @Motivo='Revision de oido', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=5, @Fecha='2026-07-26', @Hora='08:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=16, @Id_Veterinario=2, @Fecha='2026-07-27', @Hora='07:45', @Motivo='Revision de oido', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=3, @Id_Veterinario=10, @Fecha='2026-07-28', @Hora='14:30', @Motivo='Emergencia', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=44, @Id_Veterinario=2, @Fecha='2026-07-29', @Hora='14:00', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=4, @Id_Veterinario=6, @Fecha='2026-07-30', @Hora='15:00', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Cancelada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=2, @Fecha='2026-07-31', @Hora='14:45', @Motivo='Emergencia', @Estado_Cita='Cancelada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=35, @Id_Veterinario=3, @Fecha='2026-08-01', @Hora='07:45', @Motivo='Chequeo cardiaco', @Estado_Cita='Atendida', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=4, @Id_Veterinario=9, @Fecha='2026-08-01', @Hora='09:15', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=25, @Id_Veterinario=7, @Fecha='2026-08-01', @Hora='11:15', @Motivo='Control de peso', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=23, @Id_Veterinario=9, @Fecha='2026-08-01', @Hora='12:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=9, @Id_Veterinario=6, @Fecha='2026-08-02', @Hora='08:45', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=10, @Id_Veterinario=5, @Fecha='2026-08-02', @Hora='11:00', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=1, @Fecha='2026-08-02', @Hora='11:15', @Motivo='Limpieza dental', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=9, @Fecha='2026-08-02', @Hora='13:15', @Motivo='Chequeo cardiaco', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=10, @Fecha='2026-08-03', @Hora='10:30', @Motivo='Desparasitacion', @Estado_Cita='Cancelada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=24, @Id_Veterinario=4, @Fecha='2026-08-03', @Hora='13:45', @Motivo='Limpieza dental', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=46, @Id_Veterinario=7, @Fecha='2026-08-03', @Hora='14:00', @Motivo='Control de peso', @Estado_Cita='Cancelada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=23, @Id_Veterinario=1, @Fecha='2026-08-03', @Hora='16:30', @Motivo='Consulta general', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=33, @Id_Veterinario=3, @Fecha='2026-08-04', @Hora='09:00', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=35, @Id_Veterinario=1, @Fecha='2026-08-04', @Hora='10:45', @Motivo='Vacunacion', @Estado_Cita='Cancelada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=35, @Id_Veterinario=6, @Fecha='2026-08-04', @Hora='11:30', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=26, @Id_Veterinario=1, @Fecha='2026-08-04', @Hora='14:15', @Motivo='Consulta por vomito', @Estado_Cita='Atendida', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CITAS @Id_Mascota=48, @Id_Veterinario=1, @Fecha='2026-08-05', @Hora='10:30', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=28, @Id_Veterinario=8, @Fecha='2026-08-05', @Hora='13:45', @Motivo='Control de peso', @Estado_Cita='Atendida', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=9, @Id_Veterinario=6, @Fecha='2026-08-05', @Hora='14:15', @Motivo='Cirugia menor', @Estado_Cita='Atendida', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CITAS @Id_Mascota=24, @Id_Veterinario=1, @Fecha='2026-08-06', @Hora='08:30', @Motivo='Emergencia', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=21, @Id_Veterinario=3, @Fecha='2026-08-06', @Hora='16:45', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=23, @Id_Veterinario=10, @Fecha='2026-08-07', @Hora='08:45', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=40, @Id_Veterinario=5, @Fecha='2026-08-07', @Hora='12:30', @Motivo='Chequeo cardiaco', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=21, @Id_Veterinario=2, @Fecha='2026-08-07', @Hora='16:00', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=2, @Fecha='2026-08-07', @Hora='16:30', @Motivo='Cirugia menor', @Estado_Cita='Cancelada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=29, @Id_Veterinario=3, @Fecha='2026-08-08', @Hora='09:30', @Motivo='Control post-operatorio', @Estado_Cita='Atendida', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=8, @Fecha='2026-08-08', @Hora='09:45', @Motivo='Consulta por vomito', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=5, @Fecha='2026-08-08', @Hora='11:00', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=26, @Id_Veterinario=8, @Fecha='2026-08-08', @Hora='12:45', @Motivo='Desparasitacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=6, @Fecha='2026-08-08', @Hora='13:45', @Motivo='Control post-operatorio', @Estado_Cita='Atendida', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=22, @Id_Veterinario=8, @Fecha='2026-08-09', @Hora='07:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Cancelada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=21, @Id_Veterinario=5, @Fecha='2026-08-09', @Hora='07:45', @Motivo='Control de peso', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=50, @Id_Veterinario=9, @Fecha='2026-08-09', @Hora='09:15', @Motivo='Revision de oido', @Estado_Cita='Cancelada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=7, @Id_Veterinario=1, @Fecha='2026-08-09', @Hora='09:45', @Motivo='Emergencia', @Estado_Cita='Atendida', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CITAS @Id_Mascota=26, @Id_Veterinario=1, @Fecha='2026-08-09', @Hora='10:15', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=46, @Id_Veterinario=3, @Fecha='2026-08-09', @Hora='12:30', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=10, @Fecha='2026-08-09', @Hora='14:00', @Motivo='Consulta por cojera', @Estado_Cita='Atendida', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=42, @Id_Veterinario=10, @Fecha='2026-08-09', @Hora='14:45', @Motivo='Vacunacion', @Estado_Cita='Atendida', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=44, @Id_Veterinario=8, @Fecha='2026-08-09', @Hora='16:45', @Motivo='Consulta por vomito', @Estado_Cita='Atendida', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=2, @Id_Veterinario=7, @Fecha='2026-08-09', @Hora='17:00', @Motivo='Consulta general', @Estado_Cita='Atendida', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=6, @Fecha='2026-08-10', @Hora='08:00', @Motivo='Chequeo cardiaco', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=3, @Id_Veterinario=7, @Fecha='2026-08-10', @Hora='10:15', @Motivo='Consulta por vomito', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=24, @Id_Veterinario=6, @Fecha='2026-08-10', @Hora='10:15', @Motivo='Consulta por cojera', @Estado_Cita='Pendiente', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=8, @Fecha='2026-08-10', @Hora='13:15', @Motivo='Emergencia', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=9, @Fecha='2026-08-10', @Hora='14:15', @Motivo='Chequeo cardiaco', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=4, @Id_Veterinario=10, @Fecha='2026-08-10', @Hora='14:45', @Motivo='Vacunacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=14, @Id_Veterinario=4, @Fecha='2026-08-10', @Hora='15:00', @Motivo='Consulta por vomito', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=6, @Fecha='2026-08-10', @Hora='15:30', @Motivo='Cirugia menor', @Estado_Cita='Pendiente', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=6, @Id_Veterinario=10, @Fecha='2026-08-10', @Hora='16:15', @Motivo='Consulta por vomito', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=3, @Fecha='2026-08-11', @Hora='08:15', @Motivo='Control de peso', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=12, @Id_Veterinario=5, @Fecha='2026-08-11', @Hora='09:30', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=13
EXEC SP_INSERTA_CITAS @Id_Mascota=50, @Id_Veterinario=5, @Fecha='2026-08-11', @Hora='16:00', @Motivo='Desparasitacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=35, @Id_Veterinario=7, @Fecha='2026-08-11', @Hora='16:45', @Motivo='Cirugia menor', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=1, @Fecha='2026-08-12', @Hora='10:15', @Motivo='Chequeo cardiaco', @Estado_Cita='Pendiente', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=1, @Fecha='2026-08-12', @Hora='11:00', @Motivo='Consulta por vomito', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=21, @Id_Veterinario=3, @Fecha='2026-08-13', @Hora='09:45', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=23, @Id_Veterinario=2, @Fecha='2026-08-13', @Hora='11:30', @Motivo='Emergencia', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=28, @Id_Veterinario=2, @Fecha='2026-08-13', @Hora='15:00', @Motivo='Cirugia menor', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=24, @Id_Veterinario=8, @Fecha='2026-08-14', @Hora='10:45', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=14, @Id_Veterinario=8, @Fecha='2026-08-14', @Hora='14:00', @Motivo='Desparasitacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=26, @Id_Veterinario=6, @Fecha='2026-08-15', @Hora='07:30', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=25, @Id_Veterinario=8, @Fecha='2026-08-15', @Hora='08:15', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=9, @Id_Veterinario=8, @Fecha='2026-08-15', @Hora='09:00', @Motivo='Control de peso', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=45, @Id_Veterinario=10, @Fecha='2026-08-15', @Hora='10:00', @Motivo='Consulta por cojera', @Estado_Cita='Pendiente', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=6, @Id_Veterinario=8, @Fecha='2026-08-15', @Hora='10:45', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=2, @Id_Veterinario=7, @Fecha='2026-08-15', @Hora='17:00', @Motivo='Desparasitacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=9, @Id_Veterinario=6, @Fecha='2026-08-16', @Hora='07:45', @Motivo='Consulta por cojera', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=2, @Id_Veterinario=5, @Fecha='2026-08-16', @Hora='08:00', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=17
EXEC SP_INSERTA_CITAS @Id_Mascota=3, @Id_Veterinario=5, @Fecha='2026-08-16', @Hora='08:45', @Motivo='Revision de piel', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=30, @Id_Veterinario=2, @Fecha='2026-08-16', @Hora='15:30', @Motivo='Emergencia', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=42, @Id_Veterinario=7, @Fecha='2026-08-16', @Hora='15:30', @Motivo='Revision de piel', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=26, @Id_Veterinario=7, @Fecha='2026-08-17', @Hora='07:30', @Motivo='Cirugia menor', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=46, @Id_Veterinario=6, @Fecha='2026-08-17', @Hora='09:45', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=11
EXEC SP_INSERTA_CITAS @Id_Mascota=16, @Id_Veterinario=8, @Fecha='2026-08-17', @Hora='10:15', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=45, @Id_Veterinario=8, @Fecha='2026-08-17', @Hora='11:15', @Motivo='Control post-operatorio', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=3, @Fecha='2026-08-17', @Hora='11:45', @Motivo='Emergencia', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=18, @Id_Veterinario=6, @Fecha='2026-08-17', @Hora='15:00', @Motivo='Vacunacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=1, @Fecha='2026-08-17', @Hora='15:30', @Motivo='Control de peso', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=11, @Id_Veterinario=9, @Fecha='2026-08-17', @Hora='15:30', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=25, @Id_Veterinario=10, @Fecha='2026-08-17', @Hora='15:45', @Motivo='Consulta por vomito', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=11, @Id_Veterinario=9, @Fecha='2026-08-17', @Hora='16:30', @Motivo='Consulta por cojera', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=14, @Id_Veterinario=1, @Fecha='2026-08-17', @Hora='17:00', @Motivo='Consulta por cojera', @Estado_Cita='Confirmada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=33, @Id_Veterinario=8, @Fecha='2026-08-18', @Hora='08:00', @Motivo='Vacunacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CITAS @Id_Mascota=11, @Id_Veterinario=2, @Fecha='2026-08-18', @Hora='08:30', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=31, @Id_Veterinario=1, @Fecha='2026-08-18', @Hora='11:30', @Motivo='Consulta por cojera', @Estado_Cita='Confirmada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=9, @Fecha='2026-08-18', @Hora='16:30', @Motivo='Revision de piel', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=7, @Fecha='2026-08-19', @Hora='08:45', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=30, @Id_Veterinario=3, @Fecha='2026-08-19', @Hora='08:45', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=3, @Fecha='2026-08-19', @Hora='10:30', @Motivo='Consulta por vomito', @Estado_Cita='Pendiente', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=10, @Fecha='2026-08-19', @Hora='11:15', @Motivo='Vacunacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=35, @Id_Veterinario=4, @Fecha='2026-08-19', @Hora='14:30', @Motivo='Limpieza dental', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=8, @Fecha='2026-08-20', @Hora='14:45', @Motivo='Chequeo cardiaco', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=32, @Id_Veterinario=3, @Fecha='2026-08-20', @Hora='17:00', @Motivo='Consulta por cojera', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=42, @Id_Veterinario=1, @Fecha='2026-08-21', @Hora='11:30', @Motivo='Cirugia menor', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=19, @Id_Veterinario=10, @Fecha='2026-08-22', @Hora='09:45', @Motivo='Control post-operatorio', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=8, @Fecha='2026-08-22', @Hora='10:00', @Motivo='Revision de piel', @Estado_Cita='Pendiente', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CITAS @Id_Mascota=44, @Id_Veterinario=10, @Fecha='2026-08-22', @Hora='10:15', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=48, @Id_Veterinario=6, @Fecha='2026-08-22', @Hora='10:15', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=7, @Id_Veterinario=2, @Fecha='2026-08-22', @Hora='11:00', @Motivo='Vacunacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=1, @Id_Veterinario=3, @Fecha='2026-08-22', @Hora='16:30', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=2, @Id_Veterinario=9, @Fecha='2026-08-23', @Hora='10:45', @Motivo='Cirugia menor', @Estado_Cita='Pendiente', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CITAS @Id_Mascota=15, @Id_Veterinario=7, @Fecha='2026-08-23', @Hora='12:45', @Motivo='Desparasitacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=50, @Id_Veterinario=8, @Fecha='2026-08-23', @Hora='15:15', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CITAS @Id_Mascota=27, @Id_Veterinario=10, @Fecha='2026-08-23', @Hora='15:45', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=22, @Id_Veterinario=10, @Fecha='2026-08-23', @Hora='16:45', @Motivo='Control post-operatorio', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=9, @Fecha='2026-08-24', @Hora='08:00', @Motivo='Consulta general', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=10, @Fecha='2026-08-24', @Hora='08:00', @Motivo='Control de peso', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=7, @Fecha='2026-08-24', @Hora='09:30', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CITAS @Id_Mascota=45, @Id_Veterinario=7, @Fecha='2026-08-24', @Hora='11:30', @Motivo='Emergencia', @Estado_Cita='Confirmada', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=33, @Id_Veterinario=10, @Fecha='2026-08-24', @Hora='13:45', @Motivo='Vacunacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=14
EXEC SP_INSERTA_CITAS @Id_Mascota=15, @Id_Veterinario=7, @Fecha='2026-08-24', @Hora='16:45', @Motivo='Vacunacion', @Estado_Cita='Confirmada', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CITAS @Id_Mascota=24, @Id_Veterinario=4, @Fecha='2026-08-25', @Hora='07:45', @Motivo='Consulta por vomito', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=28, @Id_Veterinario=9, @Fecha='2026-08-25', @Hora='14:15', @Motivo='Revision de piel', @Estado_Cita='Pendiente', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=4, @Fecha='2026-08-25', @Hora='14:15', @Motivo='Emergencia', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=12, @Id_Veterinario=4, @Fecha='2026-08-25', @Hora='16:00', @Motivo='Revision de piel', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=6, @Fecha='2026-08-26', @Hora='07:30', @Motivo='Consulta por cojera', @Estado_Cita='Pendiente', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=39, @Id_Veterinario=8, @Fecha='2026-08-26', @Hora='13:45', @Motivo='Chequeo cardiaco', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=28, @Id_Veterinario=8, @Fecha='2026-08-27', @Hora='08:30', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=7, @Id_Veterinario=7, @Fecha='2026-08-27', @Hora='09:00', @Motivo='Vacunacion', @Estado_Cita='Pendiente', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=39, @Id_Veterinario=6, @Fecha='2026-08-27', @Hora='10:15', @Motivo='Consulta por cojera', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=7, @Id_Veterinario=8, @Fecha='2026-08-27', @Hora='17:00', @Motivo='Control de peso', @Estado_Cita='Pendiente', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CITAS @Id_Mascota=27, @Id_Veterinario=1, @Fecha='2026-08-28', @Hora='10:15', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=39, @Id_Veterinario=3, @Fecha='2026-08-28', @Hora='12:30', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=16, @Id_Veterinario=9, @Fecha='2026-08-28', @Hora='15:00', @Motivo='Consulta por cojera', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=6, @Fecha='2026-08-29', @Hora='08:30', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=29, @Id_Veterinario=10, @Fecha='2026-08-29', @Hora='10:00', @Motivo='Emergencia', @Estado_Cita='Pendiente', @IdUsuarioGlobal=2
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=10, @Fecha='2026-08-29', @Hora='10:15', @Motivo='Consulta por vomito', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=17, @Id_Veterinario=10, @Fecha='2026-08-29', @Hora='12:45', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=34, @Id_Veterinario=5, @Fecha='2026-08-29', @Hora='15:30', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=16, @Id_Veterinario=10, @Fecha='2026-08-30', @Hora='07:30', @Motivo='Cirugia menor', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=23, @Id_Veterinario=7, @Fecha='2026-08-30', @Hora='07:30', @Motivo='Control de peso', @Estado_Cita='Pendiente', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=7, @Fecha='2026-08-30', @Hora='11:30', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=43, @Id_Veterinario=2, @Fecha='2026-08-30', @Hora='13:15', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=1, @Id_Veterinario=8, @Fecha='2026-08-30', @Hora='14:00', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=24, @Id_Veterinario=2, @Fecha='2026-08-30', @Hora='15:00', @Motivo='Control de peso', @Estado_Cita='Confirmada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=35, @Id_Veterinario=5, @Fecha='2026-08-30', @Hora='16:45', @Motivo='Control de peso', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=40, @Id_Veterinario=6, @Fecha='2026-08-31', @Hora='16:45', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=7, @Id_Veterinario=2, @Fecha='2026-09-03', @Hora='08:30', @Motivo='Revision de piel', @Estado_Cita='Pendiente', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=13, @Id_Veterinario=8, @Fecha='2026-09-06', @Hora='08:15', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=1, @Fecha='2026-09-06', @Hora='12:00', @Motivo='Control post-operatorio', @Estado_Cita='Pendiente', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CITAS @Id_Mascota=39, @Id_Veterinario=3, @Fecha='2026-09-07', @Hora='14:30', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=29, @Id_Veterinario=8, @Fecha='2026-09-08', @Hora='09:45', @Motivo='Control de peso', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=13, @Id_Veterinario=7, @Fecha='2026-09-08', @Hora='11:45', @Motivo='Consulta general', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=24, @Id_Veterinario=1, @Fecha='2026-09-11', @Hora='08:45', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=13, @Id_Veterinario=2, @Fecha='2026-09-11', @Hora='15:30', @Motivo='Control post-operatorio', @Estado_Cita='Pendiente', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=5, @Id_Veterinario=9, @Fecha='2026-09-14', @Hora='11:00', @Motivo='Limpieza dental', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=4, @Fecha='2026-09-20', @Hora='10:15', @Motivo='Emergencia', @Estado_Cita='Pendiente', @IdUsuarioGlobal=5
EXEC SP_INSERTA_CITAS @Id_Mascota=4, @Id_Veterinario=9, @Fecha='2026-09-21', @Hora='17:00', @Motivo='Emergencia', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=20, @Id_Veterinario=1, @Fecha='2026-09-22', @Hora='09:45', @Motivo='Revision de oido', @Estado_Cita='Pendiente', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=31, @Id_Veterinario=2, @Fecha='2026-09-25', @Hora='12:45', @Motivo='Revision de oido', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=49, @Id_Veterinario=5, @Fecha='2026-09-25', @Hora='15:00', @Motivo='Consulta por cojera', @Estado_Cita='Confirmada', @IdUsuarioGlobal=3
EXEC SP_INSERTA_CITAS @Id_Mascota=13, @Id_Veterinario=6, @Fecha='2026-09-27', @Hora='07:45', @Motivo='Chequeo cardiaco', @Estado_Cita='Pendiente', @IdUsuarioGlobal=1
EXEC SP_INSERTA_CITAS @Id_Mascota=35, @Id_Veterinario=6, @Fecha='2026-09-29', @Hora='11:00', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Confirmada', @IdUsuarioGlobal=7
EXEC SP_INSERTA_CITAS @Id_Mascota=45, @Id_Veterinario=8, @Fecha='2026-09-29', @Hora='15:00', @Motivo='Aplicacion de vacuna anual', @Estado_Cita='Confirmada', @IdUsuarioGlobal=6
EXEC SP_INSERTA_CITAS @Id_Mascota=41, @Id_Veterinario=2, @Fecha='2026-09-30', @Hora='07:45', @Motivo='Control post-operatorio', @Estado_Cita='Confirmada', @IdUsuarioGlobal=4
EXEC SP_INSERTA_CITAS @Id_Mascota=36, @Id_Veterinario=5, @Fecha='2026-09-30', @Hora='16:30', @Motivo='Emergencia', @Estado_Cita='Pendiente', @IdUsuarioGlobal=3
GO

-- ============================================================
-- CONSULTAS (via SP_INSERTA_CONSULTAS, una por cada cita 'Atendida')
-- @IdUsuarioGlobal = usuario del PROPIO veterinario que atendio la cita
-- (ej. si Ana Mora atendio, la consulta queda a nombre de 'dra.mora'),
-- para que Auditoria se vea como un sistema realmente usado por el equipo.
-- ============================================================
EXEC SP_INSERTA_CONSULTAS @Id_Cita=1, @Diagnostico='Sin hallazgos relevantes', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CONSULTAS @Id_Cita=2, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=3, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CONSULTAS @Id_Cita=5, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=6, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=14
EXEC SP_INSERTA_CONSULTAS @Id_Cita=7, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=17
EXEC SP_INSERTA_CONSULTAS @Id_Cita=9, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CONSULTAS @Id_Cita=10, @Diagnostico='Conjuntivitis', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CONSULTAS @Id_Cita=11, @Diagnostico='Conjuntivitis', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=12, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CONSULTAS @Id_Cita=13, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CONSULTAS @Id_Cita=15, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=17, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CONSULTAS @Id_Cita=18, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=13
EXEC SP_INSERTA_CONSULTAS @Id_Cita=19, @Diagnostico='Sin hallazgos relevantes', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=22, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=14
EXEC SP_INSERTA_CONSULTAS @Id_Cita=24, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=25, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=26, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=14
EXEC SP_INSERTA_CONSULTAS @Id_Cita=27, @Diagnostico='Conjuntivitis', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=28, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=29, @Diagnostico='Otitis leve', @Tratamiento='Aplicacion de vacuna y desparasitante', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=30, @Diagnostico='Sin hallazgos relevantes', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=31, @Diagnostico='Sin hallazgos relevantes', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=32, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=11
EXEC SP_INSERTA_CONSULTAS @Id_Cita=33, @Diagnostico='Otitis leve', @Tratamiento='Aplicacion de vacuna y desparasitante', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=34, @Diagnostico='Otitis leve', @Tratamiento='Aplicacion de vacuna y desparasitante', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=17
EXEC SP_INSERTA_CONSULTAS @Id_Cita=35, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=36, @Diagnostico='Sobrepeso moderado', @Tratamiento='Control quirurgico en 15 dias', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=37, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CONSULTAS @Id_Cita=38, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=39, @Diagnostico='Conjuntivitis', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=17
EXEC SP_INSERTA_CONSULTAS @Id_Cita=40, @Diagnostico='Sin hallazgos relevantes', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=43, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=44, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CONSULTAS @Id_Cita=45, @Diagnostico='Sobrepeso moderado', @Tratamiento='Control quirurgico en 15 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=14
EXEC SP_INSERTA_CONSULTAS @Id_Cita=46, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CONSULTAS @Id_Cita=47, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=13
EXEC SP_INSERTA_CONSULTAS @Id_Cita=48, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CONSULTAS @Id_Cita=49, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=50, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=16
EXEC SP_INSERTA_CONSULTAS @Id_Cita=52, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=11
EXEC SP_INSERTA_CONSULTAS @Id_Cita=54, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=55, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=57, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=13
EXEC SP_INSERTA_CONSULTAS @Id_Cita=58, @Diagnostico='Conjuntivitis', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=59, @Diagnostico='Sin hallazgos relevantes', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=60, @Diagnostico='Conjuntivitis', @Tratamiento='Se receta antibiotico por 7 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CONSULTAS @Id_Cita=61, @Diagnostico='Sin hallazgos relevantes', @Tratamiento='Reposo y analgesico por 5 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=13
EXEC SP_INSERTA_CONSULTAS @Id_Cita=62, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=63, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=64, @Diagnostico='Sobrepeso moderado', @Tratamiento='Control quirurgico en 15 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=17
EXEC SP_INSERTA_CONSULTAS @Id_Cita=65, @Diagnostico='Sobrepeso moderado', @Tratamiento='Control quirurgico en 15 dias', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CONSULTAS @Id_Cita=66, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=9
EXEC SP_INSERTA_CONSULTAS @Id_Cita=68, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=69, @Diagnostico='Sobrepeso moderado', @Tratamiento='Control quirurgico en 15 dias', @Observaciones='Se indica traer examenes de laboratorio en proxima cita', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CONSULTAS @Id_Cita=70, @Diagnostico='Parasitos intestinales', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CONSULTAS @Id_Cita=71, @Diagnostico='Infeccion respiratoria leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CONSULTAS @Id_Cita=72, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Propietario reporta mejoria desde ultima consulta', @IdUsuarioGlobal=13
EXEC SP_INSERTA_CONSULTAS @Id_Cita=74, @Diagnostico='Otitis leve', @Tratamiento='Aplicacion de vacuna y desparasitante', @Observaciones='Paciente colaborador, sin complicaciones', @IdUsuarioGlobal=12
EXEC SP_INSERTA_CONSULTAS @Id_Cita=76, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=77, @Diagnostico='Deshidratacion leve', @Tratamiento='Suero y control en 48 horas', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=8
EXEC SP_INSERTA_CONSULTAS @Id_Cita=78, @Diagnostico='Fractura en recuperacion', @Tratamiento='Cambio de dieta y control en 30 dias', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=10
EXEC SP_INSERTA_CONSULTAS @Id_Cita=79, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=17
EXEC SP_INSERTA_CONSULTAS @Id_Cita=80, @Diagnostico='Otitis leve', @Tratamiento='Aplicacion de vacuna y desparasitante', @Observaciones='Se recomienda seguimiento en proxima visita', @IdUsuarioGlobal=17
EXEC SP_INSERTA_CONSULTAS @Id_Cita=81, @Diagnostico='Gingivitis', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=15
EXEC SP_INSERTA_CONSULTAS @Id_Cita=82, @Diagnostico='Dermatitis alergica', @Tratamiento='Limpieza y antiinflamatorio topico', @Observaciones='Sin observaciones adicionales', @IdUsuarioGlobal=14
GO

-- ============================================================
-- VERIFICACION
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

-- Chequeo rapido de que Auditoria ya no es solo el admin:
SELECT U.Nombre_Usuario, COUNT(*) AS Acciones
FROM Auditoria A
INNER JOIN Usuarios U ON U.Id_Usuario = A.Id_Usuario
GROUP BY U.Nombre_Usuario
ORDER BY Acciones DESC
GO

-- Confirmar los picos del 9, 10 y 17 de agosto:
SELECT Fecha, COUNT(*) AS Cantidad FROM Citas WHERE Fecha BETWEEN '2026-08-01' AND '2026-08-31' GROUP BY Fecha ORDER BY Fecha

-- Cantidades esperadas SOLO SI la base de datos estaba COMPLETAMENTE VACIA
-- Roles: 3 | Tipos_Identificacion: 4 | Especialidades: 6 | Especies: 5
-- Razas: 20 | Propietarios: 30 | Usuarios: 17
-- Veterinarios: 10 | Mascotas: 50 | Citas: 198
-- Consultas: 67