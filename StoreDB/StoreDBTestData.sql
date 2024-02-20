USE StoreDB;
GO

-- Insert data into CategoryState
IF NOT EXISTS (SELECT * FROM [CategoryState] WHERE [Name] = 'Active')
BEGIN
    INSERT INTO [CategoryState] ([Name]) VALUES ('Active');
END

IF NOT EXISTS (SELECT * FROM [CategoryState] WHERE [Name] = 'Inactive')
BEGIN
    INSERT INTO [CategoryState] ([Name]) VALUES ('Inactive');
END


-- Insert data into Category
IF NOT EXISTS (SELECT * FROM [Category] WHERE [Name] = 'Clothing')
BEGIN
    INSERT INTO [Category] ([Name], [CategoryStateId]) VALUES ('Clothing', 1);
END

IF NOT EXISTS (SELECT * FROM [Category] WHERE [Name] = 'Footwear')
BEGIN
    INSERT INTO [Category] ([Name], [CategoryStateId]) VALUES ('Footwear', 1);
END

IF NOT EXISTS (SELECT * FROM [Category] WHERE [Name] = 'Swimsuit')
BEGIN
    INSERT INTO [Category] ([Name], [CategoryStateId]) VALUES ('Swimsuit', 2);
END


-- Insert data into ProductState
IF NOT EXISTS (SELECT * FROM [ProductState] WHERE [Name] = 'Available')
BEGIN
    INSERT INTO [ProductState] ([Name]) VALUES ('Available');
END

IF NOT EXISTS (SELECT * FROM [ProductState] WHERE [Name] = 'Out of Stock')
BEGIN
    INSERT INTO [ProductState] ([Name]) VALUES ('Out of Stock');
END


-- Insert data into Product
IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'T-Shirt')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('T-Shirt', 'Cotton T-Shirt.', 100, 20.00, 1, 1);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Jeans')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Jeans', 'Slim-fit denim jeans.', 50, 50.00, 1, 1);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Hoodies')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Hoodies', 'A sweatshirt or a jacket with a hood.', 75, 15.00, 1, 1);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Socks')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Socks', 'A garment for the foot, typically knitted from wool, cotton, or nylon.', 0, 3.00, 1, 2);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Sneakers')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Sneakers', 'Casual sports shoes.', 110, 40.00, 2, 1);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Loafers')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Loafers', 'Shoe that is easily slipped on and off the foot.', 40, 50.00, 2, 1);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Sandals')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Sandals', 'A light shoe with either an openwork upper or straps attaching the sole to the foot.', 0, 10.00, 2, 2);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Board Shorts')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Board Shorts', 'Shorts have a fixed waist with a lace cinch that tightens firmly.', 80, 20.00, 3, 1);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Bikini')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Bikini', 'A two-piece bathing suit worn by women that does not cover the midriffy.', 30, 25.00, 3, 1);
END

IF NOT EXISTS (SELECT * FROM [Product] WHERE [Name] = 'Bermuda')
BEGIN
    INSERT INTO [Product] ([Name], [Description], [ProductStock], [Price], [CategoryId], [ProductStateId]) VALUES ('Bermuda', 'A particular type of short trousers, worn as semi-casual attire by both men and women.', 0, 15.00, 3, 2);
END


-- Insert data into Purchase
IF NOT EXISTS (SELECT * FROM [Purchase] WHERE [CustomerName] = 'John Constantine')
BEGIN
    INSERT INTO [Purchase] ([Date], [CustomerName], [CustomerDocumentId], [CustomerPhone], [CustomerEmail], [CustomerAddress], [Total]) VALUES (GETDATE(), 'John Constantine', '123456789', '12345678', 'john@example.com', '123 Main St','90.00');
END

-- Insert data into Purchase
IF NOT EXISTS (SELECT * FROM [Purchase] WHERE [CustomerName] = 'Jonn Jonzz')
BEGIN
    INSERT INTO [Purchase] ([Date], [CustomerName], [CustomerDocumentId], [CustomerPhone], [CustomerEmail], [CustomerAddress], [Total]) VALUES (GETDATE(), 'Jonn Jonzz', '987654321', '87654321', 'jonnjonzz@example.com', '32 My Street', '85.00');
END

-- Insert data into Purchase
IF NOT EXISTS (SELECT * FROM [Purchase] WHERE [CustomerName] = 'Kent Nelson')
BEGIN
    INSERT INTO [Purchase] ([Date], [CustomerName], [CustomerDocumentId], [CustomerPhone], [CustomerEmail], [CustomerAddress], [Total]) VALUES (GETDATE(), 'Kent Nelson', '123456780', '12345670', 'kent@example.com', '495 Groove Street', '195.00');
END


-- Insert data into PurchaseProduct
IF NOT EXISTS (SELECT * FROM [PurchaseProduct] WHERE [PurchaseId] = 1 AND [ProductId] = 1)
BEGIN
    INSERT INTO [PurchaseProduct] ([Quantity], [PurchaseId], [ProductId]) VALUES (2, 1, 1);
END

IF NOT EXISTS (SELECT * FROM [PurchaseProduct] WHERE [PurchaseId] = 1 AND [ProductId] = 2)
BEGIN
    INSERT INTO [PurchaseProduct] ([Quantity], [PurchaseId], [ProductId]) VALUES (1, 1, 2);
END

IF NOT EXISTS (SELECT * FROM [PurchaseProduct] WHERE [PurchaseId] = 2 AND [ProductId] = 9)
BEGIN
    INSERT INTO [PurchaseProduct] ([Quantity], [PurchaseId], [ProductId]) VALUES (1, 2, 9);
END

IF NOT EXISTS (SELECT * FROM [PurchaseProduct] WHERE [PurchaseId] = 2 AND [ProductId] = 8)
BEGIN
    INSERT INTO [PurchaseProduct] ([Quantity], [PurchaseId], [ProductId]) VALUES (3, 2, 8);
END

IF NOT EXISTS (SELECT * FROM [PurchaseProduct] WHERE [PurchaseId] = 3 AND [ProductId] = 5)
BEGIN
    INSERT INTO [PurchaseProduct] ([Quantity], [PurchaseId], [ProductId]) VALUES (2, 3, 5);
END

IF NOT EXISTS (SELECT * FROM [PurchaseProduct] WHERE [PurchaseId] = 3 AND [ProductId] = 6)
BEGIN
    INSERT INTO [PurchaseProduct] ([Quantity], [PurchaseId], [ProductId]) VALUES (2, 3, 6);
END

IF NOT EXISTS (SELECT * FROM [PurchaseProduct] WHERE [PurchaseId] = 3 AND [ProductId] = 3)
BEGIN
    INSERT INTO [PurchaseProduct] ([Quantity], [PurchaseId], [ProductId]) VALUES (1, 3, 3);
END