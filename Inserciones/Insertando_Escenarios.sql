USE [tfgCinPadd]
GO

INSERT INTO [dbo].[escenario]
           ([nombre]
           ,[direccion]
           ,[telefono]
           ,[capacidadMax])
     VALUES
           ('Teatro ABC', 'Avenida de las Artes 123', '+123456789', 300),
			('Estudio de Cine XYZ', 'Calle del Cine 456', '+987654321', 500),
			('Café La Bohème', 'Plaza Bohemia 789', '+246813579', 100),
			('Estudio de SoundWorks', 'Sunset Boulevard 101', '+135792468', 50),
			('Cine Metrópolis', 'Calle del Cine 789', '+987654321', 400);
GO


