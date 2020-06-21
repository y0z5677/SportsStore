CREATE TABLE [dbo].[Order]
(
	[Id] BigINT identity(1,1) NOT NULL PRIMARY KEY,
	CustomerName nvarchar(100),
	[Address] nvarchar(100),
	[State] nvarchar(50),
	[ZipCode] nvarchar(50),
	[Shipped] bit 
)
