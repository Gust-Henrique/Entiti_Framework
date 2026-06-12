CREATE DATABASE IF NOT EXISTS escola
  CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE escola;

-- Tutorial v3
CREATE TABLE IF NOT EXISTS Estudantes (
    Id    INT      NOT NULL AUTO_INCREMENT,
    Nome  LONGTEXT NULL,
    Idade INT      NOT NULL DEFAULT 0,
    CONSTRAINT PK_Estudantes PRIMARY KEY (Id)
);

-- Atividade 1
CREATE TABLE IF NOT EXISTS Produtos (
    Id    INT    NOT NULL AUTO_INCREMENT,
    Nome  LONGTEXT NULL,
    Preco DOUBLE NOT NULL DEFAULT 0,
    CONSTRAINT PK_Produtos PRIMARY KEY (Id)
);

-- Atividade 2
CREATE TABLE IF NOT EXISTS Clientes (
    Id    INT      NOT NULL AUTO_INCREMENT,
    Nome  LONGTEXT NULL,
    Email LONGTEXT NULL,
    CONSTRAINT PK_Clientes PRIMARY KEY (Id)
);

-- Atividade 3
CREATE TABLE IF NOT EXISTS Cursos (
    Id           INT      NOT NULL AUTO_INCREMENT,
    Nome         LONGTEXT NULL,
    CargaHoraria INT      NOT NULL DEFAULT 0,
    ProfessorId  INT      NULL,        
    CONSTRAINT PK_Cursos PRIMARY KEY (Id)
);

-- Atividade 4
CREATE TABLE IF NOT EXISTS Estoque (
    Id         INT      NOT NULL AUTO_INCREMENT,
    Nome       LONGTEXT NULL,
    Quantidade INT      NOT NULL DEFAULT 0,
    CONSTRAINT PK_Estoque PRIMARY KEY (Id)
);


-- Atividade 5: Professor (pai de Curso)
CREATE TABLE IF NOT EXISTS Professores (
    Id   INT      NOT NULL AUTO_INCREMENT,
    Nome LONGTEXT NULL,
    CONSTRAINT PK_Professores PRIMARY KEY (Id)
);

ALTER TABLE Cursos
    ADD CONSTRAINT FK_Cursos_Professores
    FOREIGN KEY (ProfessorId) REFERENCES Professores(Id);

-- Atividade 6: Pedido (pai de ItemPedido)
CREATE TABLE IF NOT EXISTS Pedidos (
    Id   INT      NOT NULL AUTO_INCREMENT,
    Data DATETIME NOT NULL,
    CONSTRAINT PK_Pedidos PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS ItensPedidos (
    Id         INT      NOT NULL AUTO_INCREMENT,
    Produto    LONGTEXT NULL,
    Quantidade INT      NOT NULL DEFAULT 0,
    PedidoId   INT      NOT NULL,
    CONSTRAINT PK_ItensPedidos PRIMARY KEY (Id),
    CONSTRAINT FK_ItensPedidos_Pedidos
        FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
);

USE escola;

INSERT INTO Estudantes (Nome, Idade) VALUES ('João Silva', 22), ('Maria Oliveira', 25);

INSERT INTO Produtos (Nome, Preco) VALUES
    ('Notebook', 3500.00), ('Mouse', 150.00), ('Teclado', 250.00);

INSERT INTO Clientes (Nome, Email) VALUES
    ('Ana Silva', 'ana@email.com'), ('Carla Lima', 'carla@loja.com');

INSERT INTO Professores (Nome) VALUES ('Carlos Silva');

INSERT INTO Cursos (Nome, CargaHoraria, ProfessorId) VALUES
    ('C# Básico',        40, 1),
    ('Entity Framework', 30, 1),
    ('ASP.NET Core',     60, 1),
    ('SQL para Devs',    20, 1),
    ('Docker Básico',    15, NULL);

INSERT INTO Pedidos (Data) VALUES (NOW());

INSERT INTO ItensPedidos (Produto, Quantidade, PedidoId) VALUES
    ('Notebook', 1, 1),
    ('Mouse',    2, 1),
    ('Teclado',  1, 1);

INSERT INTO Estoque (Nome, Quantidade) VALUES
    ('Cabo USB', 10), ('Adaptador', 3), ('Case HD', 7);


