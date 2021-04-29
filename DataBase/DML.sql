--DML


USE SENAI_HROADS_TARDE;
GO
-- Exerc�cio 3

INSERT INTO TipoDeHabilidade 
VALUES			('Ataque'),
				('Defesa'),
				('Cura'),
				('Magia');
GO

INSERT INTO Habilidades	(IdTipoDeHabilidade , Habilidade)
VALUES					(1					, 'Lan�a Mortal'),
						(2					, 'Escudo Supremo'),
						(3					, 'Recuperar Vida');
GO

INSERT INTO Classes (IdHabilidade , Classe)
VALUES				(1   		  , 'B�rbaro'),
					(2		      , 'Cruzado'),
					(1		      , 'Ca�adora de Dem�nios'),
					(3   		  , 'Monge'),
					(null	      , 'Necromante'),
					(3		      , 'Feiticeiro'),
					(null	      , 'Arcanista')
GO

INSERT INTO Personagem (IdClasse, NomePersonagem, CapacidadeVida, CapacidadeMana, DataCriacao, DataAtualiza��o)
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
					
