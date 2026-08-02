/*
  VETNOVA - SCRIPT 1 DE 4: CREACION DE BASE DE DATOS Y TABLAS
  ------------------------------------------------------------
  Instrucciones:
  1) Abrir este archivo en SQL Server Management Studio (SSMS)
  2) Presionar Ejecutar - se ejecuta todo automaticamente
  3) Al terminar, la base de datos VetNova ya existe con sus 12 tablas

  IMPORTANTE: Ejecutar este script ANTES que el de procedimientos almacenados.
*/

CREATE DATABASE VetNova
go

USE VetNova
go
GO

-------------------------------------------------------------
-- TABLA: Roles
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Roles(
	Id_Rol		int				IDENTITY(1,1)		NOT NULL,
	Rol			VARCHAR(50)		NOT NULL,
	Estado		CHAR(1)			NOT NULL,

	CONSTRAINT PK_Roles PRIMARY KEY(Id_Rol)
)
GO

-------------------------------------------------------------
-- TABLA: Tipos_Identificacion
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Tipos_Identificacion(

	Id_Tipo_Identificacion		INT				IDENTITY(1,1)		NOT NULL,
	Tipo_Identificacion			VARCHAR(50)		NOT NULL,
	Estado						CHAR(1)			NOT NULL,

	CONSTRAINT PK_Tipos_Identificacion PRIMARY KEY(Id_Tipo_Identificacion)
)
GO

-------------------------------------------------------------
-- TABLA: Especialidades
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Especialidades(
	Id_Especialidad		int				IDENTITY(1,1)		NOT NULL,
	Especialidad		VARCHAR(50)		NOT NULL,
	Estado				CHAR(1)			NOT NULL,

	CONSTRAINT PK_Especialidades PRIMARY KEY(Id_Especialidad)
)
GO

-------------------------------------------------------------
-- TABLA: Especies
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Especies(

	Id_Especie		INT				IDENTITY(1,1)		NOT NULL,
	Especie			VARCHAR(100)	NOT NULL,
	Estado			CHAR(1)			NOT NULL,

	CONSTRAINT PK_Especies PRIMARY KEY(Id_Especie)
)
GO

-------------------------------------------------------------
-- TABLA: Razas
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Razas(

	Id_Raza			INT				IDENTITY(1,1)		NOT NULL,
	Id_Especie		INT				NOT NULL,
	Raza			VARCHAR(100)	NOT NULL,
	Estado			CHAR(1)			NOT NULL,

	CONSTRAINT PK_Razas PRIMARY KEY(Id_Raza),

	CONSTRAINT FK_Razas_Especies
        FOREIGN KEY (Id_Especie)
        REFERENCES Especies(Id_Especie)
)
GO

-------------------------------------------------------------
-- TABLA: Propietarios
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Propietarios(
	
	Id_Propietario              INT             IDENTITY(1,1)       NOT NULL,
    Id_Tipo_Identificacion      INT             NOT NULL,
    Nombre                      VARCHAR(100)    NOT NULL,
    Apellido1                   VARCHAR(100)    NOT NULL,
    Apellido2                   VARCHAR(100)    NOT NULL,
    Telefono                    VARCHAR(100)    NOT NULL,
    Email                       VARCHAR(100)    NOT NULL,
    Direccion                   VARCHAR(100)    NOT NULL,
    Estado                      CHAR(1)         NOT NULL,

    CONSTRAINT PK_Propietarios PRIMARY KEY (Id_Propietario),

    CONSTRAINT FK_Propietarios_Tipos_Identificacion
        FOREIGN KEY (Id_Tipo_Identificacion)
        REFERENCES Tipos_Identificacion(Id_Tipo_Identificacion)
)
GO

-------------------------------------------------------------
-- TABLA: Usuarios
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Usuarios(

    Id_Usuario          INT             IDENTITY(1,1)       NOT NULL,
    Id_Rol              INT             NOT NULL,
    Nombre_Usuario      VARCHAR(100)    NOT NULL,
    Email               VARCHAR(100)    NOT NULL,
    Contrasena          VARCHAR(100)    NOT NULL,
    Estado              CHAR(1)         NOT NULL,

    CONSTRAINT PK_Usuarios PRIMARY KEY (Id_Usuario),

    CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (Id_Rol)
        REFERENCES Roles(Id_Rol)
)
GO

