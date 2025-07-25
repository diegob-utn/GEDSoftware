USE GEDSoftware;
Go
-- Tabla: Desarrolladores
CREATE TABLE Desarrolladores (
                                 Id INT PRIMARY KEY IDENTITY(1,1),
                                 Nombre NVARCHAR(100) NOT NULL,
                                 Correo NVARCHAR(150) NOT NULL,
                                 Telefono NVARCHAR(20)
);

-- Tabla: Proyectos
CREATE TABLE Proyectos (
                           Id INT PRIMARY KEY IDENTITY(1,1),
                           nombre NVARCHAR(100),
                           descripcion NVARCHAR(MAX),
                           fechacreacion DATETIME,
                           fechalimite DATETIME,
                           prioridad NVARCHAR(50), -- Usamos string
                           estado NVARCHAR(50),
                           desarrolladorId INT,
                           FOREIGN KEY (desarrolladorId) REFERENCES Desarrolladores(Id)
);

-- Tabla: Tareas
CREATE TABLE Tareas (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        nombre NVARCHAR(100),
                        descripcion NVARCHAR(MAX),
                        fechacreacion DATETIME,
                        fechalimite DATETIME,
                        prioridad NVARCHAR(50),
                        estado NVARCHAR(50),
                        desarrolladorId INT,
                        proyectoId INT,
                        FOREIGN KEY (desarrolladorId) REFERENCES Desarrolladores(Id),
                        FOREIGN KEY (proyectoId) REFERENCES Proyectos(Id)
);
