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