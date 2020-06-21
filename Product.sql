CREATE TABLE [dbo].[Product]
(
	[Id] bigInt identity not null primary key,
	[name] nvarchar(100) not null,
	[description] nvarchar(200),
	PurchasePrice decimal not null,
	RetailPrice decimal not null,
	CategoryId bigInt,
	foreign key (categoryId) references Category (Id) 
	ON DELETE NO ACTION
)
