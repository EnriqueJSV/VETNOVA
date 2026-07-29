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