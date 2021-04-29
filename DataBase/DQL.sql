-- DQL 

use SENAI_HROADS_TARDE

SELECT	Habilidades.IdHabilidade, Habilidades.Habilidade,
		Habilidades.IdHabilidade, TipoDeHabilidade.NomeTipo FROM Habilidades
INNER JOIN TipoDeHabilidade
ON Habilidades.IdHabilidade = TipoDeHabilidade.IdTipoDeHabilidade;

SELECT * FROM Usuario;