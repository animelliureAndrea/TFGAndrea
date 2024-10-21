USE [tfgCinPadd]
GO

INSERT INTO [dbo].[criticas]
           ([codPelicula]
           ,[codUsuario]
           ,[puntuacion]
           ,[comentario])
     VALUES
           (10, 23, 5, 'La obra más catastroficamente espectacular que vi nunca'),
		   (10, 1, 1, 'No la entendí');
GO


