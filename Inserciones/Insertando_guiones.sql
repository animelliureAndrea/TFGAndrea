USE [tfgCinPadd]
GO

INSERT INTO [dbo].[guiones]
           ([nombre]
           ,[guionista]
           ,[genero]
           ,[año]
           ,[sinopsis])
     VALUES
           ('El secreto de la montaña', 1, 'Drama', '2022-05-15', 'Un grupo de excursionistas descubre un misterio oculto en lo más alto de una montaña.'),
			('La sombra del pasado', 2, 'Suspenso', '2023-08-20', 'Un hombre es perseguido por su oscuro pasado mientras intenta reconstruir su vida.'),
			('El último viaje', 3, 'Aventura', '2024-04-10', 'Un grupo de amigos emprende un épico viaje por carretera en busca de aventuras y descubrimientos.'),
			('La promesa rota', 4, 'Romance', '2023-11-05', 'Dos amantes se reencuentran después de años separados, pero el destino tiene otros planes para ellos.'),
			('El experimento', 4, 'Ciencia Ficción', '2024-09-30', 'Un grupo de científicos lleva a cabo un arriesgado experimento que podría cambiar el curso de la humanidad para siempre.');

GO


