CREATE TABLE [dbo].[BeerStyles](
	[Id] int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Name] nvarchar(64) NOT NULL
);

CREATE TABLE [dbo].[Breweries](
	[Id] int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Name] nvarchar(64) NOT NULL
);

CREATE TABLE [dbo].[Beers](
	[Id] int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Name] nvarchar(128) NOT NULL,
	[Description] nvarchar(512) NULL,
	[BeerStyleId] int NOT NULL,
	[BreweryId] int NOT NULL,
	
	CONSTRAINT [FK_Beers_BeerStyles] FOREIGN KEY([BeerStyleId]) REFERENCES [dbo].[BeerStyles]([Id]),
	CONSTRAINT [FK_Beers_Breweries] FOREIGN KEY([BreweryId]) REFERENCES [dbo].[Breweries]([Id])
);

CREATE NONCLUSTERED INDEX [IX_Beers_BeerStyleId] 
	ON [dbo].[Beers] ([BeerStyleId] ASC);

CREATE NONCLUSTERED INDEX [IX_Beers_BreweryId] 
	ON [dbo].[Beers] ([BreweryId] ASC);

CREATE TABLE [dbo].[PlacesBeers](
	[Id] int NOT NULL,
	[PlaceId] nvarchar(128) NOT NULL,
	[AddedDate] datetime NOT NULL,
	[Description] nvarchar(300) NOT NULL,
	[UserId] int NOT NULL,
	[BeerId] int NOT NULL,
	[Price] money NOT NULL,

	CONSTRAINT [UN_BeerId_PlaceId] UNIQUE([BeerId], [PlaceId]),
	CONSTRAINT [FK_PlacesBeers_LikeableItems] FOREIGN KEY(Id) REFERENCES [dbo].LikeableItems(Id),
	CONSTRAINT [FK_PlacesBeers_AspNetUsers] FOREIGN KEY (UserId) REFERENCES [dbo].AspNetUsers(Id),
	CONSTRAINT [FK_PlacesBeers_Beers] FOREIGN KEY (BeerId) REFERENCES [dbo].Beers(Id),
);

CREATE UNIQUE NONCLUSTERED INDEX [UX_PlacesBeers_PlaceId] 
	ON [dbo].[PlacesBeers] ([PlaceId] ASC);

CREATE NONCLUSTERED INDEX [IX_PlacesBeers_BeerId] 
	ON [dbo].[PlacesBeers] ([BeerId] ASC);

CREATE NONCLUSTERED INDEX [IX_PlacesBeers_UserId] 
	ON [dbo].[PlacesBeers] ([UserId] ASC);