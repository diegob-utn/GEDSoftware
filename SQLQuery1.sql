USE GEDSoftware;

CREATE TABLE Tareas(
                       Id INT PRIMARY KEY,
                       nombre VARCHAR(100),
                       descripcion VARCHAR(100),
                       fechacreacion DATETIME DEFAULT GETDATE(),
                       fechalimite DATETIME DEFAULT GETDATE(),
                       estado VARCHAR(20),
                       FOREIGN KEY (ProyectoId) REFERENCES Proyectos(ProyectoID)
)
