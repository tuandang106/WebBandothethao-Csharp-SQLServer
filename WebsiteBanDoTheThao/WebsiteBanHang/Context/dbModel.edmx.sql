
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2022 19:09:30
-- Generated from EDMX file: C:\Users\Admin\OneDrive\Máy tính\NamTinh_WebsiteBanHang\WebsiteBanHang\Context\dbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WebsiteBanHang];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetail];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Brand'
CREATE TABLE [dbo].[Brand] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Avatar] nvarchar(100)  NULL,
    [Slug] varchar(100)  NULL,
    [ShowOnHomePage] bit  NULL,
    [DisplayOrder] int  NULL,
    [CreatedOnUtc] datetime  NULL,
    [UpdatedOnUtc] datetime  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Avatar] nchar(100)  NULL,
    [Slug] varchar(100)  NULL,
    [ShowOnHomePage] bit  NULL,
    [DisplayOrder] int  NULL,
    [Deleted] bit  NULL,
    [CreatedOnUtc] datetime  NULL,
    [UpdatedOnUtc] datetime  NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [UserId] int  NULL,
    [Status] int  NULL,
    [CreatedOnUtc] datetime  NULL
);
GO

-- Creating table 'OrderDetail'
CREATE TABLE [dbo].[OrderDetail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Avatar] nchar(100)  NULL,
    [CategoryId] int  NULL,
    [ShortDes] nvarchar(100)  NULL,
    [FullDescription] nvarchar(500)  NULL,
    [Price] float  NULL,
    [PriceDiscount] float  NULL,
    [TypeId] int  NULL,
    [Slug] varchar(50)  NULL,
    [BrandId] int  NULL,
    [Deleted] bit  NULL,
    [ShowOnHomePage] bit  NULL,
    [DisplayOrder] int  NULL,
    [CreatedOnUtc] datetime  NULL,
    [UpdatedOnUtc] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [IsAdmin] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Brand'
ALTER TABLE [dbo].[Brand]
ADD CONSTRAINT [PK_Brand]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderDetail'
ALTER TABLE [dbo].[OrderDetail]
ADD CONSTRAINT [PK_OrderDetail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------