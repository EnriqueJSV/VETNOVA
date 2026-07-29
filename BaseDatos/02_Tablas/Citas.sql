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