-------------------------------------------------------------
-- TABLA: Veterinarios
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Veterinarios(
	
	Id_Veterinario              INT             IDENTITY(1,1)       NOT NULL,
    Id_Tipo_Identificacion      INT             NOT NULL,
    Identificacion              VARCHAR(50)     NOT NULL,
    Nombre                      VARCHAR(100)    NOT NULL,
    Apellido1                   VARCHAR(100)    NOT NULL,
    Apellido2                   VARCHAR(100)    NOT NULL,
    Id_Especialidad             INT             NOT NULL,
    Telefono                    VARCHAR(100)    NOT NULL,
    Email                       VARCHAR(100)    NOT NULL,
    Estado                      CHAR(1)         NOT NULL,

    CONSTRAINT PK_Veterinarios PRIMARY KEY (Id_Veterinario),

    CONSTRAINT FK_Veterinarios_Tipos_Identificacion
        FOREIGN KEY (Id_Tipo_Identificacion)
        REFERENCES Tipos_Identificacion(Id_Tipo_Identificacion),

    CONSTRAINT FK_Veterinarios_Especialidades
        FOREIGN KEY (Id_Especialidad)
        REFERENCES Especialidades(Id_Especialidad)
)
GO

-------------------------------------------------------------
-- TABLA: Mascotas
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Mascotas(
	
	Id_Mascota                  INT             IDENTITY(1,1)       NOT NULL,
    Id_Propietario              INT             NOT NULL,
    Id_Raza                     INT             NOT NULL,
    Nombre                      VARCHAR(100)    NOT NULL,
    Sexo                        VARCHAR(30)     NOT NULL,
    Fecha_Nacimiento            DATETIME        NOT NULL,
    Peso                        VARCHAR(30)     NOT NULL,
    Color                       VARCHAR(30)     NOT NULL,
    Estado                      CHAR(1)         NOT NULL,

    CONSTRAINT PK_Mascotas PRIMARY KEY (Id_Mascota),

    CONSTRAINT FK_Mascotas_Propietarios
        FOREIGN KEY (Id_Propietario)
        REFERENCES Propietarios(Id_Propietario),

    CONSTRAINT FK_Mascotas_Razas
        FOREIGN KEY (Id_Raza)
        REFERENCES Razas(Id_Raza)
)
GO

-------------------------------------------------------------
-- TABLA: Auditoria
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Auditoria(

    Id_Auditoria        INT             IDENTITY(1,1)       NOT NULL,
    Id_Usuario          INT             NOT NULL,
    Accion              CHAR(1)         NOT NULL,
    Descripcion         VARCHAR(500)    NOT NULL,
    Fecha               DATETIME        NOT NULL,
    

    CONSTRAINT PK_Auditoria PRIMARY KEY (Id_Auditoria),

    CONSTRAINT FK_Auditoria_Usuarios
        FOREIGN KEY (Id_Usuario)
        REFERENCES Usuarios(Id_Usuario)
)
GO

-------------------------------------------------------------
-- TABLA: Citas
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Citas(
	
	Id_Cita                     INT             IDENTITY(1,1)       NOT NULL,
    Id_Mascota                  INT             NOT NULL,
    Id_Veterinario              INT             NOT NULL,
    Fecha                       DATE            NOT NULL,
    Hora                        TIME            NOT NULL,
    Motivo                      VARCHAR(500)    NOT NULL,
    Estado_Cita                 VARCHAR(50)     NOT NULL,

    CONSTRAINT PK_Citas PRIMARY KEY (Id_Cita),

    CONSTRAINT FK_Citas_Mascotas
        FOREIGN KEY (Id_Mascota)
        REFERENCES Mascotas(Id_Mascota),

    CONSTRAINT FK_Citas_Veterinarios
        FOREIGN KEY (Id_Veterinario)
        REFERENCES Veterinarios(Id_Veterinario)
)
GO

-------------------------------------------------------------
-- TABLA: Consultas
-------------------------------------------------------------
USE VetNova
go

CREATE TABLE Consultas(
	
	Id_Consulta                 INT             IDENTITY(1,1)       NOT NULL,
    Id_Cita                     INT             NOT NULL,
    Diagnostico                 VARCHAR(500)    NOT NULL,
    Tratamiento                 VARCHAR(500)    NOT NULL,
    Observaciones               VARCHAR(500)    NOT NULL,

    CONSTRAINT PK_Consultas PRIMARY KEY (Id_Consulta),

    CONSTRAINT FK_Consultas_Citas
        FOREIGN KEY (Id_Cita)
        REFERENCES Citas(Id_Cita)
)
GO