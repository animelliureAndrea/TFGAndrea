USE [tfgCinPadd]
GO

INSERT INTO [dbo].[productora]
           ([nombre]
           ,[direccion]
           ,[telefono]
           ,[mail])
     VALUES
           ('CineArte Producciones', 'Calle Mayor 123', '+123456789', 'info@cinearte.com'),
			('Estudio Cinematográfico XYZ', 'Avenida Principal 456', '+987654321', 'contacto@estudioxyz.com'),
			('Producciones Creativas S.A.', 'Calle de los Artistas 789', '+246813579', 'contacto@creativas.com'),
			('DreamWorks Studios', 'Sunset Boulevard 101', '+135792468', 'info@dreamworks.com'),
			('Warner Bros. Pictures', 'Burbank, California', '+246813579', 'info@warnerbros.com');
GO



