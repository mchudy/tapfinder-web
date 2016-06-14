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
		(N'Pocz�tuj�cy', N'Witaj na pok�adzie!'),
		(N'Amator', N'Pierwsze wypite piwa za Tob�. Oby tak dalej!'),
		(N'Aspiruj�cy', N'Aspirujesz do miana Piwosza, tak trzyma�!'),
		(N'Piwosz', N'Lubisz wypi� dobre piwo, mo�e zostaniesz Browarnikiem?'),
		(N'Browarnik', N'�adne kraftowe piwo nie jest Ci obce!'),
		(N'Ekspert', N'Jeste� prawdziwym ekspertem w kwestii z�ocistego trunku!')
;