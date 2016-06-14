/* Migration Script */

CREATE TABLE [dbo].[Badges](
	[Id] int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Title] nvarchar(128) NOT NULL,
	[Description] nvarchar(512) NOT NULL,
);

CREATE TABLE [dbo].[UsersBadges](
	[UserId] int NOT NULL,
	[BadgeId] int NOT NULL,
	
	CONSTRAINT [PK_UsersBadges] PRIMARY KEY CLUSTERED ([UserId] ASC, [BadgeId] ASC),
	CONSTRAINT [FK_UsersBadges_AspNetUsers] FOREIGN KEY(UserId) REFERENCES [dbo].AspNetUsers(Id),
	CONSTRAINT [FK_UsersBadges_Badges] FOREIGN KEY(BadgeId) REFERENCES [dbo].Badges(Id)
);

GO
INSERT INTO [dbo].[Badges]
           ([Title], [Description])
     VALUES
		(N'Pocz�tuj�cy', N'Witaj na pok�adzie!'),
		(N'Amator', N'Pierwsze wypite piwa za Tob�. Oby tak dalej!'),
		(N'Aspiruj�cy', N'Aspirujesz do miana Piwosza, tak trzyma�!'),
		(N'Piwosz', N'Lubisz wypi� dobre piwo, mo�e zostaniesz Browarnikiem?'),
		(N'Browarnik', N'�adne kraftowe piwo nie jest Ci obce!'),
		(N'Ekspert', N'Jeste� prawdziwym ekspertem w kwestii z�ocistego trunku!')
;