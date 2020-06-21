CREATE TABLE [dbo].[Category]
(
	[Id] BigInt identity (1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(100) not null,
	[Description] nvarchar(200) null
)
