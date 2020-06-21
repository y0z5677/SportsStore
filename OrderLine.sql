CREATE TABLE [dbo].[OrderLine]
(
	[Id] BigINT identity (1,1) NOT NULL PRIMARY KEY,
	Quantity int,
	ProductId bigInt ,
	foreign key (ProductId) references Product(Id),
	OrderId bigInt,
	foreign key (OrderId) references [Order] (Id) ON DELETE CASCADE
)
