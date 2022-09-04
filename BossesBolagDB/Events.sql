CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL identity PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [SKU] NVARCHAR(100) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [BillToID] int foreign key REFERENCES [dbo].[BillOrShipInfo] ([Id]) not null,
    [ShipToID] int foreign key REFERENCES [dbo].[BillOrShipInfo] ([Id]) not null,
)
