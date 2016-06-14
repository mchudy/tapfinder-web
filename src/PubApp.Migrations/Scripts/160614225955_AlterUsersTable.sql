/* Migration Script */

GO
ALTER TABLE [dbo].[AspNetUsers] ADD [Experience] int NULL;
ALTER TABLE [dbo].[AspNetUsers] ADD [RankId] int NULL;
ALTER TABLE [dbo].[AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Rank] FOREIGN KEY(RankId) REFERENCES [dbo].Ranks(Id);