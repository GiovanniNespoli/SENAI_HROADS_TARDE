--DDL

--Exercício 1
CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO

--Exercício 2
CREATE TABLE TipoDeHabilidade(

	IdTipoDeHabilidade	INT PRIMARY KEY IDENTITY,
	NomeTipo			VARCHAR(100) NOT NULL,

);
GO

CREATE TABLE Habilidades(

	IdHabilidade		INT PRIMARY KEY IDENTITY,
	IdTipoDeHabilidade	INT FOREIGN KEY REFERENCES TipoDeHabilidade(IdTipoDeHabilidade),
	Habilidade				VARCHAR(100) NOT NULL,

);
GO
CREATE TABLE Classes(
	
	IdClasse			INT PRIMARY KEY IDENTITY,
	IdHabilidade		INT FOREIGN KEY REFERENCES Habilidades(IdHabilidade),
	Classe			VARCHAR(100) NOT NULL,

);
GO

--CREATE TABLE ClassesHabilidades(
	--IdClasse		  INT FOREIGN KEY REFERENCES Classes(IdClasse),
	--IdHabilidade      INT FOREIGN KEY REFERENCES Habilidades(IdHabilidade)
--);
--GO

CREATE TABLE Personagem(
	
	IdPersonagem		INT PRIMARY KEY IDENTITY,
	IdClasse			INT FOREIGN KEY REFERENCES Classes(IdClasse),

	NomePersonagem		VARCHAR(100) NOT NULL,
	CapacidadeVida		INT NOT NULL,
	CapacidadeMana		INT NOT NULL,
	DataCriacao			DATE NOT NULL,
	DataAtualização		DATE NOT NULL,

);
GO

CREATE TABLE TipoUsuario(

	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	TipoUsuario		VARCHAR(250) NOT NULL,

);
GO

CREATE TABLE Usuario(

	IdUsuario		INT PRIMARY KEY IDENTITY,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	Email			VARCHAR(250) UNIQUE NOT NULL,
	Senha			VARCHAR(250) NOT NULL,

);
GO