IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'StoreDB')
BEGIN
	CREATE DATABASE StoreDB;
END
GO

USE StoreDB;
GO

--CREATE CATEGORY STATE
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'CategoryState' AND xtype = 'U')
BEGIN
	CREATE TABLE [CategoryState] (
	Id INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT PKCategoryState PRIMARY KEY (Id),
	CONSTRAINT UXCategoryStateName UNIQUE ([Name]),
	)
END
GO

--CREATE CATEGORY
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Category' AND xtype = 'U')
BEGIN
	CREATE TABLE [Category] (
	Id INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[CategoryStateId] INT NOT NULL,
	CONSTRAINT PKCategory PRIMARY KEY (Id),
	CONSTRAINT UXCategoryName UNIQUE ([Name]),
	CONSTRAINT FKCategoryCategoryStateCategoryStateId FOREIGN KEY (CategoryStateId) REFERENCES CategoryState (Id),
	)
END
GO

--CREATE PRODUCT STATE
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'ProductState' AND xtype = 'U')
BEGIN
	CREATE TABLE [ProductState] (
	Id INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT PKProductState PRIMARY KEY (Id),
	CONSTRAINT UXProductStateName UNIQUE ([Name]),
	)
END
GO

--CREATE PRODUCT
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Product' AND xtype = 'U')
BEGIN
	CREATE TABLE [Product] (
	Id INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(255) NOT NULL,
	[ProductStock] INT NOT NULL,
	[Price] DECIMAL(10,2) NOT NULL,
	[CategoryId] INT NOT NULL,
	[ProductStateId] INT NOT NULL,
	CONSTRAINT PKProduct PRIMARY KEY (Id),
	CONSTRAINT UXProductName UNIQUE ([Name]),
	CONSTRAINT FKCategoryProductCategoryId FOREIGN KEY (CategoryId) REFERENCES Category (Id),
	CONSTRAINT FKProductStateProductProductStateId FOREIGN KEY (ProductStateId) REFERENCES ProductState (Id),
	)
END
GO

--CREATE PURCHASE
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Purchase' AND xtype = 'U')
BEGIN
	CREATE TABLE [Purchase] (
	Id INT NOT NULL IDENTITY(1,1),
	[Date] DATETIME2 NOT NULL,
	[Total] DECIMAL(10,2) NOT NULL,
	[CustomerName] NVARCHAR(255) NOT NULL,
	[CustomerDocumentId] NVARCHAR(9) NOT NULL,
	[CustomerPhone] NVARCHAR(8) NOT NULL,
	[CustomerEmail] NVARCHAR(50) NOT NULL,
	[CustomerAddress] NVARCHAR(255) NOT NULL,
	CONSTRAINT PKPurchase PRIMARY KEY (Id),
	)
END
GO

--CREATE PURCHASEPRODUCT
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'PurchaseProduct' AND xtype = 'U')
BEGIN
	CREATE TABLE [PurchaseProduct] (
	Id INT NOT NULL IDENTITY(1,1),
	[Quantity] INT NOT NULL,
	[TotalPrice] DECIMAL(10,2) NOT NULL,
	[PurchaseId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	CONSTRAINT PKPurchaseProduct PRIMARY KEY (Id),
	CONSTRAINT FKPurchasePurchaseProductPurchaseId FOREIGN KEY (PurchaseId) REFERENCES [Purchase] (Id),
	CONSTRAINT FKProductPurchaseProductProductId FOREIGN KEY (ProductId) REFERENCES Product (Id),
	)
END
GO