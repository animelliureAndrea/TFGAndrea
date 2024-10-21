USE [tfgCinPadd]
GO

INSERT INTO [dbo].[castings]
           ([nombre]
           ,[descripcion]
           ,[director]
           ,[ubicación]
           ,[interesados]
           ,[fecha]
           ,[codPelicula])
     VALUES
           ('Casting película acción', 'Se buscan actores y actrices con experiencia en escenas de acción.', 3, 'Estudio de cine XYZ', 1, '2024-02-15', 12),
			('Audición de talentos', 'Se convoca a una audición abierta para descubrir nuevos talentos.', 4, 'Teatro ABC', 1, '2024-04-20', NULL),
			('Casting película romántica', 'Se buscan protagonistas para una historia de amor.', NULL, 'Estudio de cine XYZ', 1, '2024-06-10', 13),
			('Casting película terror', 'Buscamos actores dispuestos a enfrentarse a sus peores pesadillas.', NULL, 'Teatro del Terror', 1, '2023-10-05', 11),
			('Audición de doblaje', 'Se buscan voces talentosas para dar vida a los personajes de una película animada.', 5, 'Estudio de grabación SoundWorks', 1, '2024-08-10', NULL);
GO


USE [tfgCinPadd]
GO

INSERT INTO [dbo].[castings]
           ([nombre]
           ,[descripcion]
           ,[director]
           ,[ubicación]
           ,[interesados]
           ,[fecha]
           ,[codPelicula])
     VALUES
           ('Casting videoclip', 'Se buscan actores y actrices sin experiencia.', 3, 'Reservado Concept', 1, '2024-05-15', NULL),
			('Audición de niños', 'Se convoca a una audición abierta para nenes de 7-10.', 4, 'Teatro ABC', 1, '2024-04-20', NULL),
			('Casting película romántica', 'Se buscan figurantes para una historia de amor.', 1, 'Estudio de cine XYZ', 1, '2024-06-10', 13),
			('Casting figurantes', 'Buscamos figurantes dispuestos a enfrentarse a sus peores pesadillas.', 2, 'Teatro del Terror', 1, '2023-10-05', 11),
			('Audición de extras', 'Se buscan extras de manos.', 5, 'Estudio de grabación SoundWorks', 1, '2024-08-10', NULL);
GO