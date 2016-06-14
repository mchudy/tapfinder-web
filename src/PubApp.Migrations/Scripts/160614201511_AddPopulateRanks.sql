/* Migration Script */

CREATE TABLE [dbo].[Ranks](
	[Id] int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Title] nvarchar(128) NOT NULL,
	[Description] nvarchar(512) NOT NULL,
);

GO
INSERT INTO [dbo].[Ranks]
           ([Title], [Description])
     VALUES
		(N'Pocz¹tuj¹cy', N'Witaj na pok³adzie!'),
		(N'Amator', N'Pierwsze wypite piwa za Tob¹. Oby tak dalej!'),
		(N'Aspiruj¹cy', N'Aspirujesz do miana Piwosza, tak trzymaæ!'),
		(N'Piwosz', N'Lubisz wypiæ dobre piwo, mo¿e zostaniesz Browarnikiem?'),
		(N'Browarnik', N'¯adne kraftowe piwo nie jest Ci obce!'),
		(N'Ekspert', N'Jesteœ prawdziwym ekspertem w kwestii z³ocistego trunku!')
;