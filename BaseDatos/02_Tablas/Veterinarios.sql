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