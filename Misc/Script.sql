USE master;
GO

CREATE DATABASE ProductManager;
GO

USE ProductManager;
GO

CREATE TABLE dbo.Products
(
	[Id] INT NOT NULL IDENTITY(0, 1) PRIMARY KEY,
	[Code] VARCHAR(10) NOT NULL UNIQUE,
	[Name] VARCHAR(50) NOT NULL,
	[Price] DECIMAL(12, 2) NOT NULL DEFAULT(0.0)
);

INSERT INTO dbo.Products([Code], [Name], [Price])
VALUES('CODE001', 'Product001', 100.0);


SELECT * FROM dbo.Products WITH (NOLOCK);