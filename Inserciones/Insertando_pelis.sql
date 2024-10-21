USE [tfgCinPadd]
GO

INSERT INTO [dbo].[peliculas]
           ([titulo]
           ,[descripcion]
           ,[nºActores]
           ,[director]
           ,[guionista]
           ,[guion]
           ,[genero]
           ,[año])
     VALUES
           ('El secreto de la montaña', 'Un grupo de excursionistas descubre un misterio oculto en lo más alto de una montaña.', 6, 1, 1, 1, 'Drama', '2022-05-15'),
			('La sombra del pasado', 'Un hombre es perseguido por su oscuro pasado mientras intenta reconstruir su vida.', 4, 2, 2, 2, 'Suspenso', '2023-08-20'),
			('El último viaje', 'Un grupo de amigos emprende un épico viaje por carretera en busca de aventuras y descubrimientos.', 8, 3, 3, 3, 'Aventura', '2024-04-10'),
			('La promesa rota', 'Dos amantes se reencuentran después de años separados.', 5, 4, 4, 4, 'Romance', '2023-11-05'),
			('El experimento', 'Un grupo de científicos lleva a cabo un arriesgado experimento.', 7, 5, 5, 5, 'Ciencia Ficción', '2024-09-30');
GO

USE [tfgCinPadd]
GO

INSERT INTO [dbo].[peliculas]
           ([titulo]
           ,[descripcion]
           ,[nºActores]
           ,[director]
           ,[guionista]
           ,[guion]
           ,[genero]
           ,[año])
     VALUES
		('No hay película', 'Campo enlazado a casting sin película relaccionada', 0, 1, 1, 1, 'Drama', '2022-05-15');
GO
