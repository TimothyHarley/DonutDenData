USE [master]
GO
/****** Object:  Database [DonutDen]    Script Date: 7/20/2019 9:35:43 AM ******/
CREATE DATABASE [DonutDen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DonutDen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DonutDen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DonutDen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DonutDen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DonutDen] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DonutDen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DonutDen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DonutDen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DonutDen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DonutDen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DonutDen] SET ARITHABORT OFF 
GO
ALTER DATABASE [DonutDen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DonutDen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DonutDen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DonutDen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DonutDen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DonutDen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DonutDen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DonutDen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DonutDen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DonutDen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DonutDen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DonutDen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DonutDen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DonutDen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DonutDen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DonutDen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DonutDen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DonutDen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DonutDen] SET  MULTI_USER 
GO
ALTER DATABASE [DonutDen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DonutDen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DonutDen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DonutDen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DonutDen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DonutDen] SET QUERY_STORE = OFF
GO
USE [DonutDen]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DonutDen]
GO
/****** Object:  Table [dbo].[CookType]    Script Date: 7/20/2019 9:35:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CookType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_CookType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonutCategory]    Script Date: 7/20/2019 9:35:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonutCategory](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_DonutCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 7/20/2019 9:35:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 7/20/2019 9:35:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [numeric](10, 2) NOT NULL,
	[SpecialRequest] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/20/2019 9:35:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](24) NOT NULL,
	[PickUpDate] [date] NOT NULL,
	[PickUpTime] [time](0) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ApprovedBy] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/20/2019 9:35:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(3720,1) NOT NULL,
	[FirebaseUid] [nvarchar](255) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](24) NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CookType] ON 

INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (7, 3720, 1)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (8, 3720, 2)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (9, 3720, 4)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (10, 3720, 5)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (11, 3720, 7)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (12, 3720, 8)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (13, 3720, 9)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (14, 3721, 1)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (15, 3721, 2)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (16, 3721, 4)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (17, 3721, 5)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (18, 3721, 3)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (19, 3721, 8)
INSERT [dbo].[CookType] ([Id], [UserId], [CategoryId]) VALUES (20, 3721, 9)
SET IDENTITY_INSERT [dbo].[CookType] OFF
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (1, N'Yeast Donuts')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (2, N'Fancy Pastries')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (3, N'Old Fasioned/Cake Donuts')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (4, N'14" Texas Donut')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (5, N'18" Texas Donut')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (6, N'Brekfast Sandwich')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (7, N'Cronuts')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (8, N'Holes')
INSERT [dbo].[DonutCategory] ([Id], [Name]) VALUES (9, N'Muffins')
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (1, N'Glazed Donuts', CAST(1.33 AS Numeric(10, 2)), 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (2, N'6 Glazed Donuts', CAST(7.49 AS Numeric(10, 2)), 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (3, N'12 Glazed Donuts', CAST(12.49 AS Numeric(10, 2)), 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (4, N'Other Donuts', CAST(1.44 AS Numeric(10, 2)), 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (5, N'Filled Donuts', CAST(1.59 AS Numeric(10, 2)), 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (6, N'Fancy Pastries', CAST(2.69 AS Numeric(10, 2)), 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (7, N'Old Fasioned', CAST(1.44 AS Numeric(10, 2)), 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (8, N'Cake Donuts', CAST(1.44 AS Numeric(10, 2)), 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (9, N'14" Texas Donut', CAST(23.99 AS Numeric(10, 2)), 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (10, N'18" Texas Donut', CAST(33.99 AS Numeric(10, 2)), 5)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (11, N'Breakfast Biscuits', CAST(2.69 AS Numeric(10, 2)), 6)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (12, N'Cronuts', CAST(2.69 AS Numeric(10, 2)), 7)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (13, N'Donut Holes', CAST(0.44 AS Numeric(10, 2)), 8)
INSERT [dbo].[MenuItem] ([Id], [Name], [Price], [Category]) VALUES (14, N'Muffins', CAST(2.69 AS Numeric(10, 2)), 9)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [UnitPrice], [SpecialRequest]) VALUES (3, 1, 1, 4, CAST(1.33 AS Numeric(10, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [UnitPrice], [SpecialRequest]) VALUES (4, 1, 13, 5, CAST(0.44 AS Numeric(10, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [UnitPrice], [SpecialRequest]) VALUES (5, 2, 6, 1, CAST(2.69 AS Numeric(10, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [UnitPrice], [SpecialRequest]) VALUES (6, 3, 11, 1, CAST(2.69 AS Numeric(10, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [UnitPrice], [SpecialRequest]) VALUES (7, 3, 7, 3, CAST(1.44 AS Numeric(10, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [UnitPrice], [SpecialRequest]) VALUES (8, 3, 5, 1, CAST(1.59 AS Numeric(10, 2)), NULL)
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [FirstName], [LastName], [Email], [PhoneNumber], [PickUpDate], [PickUpTime], [IsApproved], [IsDeleted], [ApprovedBy]) VALUES (1, N'Tony', N'Stark', N'Tony@Avengers.com', N'2125551234', CAST(N'2022-01-01' AS Date), CAST(N'13:00:00' AS Time), 1, 0, 3720)
INSERT [dbo].[Orders] ([Id], [FirstName], [LastName], [Email], [PhoneNumber], [PickUpDate], [PickUpTime], [IsApproved], [IsDeleted], [ApprovedBy]) VALUES (2, N'Steve', N'Rogers', N'Captain@Avengers.com', N'2125555678', CAST(N'2022-01-05' AS Date), CAST(N'11:00:00' AS Time), 1, 0, 3720)
INSERT [dbo].[Orders] ([Id], [FirstName], [LastName], [Email], [PhoneNumber], [PickUpDate], [PickUpTime], [IsApproved], [IsDeleted], [ApprovedBy]) VALUES (3, N'Bruce', N'Banner', N'AllwaysAngry@Avengers.com', N'2125559012', CAST(N'2022-06-16' AS Date), CAST(N'08:00:00' AS Time), 1, 0, 3721)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirebaseUid], [FirstName], [LastName], [Email], [PhoneNumber], [IsAdmin], [IsDeleted]) VALUES (3720, N'1234567890', N'Timothy', N'Harley', N'Timothy.D.Harley@gmail.com', N'6154801920', 1, 0)
INSERT [dbo].[Users] ([Id], [FirebaseUid], [FirstName], [LastName], [Email], [PhoneNumber], [IsAdmin], [IsDeleted]) VALUES (3721, N'0987654321', N'Rachel', N'Harley', N'RachelJAHarley@gmail.com', N'6157130935', 1, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[CookType]  WITH CHECK ADD  CONSTRAINT [FK_CookType_DonutCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[DonutCategory] ([Id])
GO
ALTER TABLE [dbo].[CookType] CHECK CONSTRAINT [FK_CookType_DonutCategory]
GO
ALTER TABLE [dbo].[CookType]  WITH CHECK ADD  CONSTRAINT [FK_CookType_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CookType] CHECK CONSTRAINT [FK_CookType_Users]
GO
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_DonutCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DonutCategory] ([Id])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_DonutCategory]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_MenuItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[MenuItem] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_MenuItem]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ApprovedBy' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'CONSTRAINT',@level2name=N'FK_Orders_Users'
GO
USE [master]
GO
ALTER DATABASE [DonutDen] SET  READ_WRITE 
GO
