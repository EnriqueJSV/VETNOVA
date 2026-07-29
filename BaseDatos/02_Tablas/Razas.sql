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