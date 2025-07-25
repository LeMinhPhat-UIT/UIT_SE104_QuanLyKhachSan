CREATE Database HotelData
GO

USE [HotelData]
GO
/****** Object:  Table [dbo].[Amenity]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenity](
	[AmenityID] [int] IDENTITY(1,1) NOT NULL,
	[AmenityName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Amenity] PRIMARY KEY CLUSTERED 
(
	[AmenityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerTierID] [int] NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[IdentityNumber] [char](12) NOT NULL,
	[PhoneNumber] [char](10) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerTier]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTier](
	[CustomerTierID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerTierName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CustomerTier] PRIMARY KEY CLUSTERED 
(
	[CustomerTierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NOT NULL,
	[ReportID] [int] NULL,
	[UserID] [int] NULL,
	[InvoiceDate] [smalldatetime] NOT NULL,
	[SurchargeRate] [int] NOT NULL,
	[Coef] [decimal](18, 2) NOT NULL,
	[TotalAmount] [money] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RoomID] [int] NOT NULL,
	[CheckInDate] [smalldatetime] NOT NULL,
	[CheckOutDate] [smalldatetime] NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[CustomersCount] [int] NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation_Customer]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation_Customer](
	[CustomersCustomerID] [int] NOT NULL,
	[ReservationsReservationID] [int] NOT NULL,
 CONSTRAINT [PK_Reservation_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomersCustomerID] ASC,
	[ReservationsReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RevenueReport]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevenueReport](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[RevenueDate] [smalldatetime] NOT NULL,
	[UserID] [int] NULL,
	[RoomTierID] [int] NOT NULL,
	[TotalRevenue] [money] NOT NULL,
 CONSTRAINT [PK_RevenueReport] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomTierID] [int] NULL,
	[RoomNumber] [char](10) NOT NULL,
	[RoomState] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room_Amenity]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_Amenity](
	[AmenitiesAmenityID] [int] NOT NULL,
	[RoomsRoomID] [int] NOT NULL,
 CONSTRAINT [PK_Room_Amenity] PRIMARY KEY CLUSTERED 
(
	[AmenitiesAmenityID] ASC,
	[RoomsRoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomTier]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomTier](
	[RoomTierID] [int] IDENTITY(1,1) NOT NULL,
	[RoomTierName] [nvarchar](50) NOT NULL,
	[RoomTierPrice] [money] NOT NULL,
 CONSTRAINT [PK_RoomTier] PRIMARY KEY CLUSTERED 
(
	[RoomTierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rule]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rule](
	[RuleID] [int] IDENTITY(1,1) NOT NULL,
	[RoomMaxCustomer] [int] NOT NULL,
	[SurchargeRate] [int] NOT NULL,
	[CustomerToApplySurchargeRate] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14-Jul-25 6:23:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[IdentityNumber] [char](12) NOT NULL,
	[RoleID] [int] NOT NULL,
	[WorkingDate] [smalldatetime] NOT NULL,
	[EmailAddress] [varchar](200) NOT NULL,
	[PhoneNumber] [char](10) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Amenity] ON 

INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (1, N'Giường đơn')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (2, N'Giường đôi')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (3, N'Giường cỡ đại')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (4, N'Bồn tắm')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (5, N'TV thông minh')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (6, N'Tủ lạnh mini')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (7, N'Wifi tốc độ cao')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (8, N'Ghế tình yêu')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (9, N'Điều hòa')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (10, N'Ban công')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (11, N'Máy sấy tóc')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (12, N'Ấm đun nước')
INSERT [dbo].[Amenity] ([AmenityID], [AmenityName]) VALUES (13, N'Két an toàn')
SET IDENTITY_INSERT [dbo].[Amenity] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (1, 1, N'Nguyễn Thị Thu', N'012345678901', N'0901234567')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (2, 1, N'Trần Văn Long', N'012345678902', N'0902345678')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (3, 2, N'John Doe', N'012345678903', N'0903456789')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (4, 2, N'Maria Garcia', N'012345678904', N'0904567890')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (5, 1, N'Lê Minh Tuấn', N'012345678905', N'0905678901')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (6, 1, N'Phạm Thị Yến', N'012345678906', N'0906789012')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (7, 2, N'David Lee', N'012345678907', N'0907890123')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (8, 2, N'Sophie Dubois', N'012345678908', N'0908901234')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (9, 1, N'Hoàng Anh Thư', N'012345678909', N'0909012345')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (10, 1, N'Vũ Đức Trung', N'012345678910', N'0910123456')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (11, 2, N'Chen Wei', N'012345678911', N'0911234567')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (12, 2, N'Anna Schmidt', N'012345678912', N'0912345678')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (13, 1, N'Bùi Thanh Tâm', N'012345678913', N'0913456789')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (14, 1, N'Đỗ Quốc Hưng', N'012345678914', N'0914567890')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (15, 2, N'Oliver Black', N'012345678915', N'0915678901')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (16, 1, N'Nguyễn Văn A', N'012345678916', N'0916789012')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (17, 1, N'Trần Thị B', N'012345678917', N'0917890123')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (18, 2, N'Michael Brown', N'012345678918', N'0918901234')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (19, 2, N'Emily White', N'012345678919', N'0919012345')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (20, 1, N'Phạm Văn C', N'012345678920', N'0920123456')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (21, 1, N'Lê Thị D', N'012345678921', N'0921234567')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (22, 2, N'Chris Green', N'012345678922', N'0922345678')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (23, 2, N'Linda Blue', N'012345678923', N'0923456789')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (24, 1, N'Đào Minh E', N'012345678924', N'0924567890')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (25, 1, N'Hoàng Thị F', N'012345678925', N'0925678901')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (88, 1, N'Testing', N'741852963000', N'7894561230')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (89, 1, N'Lê Minh Phát', N'987456321000', N'0764439073')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (90, 1, N'Khách 2', N'000000000000', N'7896541230')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (91, 2, N'Khách 3', N'000000000001', N'7896541230')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (94, 1, N'Khách 4', N'000000000002', N'0123456789')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (96, 2, N'Le Minh Phat', N'000000000003', N'0000000000')
INSERT [dbo].[Customer] ([CustomerID], [CustomerTierID], [CustomerName], [IdentityNumber], [PhoneNumber]) VALUES (97, 2, N'Foreign', N'000000000004', N'0000000000')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerTier] ON 

INSERT [dbo].[CustomerTier] ([CustomerTierID], [CustomerTierName]) VALUES (1, N'Nội địa')
INSERT [dbo].[CustomerTier] ([CustomerTierID], [CustomerTierName]) VALUES (2, N'Nước ngoài')
SET IDENTITY_INSERT [dbo].[CustomerTier] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (1, 1, 1, 3, CAST(N'2025-05-03T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 240000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (2, 2, 2, 4, CAST(N'2025-05-08T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 540000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (3, 3, 3, 5, CAST(N'2025-05-14T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 1000000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (4, 4, 4, 6, CAST(N'2025-05-16T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 120000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (5, 5, 5, 7, CAST(N'2025-05-22T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 360000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (6, 6, 6, 3, CAST(N'2025-05-28T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 750000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (7, 7, 7, 4, CAST(N'2025-05-31T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 360000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (8, 8, 8, 5, CAST(N'2025-06-02T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 120000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (9, 9, 9, 6, CAST(N'2025-06-04T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 360000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (10, 10, 10, 7, CAST(N'2025-06-06T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 1000000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (11, 11, 11, 8, CAST(N'2025-06-05T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 120000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (12, 12, 12, 9, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 360000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (13, 13, 13, 5, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 240000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (14, 15, NULL, 7, CAST(N'2025-06-09T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 750000.0000, N'', N'Pending')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (49, 69, 468, 1, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 100000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (50, 70, NULL, 1, CAST(N'2025-07-13T00:00:00' AS SmallDateTime), 0, CAST(1.50 AS Decimal(18, 2)), 150000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (51, 71, NULL, 1, CAST(N'2025-07-13T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 100000.0000, N'Cash', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (52, 72, NULL, 1, CAST(N'2025-07-13T00:00:00' AS SmallDateTime), 0, CAST(1.50 AS Decimal(18, 2)), 150000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (53, 73, NULL, 1, CAST(N'2025-07-13T00:00:00' AS SmallDateTime), 0, CAST(1.50 AS Decimal(18, 2)), 150000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (54, 74, NULL, 1, CAST(N'2025-07-13T00:00:00' AS SmallDateTime), 0, CAST(1.50 AS Decimal(18, 2)), 150000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (56, 76, NULL, 1, CAST(N'2025-07-13T00:00:00' AS SmallDateTime), 0, CAST(1.50 AS Decimal(18, 2)), 150000.0000, N'Credit card', N'Paid')
INSERT [dbo].[Invoice] ([InvoiceID], [ReservationID], [ReportID], [UserID], [InvoiceDate], [SurchargeRate], [Coef], [TotalAmount], [PaymentMethod], [Status]) VALUES (57, 77, NULL, 1, CAST(N'2025-07-13T00:00:00' AS SmallDateTime), 0, CAST(1.00 AS Decimal(18, 2)), 100000.0000, N'Credit card', N'Paid')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (1, 3, 1, CAST(N'2025-05-01T00:00:00' AS SmallDateTime), CAST(N'2025-05-03T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (2, 4, 11, CAST(N'2025-05-05T00:00:00' AS SmallDateTime), CAST(N'2025-05-08T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (3, 5, 26, CAST(N'2025-05-10T00:00:00' AS SmallDateTime), CAST(N'2025-05-14T00:00:00' AS SmallDateTime), N'CheckOut', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (4, 6, 2, CAST(N'2025-05-15T00:00:00' AS SmallDateTime), CAST(N'2025-05-16T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (5, 7, 12, CAST(N'2025-05-20T00:00:00' AS SmallDateTime), CAST(N'2025-05-22T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (6, 3, 27, CAST(N'2025-05-25T00:00:00' AS SmallDateTime), CAST(N'2025-05-28T00:00:00' AS SmallDateTime), N'CheckOut', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (7, 4, 13, CAST(N'2025-05-29T00:00:00' AS SmallDateTime), CAST(N'2025-05-31T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (8, 5, 3, CAST(N'2025-06-01T00:00:00' AS SmallDateTime), CAST(N'2025-06-02T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (9, 6, 14, CAST(N'2025-06-02T00:00:00' AS SmallDateTime), CAST(N'2025-06-04T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (10, 7, 28, CAST(N'2025-06-03T00:00:00' AS SmallDateTime), CAST(N'2025-06-06T00:00:00' AS SmallDateTime), N'CheckOut', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (11, 8, 4, CAST(N'2025-06-04T00:00:00' AS SmallDateTime), CAST(N'2025-06-05T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (12, 9, 15, CAST(N'2025-06-05T00:00:00' AS SmallDateTime), CAST(N'2025-06-07T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (13, 5, 1, CAST(N'2025-06-05T00:00:00' AS SmallDateTime), CAST(N'2025-06-07T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (14, 6, 2, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), CAST(N'2025-06-08T00:00:00' AS SmallDateTime), N'Pending', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (15, 7, 26, CAST(N'2025-06-06T00:00:00' AS SmallDateTime), CAST(N'2025-06-09T00:00:00' AS SmallDateTime), N'CheckIn', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (16, 8, 30, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), CAST(N'2025-06-10T00:00:00' AS SmallDateTime), N'Pending', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (17, 9, 16, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), CAST(N'2025-06-09T00:00:00' AS SmallDateTime), N'CheckIn', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (18, 10, 5, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), CAST(N'2025-06-08T00:00:00' AS SmallDateTime), N'CheckIn', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (19, 9, 3, CAST(N'2025-06-10T00:00:00' AS SmallDateTime), CAST(N'2025-06-12T00:00:00' AS SmallDateTime), N'Pending', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (20, 10, 17, CAST(N'2025-06-15T00:00:00' AS SmallDateTime), CAST(N'2025-06-18T00:00:00' AS SmallDateTime), N'Pending', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (21, 3, 29, CAST(N'2025-06-20T00:00:00' AS SmallDateTime), CAST(N'2025-06-25T00:00:00' AS SmallDateTime), N'Pending', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (22, 4, 6, CAST(N'2025-06-28T00:00:00' AS SmallDateTime), CAST(N'2025-06-30T00:00:00' AS SmallDateTime), N'Pending', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (23, 5, 7, CAST(N'2025-07-01T00:00:00' AS SmallDateTime), CAST(N'2025-07-03T00:00:00' AS SmallDateTime), N'Pending', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (24, 6, 18, CAST(N'2025-07-05T00:00:00' AS SmallDateTime), CAST(N'2025-07-08T00:00:00' AS SmallDateTime), N'Pending', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (25, 7, 31, CAST(N'2025-07-05T00:00:00' AS SmallDateTime), CAST(N'2025-07-14T00:00:00' AS SmallDateTime), N'Pending', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (26, 8, 8, CAST(N'2025-07-07T00:00:00' AS SmallDateTime), CAST(N'2025-07-16T00:00:00' AS SmallDateTime), N'Pending', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (27, 9, 19, CAST(N'2025-07-07T00:00:00' AS SmallDateTime), CAST(N'2025-07-22T00:00:00' AS SmallDateTime), N'Pending', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (28, 10, 32, CAST(N'2025-07-06T00:00:00' AS SmallDateTime), CAST(N'2025-07-28T00:00:00' AS SmallDateTime), N'Pending', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (29, 5, 9, CAST(N'2025-06-01T00:00:00' AS SmallDateTime), CAST(N'2025-06-03T00:00:00' AS SmallDateTime), N'Cancelled', 3)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (30, 6, 20, CAST(N'2025-06-04T00:00:00' AS SmallDateTime), CAST(N'2025-06-05T00:00:00' AS SmallDateTime), N'Cancelled', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (31, 7, 10, CAST(N'2025-06-06T00:00:00' AS SmallDateTime), CAST(N'2025-06-07T00:00:00' AS SmallDateTime), N'Cancelled', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (32, 8, 21, CAST(N'2025-06-08T00:00:00' AS SmallDateTime), CAST(N'2025-06-10T00:00:00' AS SmallDateTime), N'Cancelled', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (69, 1, 1, CAST(N'2025-07-11T00:00:00' AS SmallDateTime), CAST(N'2025-07-12T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (70, 1, 1, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (71, 1, 1, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (72, 1, 4, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (73, 1, 1, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'CheckOut', 1)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (74, 1, 1, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (75, 1, 1, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'Cancelled', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (76, 1, 4, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'CheckOut', 2)
INSERT [dbo].[Reservation] ([ReservationID], [UserID], [RoomID], [CheckInDate], [CheckOutDate], [Status], [CustomersCount]) VALUES (77, 1, 1, CAST(N'2025-07-12T00:00:00' AS SmallDateTime), CAST(N'2025-07-13T00:00:00' AS SmallDateTime), N'CheckOut', 2)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 1)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (3, 2)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (4, 2)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (5, 3)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (6, 3)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (7, 3)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (8, 4)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (9, 5)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (10, 5)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (11, 6)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (12, 6)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (13, 6)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (14, 7)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (15, 7)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (16, 8)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (17, 9)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (18, 9)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (19, 10)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (20, 10)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (21, 10)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (22, 11)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (23, 12)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (24, 12)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 13)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (2, 14)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (5, 15)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (6, 15)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (7, 15)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (11, 16)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (12, 16)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (13, 16)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (14, 17)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (15, 17)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (16, 18)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (4, 19)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 20)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (2, 20)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (9, 21)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (10, 21)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (14, 21)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (15, 22)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (17, 23)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (18, 24)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (19, 24)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (20, 25)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (21, 25)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (22, 25)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (23, 26)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (24, 27)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (25, 27)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 28)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (3, 28)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (5, 28)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 29)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (3, 30)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (4, 30)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (8, 31)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (11, 32)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (12, 32)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 69)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (3, 70)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (94, 71)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (4, 72)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (20, 72)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (96, 73)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 74)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (97, 74)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 75)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 76)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (97, 76)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (1, 77)
INSERT [dbo].[Reservation_Customer] ([CustomersCustomerID], [ReservationsReservationID]) VALUES (2, 77)
GO
SET IDENTITY_INSERT [dbo].[RevenueReport] ON 

INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (1, CAST(N'2025-05-03T00:00:00' AS SmallDateTime), 3, 1, 240000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (2, CAST(N'2025-05-08T00:00:00' AS SmallDateTime), 4, 2, 540000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (3, CAST(N'2025-05-14T00:00:00' AS SmallDateTime), 5, 3, 1000000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (4, CAST(N'2025-05-16T00:00:00' AS SmallDateTime), 6, 1, 120000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (5, CAST(N'2025-05-22T00:00:00' AS SmallDateTime), 7, 2, 360000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (6, CAST(N'2025-05-28T00:00:00' AS SmallDateTime), 3, 3, 750000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (7, CAST(N'2025-05-31T00:00:00' AS SmallDateTime), 4, 2, 360000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (8, CAST(N'2025-06-02T00:00:00' AS SmallDateTime), 5, 1, 120000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (9, CAST(N'2025-06-04T00:00:00' AS SmallDateTime), 6, 2, 360000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (10, CAST(N'2025-06-06T00:00:00' AS SmallDateTime), 7, 3, 1000000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (11, CAST(N'2025-06-05T00:00:00' AS SmallDateTime), 8, 1, 120000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (12, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), 9, 2, 360000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (13, CAST(N'2025-06-07T00:00:00' AS SmallDateTime), 5, 1, 240000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (80, CAST(N'2025-06-08T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (81, CAST(N'2025-06-08T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (82, CAST(N'2025-06-08T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (83, CAST(N'2025-06-09T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (84, CAST(N'2025-06-09T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (85, CAST(N'2025-06-09T00:00:00' AS SmallDateTime), 1, 3, 750000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (86, CAST(N'2025-06-10T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (87, CAST(N'2025-06-10T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (88, CAST(N'2025-06-10T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (89, CAST(N'2025-06-11T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (90, CAST(N'2025-06-11T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (91, CAST(N'2025-06-11T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (92, CAST(N'2025-06-12T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (93, CAST(N'2025-06-12T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (94, CAST(N'2025-06-12T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (95, CAST(N'2025-06-13T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (96, CAST(N'2025-06-13T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (97, CAST(N'2025-06-13T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (98, CAST(N'2025-06-14T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (99, CAST(N'2025-06-14T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (100, CAST(N'2025-06-14T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (101, CAST(N'2025-06-15T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (102, CAST(N'2025-06-15T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (103, CAST(N'2025-06-15T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (104, CAST(N'2025-06-16T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (105, CAST(N'2025-06-16T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (106, CAST(N'2025-06-16T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (107, CAST(N'2025-06-17T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (108, CAST(N'2025-06-17T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (109, CAST(N'2025-06-17T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (110, CAST(N'2025-06-18T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (111, CAST(N'2025-06-18T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (112, CAST(N'2025-06-18T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (113, CAST(N'2025-06-19T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (114, CAST(N'2025-06-19T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (115, CAST(N'2025-06-19T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (116, CAST(N'2025-06-20T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (117, CAST(N'2025-06-20T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (118, CAST(N'2025-06-20T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (119, CAST(N'2025-06-21T00:00:00' AS SmallDateTime), 1, 1, 120000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (120, CAST(N'2025-06-21T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (121, CAST(N'2025-06-21T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (122, CAST(N'2025-06-22T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (123, CAST(N'2025-06-22T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (124, CAST(N'2025-06-22T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (125, CAST(N'2025-06-23T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (126, CAST(N'2025-06-23T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (127, CAST(N'2025-06-23T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (128, CAST(N'2025-06-24T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (129, CAST(N'2025-06-24T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (130, CAST(N'2025-06-24T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (131, CAST(N'2025-06-25T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (132, CAST(N'2025-06-25T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (133, CAST(N'2025-06-25T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (134, CAST(N'2025-06-26T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (135, CAST(N'2025-06-26T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (136, CAST(N'2025-06-26T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (137, CAST(N'2025-06-27T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (138, CAST(N'2025-06-27T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (139, CAST(N'2025-06-27T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (140, CAST(N'2025-06-28T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (141, CAST(N'2025-06-28T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (142, CAST(N'2025-06-28T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (143, CAST(N'2025-06-29T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (144, CAST(N'2025-06-29T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (145, CAST(N'2025-06-29T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (146, CAST(N'2025-06-30T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (147, CAST(N'2025-06-30T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (148, CAST(N'2025-06-30T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (149, CAST(N'2025-07-01T00:00:00' AS SmallDateTime), 1, 1, 500000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (150, CAST(N'2025-07-01T00:00:00' AS SmallDateTime), 1, 2, 750000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (151, CAST(N'2025-07-01T00:00:00' AS SmallDateTime), 1, 3, 600000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (152, CAST(N'2025-07-02T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (153, CAST(N'2025-07-02T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (154, CAST(N'2025-07-02T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (453, CAST(N'2025-07-03T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (454, CAST(N'2025-07-03T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (455, CAST(N'2025-07-03T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (456, CAST(N'2025-07-04T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (457, CAST(N'2025-07-04T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (458, CAST(N'2025-07-04T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (459, CAST(N'2025-07-05T00:00:00' AS SmallDateTime), 1, 1, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (460, CAST(N'2025-07-05T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (461, CAST(N'2025-07-05T00:00:00' AS SmallDateTime), 1, 3, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (462, CAST(N'2025-07-14T00:00:00' AS SmallDateTime), 3, 1, 100000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (463, CAST(N'2025-07-15T00:00:00' AS SmallDateTime), 3, 2, 200000.0000)
GO
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (464, CAST(N'2025-07-16T00:00:00' AS SmallDateTime), 3, 3, 150000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (465, CAST(N'2025-07-16T00:00:00' AS SmallDateTime), 3, 1, 250000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (466, CAST(N'2025-07-17T00:00:00' AS SmallDateTime), 3, 2, 150000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (467, CAST(N'2025-07-18T00:00:00' AS SmallDateTime), 5, 3, 350000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (468, CAST(N'2025-07-19T00:00:00' AS SmallDateTime), 1, 1, 100000.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (469, CAST(N'2025-07-19T00:00:00' AS SmallDateTime), 1, 2, 0.0000)
INSERT [dbo].[RevenueReport] ([ReportID], [RevenueDate], [UserID], [RoomTierID], [TotalRevenue]) VALUES (470, CAST(N'2025-07-20T00:00:00' AS SmallDateTime), 1, 3, 150000.0000)
SET IDENTITY_INSERT [dbo].[RevenueReport] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Employee')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (1, 1, N'P101      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (2, 1, N'P102      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (3, 1, N'P103      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (4, 1, N'P104      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (5, 1, N'P105      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (6, 1, N'P106      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (7, 1, N'P107      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (8, 1, N'P108      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (9, 1, N'P109      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (10, 1, N'P110      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (11, 2, N'P201      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (12, 2, N'P202      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (13, 2, N'P203      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (14, 2, N'P204      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (15, 2, N'P205      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (16, 2, N'P206      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (17, 2, N'P207      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (18, 2, N'P208      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (19, 2, N'P209      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (20, 2, N'P210      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (21, 2, N'P211      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (22, 2, N'P212      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (23, 2, N'P213      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (24, 2, N'P214      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (25, 2, N'P215      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (26, 3, N'P301      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (27, 3, N'P302      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (28, 3, N'P303      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (29, 3, N'P304      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (30, 3, N'P305      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (31, 3, N'P306      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (32, 3, N'P307      ', N'Occupied')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (33, 3, N'P308      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (34, 3, N'P309      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (35, 3, N'P310      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (46, 1, N'T001      ', N'Available')
INSERT [dbo].[Room] ([RoomID], [RoomTierID], [RoomNumber], [RoomState]) VALUES (48, 1, N'T002      ', N'Available')
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 1)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 1)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 1)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 1)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 1)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 1)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 1)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 2)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 2)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 2)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 2)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 2)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 2)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 2)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 3)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 3)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 3)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 3)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 3)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 3)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 3)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 4)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 4)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 4)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 4)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 4)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 4)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 4)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 5)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 5)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 5)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 5)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 5)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 5)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 5)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 6)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 6)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 6)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 6)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 6)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 6)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 6)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 7)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 7)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 7)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 7)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 7)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 7)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 7)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 8)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 8)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 8)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 8)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 8)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 8)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 8)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 9)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 9)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 9)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 9)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 9)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 9)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 9)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 10)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 10)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 10)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 10)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 10)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 10)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 10)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 11)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 12)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 13)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 14)
GO
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 14)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 15)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 16)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 17)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 18)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 19)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 20)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 21)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 22)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 23)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 24)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 25)
GO
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (8, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 25)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 26)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 27)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 28)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 29)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 30)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 31)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 32)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 33)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 34)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (3, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (7, 35)
GO
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (9, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (10, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (11, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (12, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (13, 35)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (1, 46)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 46)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 46)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (2, 48)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (4, 48)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (5, 48)
INSERT [dbo].[Room_Amenity] ([AmenitiesAmenityID], [RoomsRoomID]) VALUES (6, 48)
GO
SET IDENTITY_INSERT [dbo].[RoomTier] ON 

INSERT [dbo].[RoomTier] ([RoomTierID], [RoomTierName], [RoomTierPrice]) VALUES (1, N'Phòng đơn', 100000.0000)
INSERT [dbo].[RoomTier] ([RoomTierID], [RoomTierName], [RoomTierPrice]) VALUES (2, N'Phòng đôi', 150000.0000)
INSERT [dbo].[RoomTier] ([RoomTierID], [RoomTierName], [RoomTierPrice]) VALUES (3, N'Phòng gia đình', 200000.0000)
SET IDENTITY_INSERT [dbo].[RoomTier] OFF
GO
SET IDENTITY_INSERT [dbo].[Rule] ON 

INSERT [dbo].[Rule] ([RuleID], [RoomMaxCustomer], [SurchargeRate], [CustomerToApplySurchargeRate]) VALUES (1, 3, 25, 3)
SET IDENTITY_INSERT [dbo].[Rule] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (1, N'Lê Quý Bình', N'SxO7+hNgzEbdFCik4ugSRzaSq74VXrK9kbyzirBfTSJcjXCSVIRoStL/+TlpSXAH', N'100000000001', 1, CAST(N'2020-01-01T00:00:00' AS SmallDateTime), N'lequyb@hotel.vn     ', N'0987654321')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (3, N'Đặng Văn Khoa', N'P2r8qd9pmFM7diCyj5Dph6RpZ/e/G5eRIxKNcgvXBhBmtWhYiI75sHpR66QkTYRW', N'100000000003', 2, CAST(N'2021-01-02T00:00:00' AS SmallDateTime), N'dangvank@hotel.vn   ', N'0987654323')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (4, N'Trần Thị Mai', N'j/S2Fc7pmziazetfPr1pF6egPFp9tf5uYxOkLCbm6G1Hf2dhpruujUK7iROiqoSv', N'100000000004', 2, CAST(N'2021-10-03T00:00:00' AS SmallDateTime), N'tranthim@hotel.vn   ', N'0987654324')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (5, N'Phan Thanh Tú', N'vi5OuyCyx/837I0UgwQ8ZwOhy7z0TERYtCx7WNIb5k3TUgXU8ePDt8RbapIjoMuE', N'100000000005', 2, CAST(N'2022-05-04T00:00:00' AS SmallDateTime), N'phathant@hotel.vn   ', N'0987654325')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (6, N'Võ Ngọc An', N'kAPNZeoFNCA8AcoLR7MFShjEYn/Yb2Ysk1ZB6IADClJ2lDAICNt3rVca+7MXH+Wi', N'100000000006', 2, CAST(N'2022-05-20T00:00:00' AS SmallDateTime), N'vongoca@hotel.vn    ', N'0987654326')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (7, N'Bùi Minh Nhật', N'qwPl+gE4IRD1rPDQHHQXoFYVvYCwSsqWK3PrlZAbkj7djfwSiHu3ANDNlp64OmKW', N'100000000007', 2, CAST(N'2023-01-06T00:00:00' AS SmallDateTime), N'buiminnh@hotel.vn   ', N'0987654327')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (8, N'Hồ Thị Kim', N'I5yqL4MqD7eKG5w1f+juxal1j2Mc3pKej7oQGk8viVjiavJg1qyz96RCzbFFhdjn', N'100000000008', 2, CAST(N'2023-07-15T00:00:00' AS SmallDateTime), N'hothik@hotel.vn     ', N'0987654328')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (9, N'Tạ Đình Phong', N'KvDCGRzbfEly+cXK1fF0pfwtUZUCKJ1hfhl+k9Fp8Ss1kmOH7iniOzD2Q1Edt2i5', N'100000000009', 2, CAST(N'2024-01-08T00:00:00' AS SmallDateTime), N'tadinph@hotel.vn    ', N'0987654329')
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IdentityNumber], [RoleID], [WorkingDate], [EmailAddress], [PhoneNumber]) VALUES (10, N'Dương Cẩm Tú', N'AvMg1HxGuf7CFj95ixG4eKWL2PEF5LHa+EVRx3PDNTezLrk9Bpnp+gXzc2+DHDBT', N'100000000010', 2, CAST(N'2024-10-09T00:00:00' AS SmallDateTime), N'duongcamt@hotel.vn  ', N'0987654330')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerTier_CustomerTierID] FOREIGN KEY([CustomerTierID])
REFERENCES [dbo].[CustomerTier] ([CustomerTierID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CustomerTier_CustomerTierID]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Reservation_ReservationID] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Reservation_ReservationID]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_RevenueReport_ReportID] FOREIGN KEY([ReportID])
REFERENCES [dbo].[RevenueReport] ([ReportID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_RevenueReport_ReportID]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_User_UserID]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Room_RoomID] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Room_RoomID]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_User_UserID]
GO
ALTER TABLE [dbo].[Reservation_Customer]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Customer_Customer_CustomersCustomerID] FOREIGN KEY([CustomersCustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation_Customer] CHECK CONSTRAINT [FK_Reservation_Customer_Customer_CustomersCustomerID]
GO
ALTER TABLE [dbo].[Reservation_Customer]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Customer_Reservation_ReservationsReservationID] FOREIGN KEY([ReservationsReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation_Customer] CHECK CONSTRAINT [FK_Reservation_Customer_Reservation_ReservationsReservationID]
GO
ALTER TABLE [dbo].[RevenueReport]  WITH CHECK ADD  CONSTRAINT [FK_RevenueReport_RoomTier_RoomTierID] FOREIGN KEY([RoomTierID])
REFERENCES [dbo].[RoomTier] ([RoomTierID])
GO
ALTER TABLE [dbo].[RevenueReport] CHECK CONSTRAINT [FK_RevenueReport_RoomTier_RoomTierID]
GO
ALTER TABLE [dbo].[RevenueReport]  WITH CHECK ADD  CONSTRAINT [FK_RevenueReport_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[RevenueReport] CHECK CONSTRAINT [FK_RevenueReport_User_UserID]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomTier_RoomTierID] FOREIGN KEY([RoomTierID])
REFERENCES [dbo].[RoomTier] ([RoomTierID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomTier_RoomTierID]
GO
ALTER TABLE [dbo].[Room_Amenity]  WITH CHECK ADD  CONSTRAINT [FK_Room_Amenity_Amenity_AmenitiesAmenityID] FOREIGN KEY([AmenitiesAmenityID])
REFERENCES [dbo].[Amenity] ([AmenityID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Room_Amenity] CHECK CONSTRAINT [FK_Room_Amenity_Amenity_AmenitiesAmenityID]
GO
ALTER TABLE [dbo].[Room_Amenity]  WITH CHECK ADD  CONSTRAINT [FK_Room_Amenity_Room_RoomsRoomID] FOREIGN KEY([RoomsRoomID])
REFERENCES [dbo].[Room] ([RoomID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Room_Amenity] CHECK CONSTRAINT [FK_Room_Amenity_Room_RoomsRoomID]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_RoleID]
GO
