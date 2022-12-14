USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[City]    Script Date: 26-09-2022 5.36.00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 26-09-2022 5.36.00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[City] [varchar](20) NOT NULL,
	[Department] [varchar](20) NOT NULL,
	[Gender] [varchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityID], [CityName]) VALUES (1, N'New Delhi')
INSERT [dbo].[City] ([CityID], [CityName]) VALUES (2, N'Mumbai')
INSERT [dbo].[City] ([CityID], [CityName]) VALUES (3, N'Hyderabad')
INSERT [dbo].[City] ([CityID], [CityName]) VALUES (4, N'Chennai')
INSERT [dbo].[City] ([CityID], [CityName]) VALUES (5, N'Bengaluru')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
