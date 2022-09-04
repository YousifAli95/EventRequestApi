CREATE TABLE [dbo].[BillOrShipInfo]
(
	[Id] INT NOT NULL identity PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Address] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(100) NOT NULL, 
    [State] NVARCHAR(100) NOT NULL, 
    [Zip] NVARCHAR(5) NOT NULL, 
)
