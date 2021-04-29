--DML


USE SENAI_HROADS_TARDE;
GO
-- Exercício 3

INSERT INTO TipoDeHabilidade 
VALUES			('Ataque'),
				('Defesa'),
				('Cura'),
				('Magia');
GO

INSERT INTO Habilidades	(IdTipoDeHabilidade , Habilidade)
VALUES					(1					, 'Lança Mortal'),
						(2					, 'Escudo Supremo'),
						(3					, 'Recuperar Vida');
GO

INSERT INTO Classes (IdHabilidade , Classe)
VALUES				(1   		  , 'Bárbaro'),
					(2		      , 'Cruzado'),
					(1		      , 'Caçadora de Demônios'),
					(3   		  , 'Monge'),
					(null	      , 'Necromante'),
					(3		      , 'Feiticeiro'),
					(null	      , 'Arcanista')
GO

INSERT INTO Personagem (IdClasse, NomePersonagem, CapacidadeVida, CapacidadeMana, DataCriacao, DataAtualização)
VALUES				   (1      , 'DeuBug'      , 100           , 80            , '20190118' , '20210426'),
					   (2      , 'BitBug'      , 70            , 100           , '20160317' , '20210426'),
					   (3      , 'Fer8'        , 75            , 60            , '20180318' , '20210426')
GO

INSERT INTO TipoUsuario
VALUES		('Admin'),
			('Jogador')
GO

INSERT INTO Usuario (IdTipoUsuario, Email, Senha)
VALUES				(1,'admin@admin.com','admin'),
					(2,'Jogador@gmail.com','Jogador')
					
