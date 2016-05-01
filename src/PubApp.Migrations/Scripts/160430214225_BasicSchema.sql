CREATE TABLE [dbo].Places(
	[Id] int NOT NULL	PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(100) NOT NULL,
	[Description] nvarchar(MAX) NULL,
	[Location] geography NOT NULL,
	[Email] varchar(254) NULL,
	[Website] varchar(256) NULL,
	[PhoneNumber] varchar(30) NULL
);

CREATE NONCLUSTERED INDEX [PlaceNameIndex] 
	ON [dbo].[Places] ([Name] ASC);

-- 'base' table for things that can be liked
CREATE TABLE [dbo].[LikeableItems](
	[Id] int NOT NULL PRIMARY KEY IDENTITY(1,1)
);

CREATE TABLE [dbo].SpecialOffers(
	[Id] int NOT NULL,
	[PlaceId] int NOT NULL,
	[StartDate] datetime NOT NULL,
	[EndDate] datetime NULL,
	[Description] nvarchar(300) NOT NULL,
	[UserId] int NOT NULL,

	CONSTRAINT [FK_SpecialOffers_LikeableItems] FOREIGN KEY(Id) REFERENCES [dbo].LikeableItems(Id),
	CONSTRAINT [FK_SpecialOffers_Places] FOREIGN KEY (PlaceId) REFERENCES [dbo].Places(Id),
	CONSTRAINT [FK_SpecialOffers_AspNetUsers] FOREIGN KEY (UserId) REFERENCES [dbo].AspNetUsers(Id),
);

CREATE TABLE [dbo].Comments(
	[Id] int NOT NULL,
	[Text] nvarchar(500) NOT NULL,
	[Date] datetime NOT NULL,
	[UserId] int NOT NULL,
	[PlaceId] int NOT NULL,

	CONSTRAINT [FK_Comments_LikeableItems] FOREIGN KEY(Id) REFERENCES [dbo].LikeableItems(Id),
    CONSTRAINT [FK_Comments_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].AspNetUsers([Id]),
	CONSTRAINT [FK_Comments_Places] FOREIGN KEY ([PlaceId]) REFERENCES [dbo].Places([Id])
);

CREATE TABLE [dbo].Likes(
	[UserId] int NOT NULL,
	[LikeableItemId] int NOT NULL,
	[Liked] bit NOT NULL,
	
	CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED ([UserId] ASC, [LikeableItemId] ASC),
	CONSTRAINT [FK_Likes_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].AspNetUsers([Id]),
	CONSTRAINT [FK_Likes_Items] FOREIGN KEY ([LikeableItemId]) REFERENCES [dbo].LikeableItems([Id])
);