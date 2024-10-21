USE [tfgCinPadd]
GO

INSERT INTO [dbo].[festivales]
           ([nombre]
           ,[fecha]
           ,[ubicacion]
           ,[NºPeliculasPresentadas])
     VALUES
           ('Premios oscars', '2024-03-20', 'Nueva York', 50),
			('Festival de Cannes', '2024-09-15', 'Cannes', 100),
			('Festival de Sundance', '2024-01-25', 'Park City', 80),
			('Premios Feroz', '2024-01-30', 'Madrid', 70),
			('Premios Goya', '2024-02-10', 'Málaga', 90),
			('Premios Gaudí', '2024-03-12', 'Barcelona', 90);
GO



