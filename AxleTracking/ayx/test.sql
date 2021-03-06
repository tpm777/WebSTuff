USE RFDB

/****** Object:  Table [dbo].[Magna Flux TT Operation]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux TT Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Magna Flux TT Operation]
GO
/****** Object:  Table [dbo].[Operators]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operators]') AND type in (N'U'))
DROP TABLE [dbo].[Operators]
GO
/****** Object:  Table [dbo].[Plants]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Plants]') AND type in (N'U'))
DROP TABLE [dbo].[Plants]
GO
/****** Object:  Table [dbo].[WD Operation]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WD Operation]') AND type in (N'U'))
DROP TABLE [dbo].[WD Operation]
GO
/****** Object:  Table [dbo].[Axle Type]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Type]') AND type in (N'U'))
DROP TABLE [dbo].[Axle Type]
GO
/****** Object:  Table [dbo].[AP Operation]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AP Operation]') AND type in (N'U'))
DROP TABLE [dbo].[AP Operation]
GO
/****** Object:  Table [dbo].[ReceiveStatus]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiveStatus]') AND type in (N'U'))
DROP TABLE [dbo].[ReceiveStatus]
GO
/****** Object:  Table [dbo].[BearingDemountStatusCodes]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BearingDemountStatusCodes]') AND type in (N'U'))
DROP TABLE [dbo].[BearingDemountStatusCodes]
GO
/****** Object:  Table [dbo].[WheelDemountStatusCodes]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WheelDemountStatusCodes]') AND type in (N'U'))
DROP TABLE [dbo].[WheelDemountStatusCodes]
GO
/****** Object:  Table [dbo].[Business Rules]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Business Rules]') AND type in (N'U'))
DROP TABLE [dbo].[Business Rules]
GO
/****** Object:  Table [dbo].[Wheel UT Operation]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel UT Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel UT Operation]
GO
/****** Object:  Table [dbo].[Wheel Scrap]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Scrap]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel Scrap]
GO
/****** Object:  Table [dbo].[Axle QA]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle QA]') AND type in (N'U'))
DROP TABLE [dbo].[Axle QA]
GO
/****** Object:  Table [dbo].[Axle UT Operation]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle UT Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Axle UT Operation]
GO
/****** Object:  Table [dbo].[Axle Scrap]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Scrap]') AND type in (N'U'))
DROP TABLE [dbo].[Axle Scrap]
GO
/****** Object:  Table [dbo].[LoadID]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadID]') AND type in (N'U'))
DROP TABLE [dbo].[LoadID]
GO
/****** Object:  Table [dbo].[Wheel Type]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Type]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel Type]
GO
/****** Object:  Table [dbo].[AccessProfiles]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccessProfiles]') AND type in (N'U'))
DROP TABLE [dbo].[AccessProfiles]
GO
/****** Object:  Table [dbo].[Axle]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle]') AND type in (N'U'))
DROP TABLE [dbo].[Axle]
GO
/****** Object:  Table [dbo].[BD Operation]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BD Operation]') AND type in (N'U'))
DROP TABLE [dbo].[BD Operation]
GO
/****** Object:  Table [dbo].[Bearing Mount Operation]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Mount Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Bearing Mount Operation]
GO
/****** Object:  Table [dbo].[Bearing Scrap]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Scrap]') AND type in (N'U'))
DROP TABLE [dbo].[Bearing Scrap]
GO
/****** Object:  Table [dbo].[Bearing Type]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Type]') AND type in (N'U'))
DROP TABLE [dbo].[Bearing Type]
GO
/****** Object:  Table [dbo].[AxleInspectionCodes]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AxleInspectionCodes]') AND type in (N'U'))
DROP TABLE [dbo].[AxleInspectionCodes]
GO
/****** Object:  Table [dbo].[OBLoadIDCounter]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBLoadIDCounter]') AND type in (N'U'))
DROP TABLE [dbo].[OBLoadIDCounter]
GO
/****** Object:  Table [dbo].[OBLoadID]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBLoadID]') AND type in (N'U'))
DROP TABLE [dbo].[OBLoadID]
GO
/****** Object:  Table [dbo].[Work Center]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Work Center]') AND type in (N'U'))
DROP TABLE [dbo].[Work Center]
GO
/****** Object:  Table [dbo].[OBAxle]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBAxle]') AND type in (N'U'))
DROP TABLE [dbo].[OBAxle]
GO
/****** Object:  Table [dbo].[WM Operation]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WM Operation]') AND type in (N'U'))
DROP TABLE [dbo].[WM Operation]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Customer Bearing Reference]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer Bearing Reference]') AND type in (N'U'))
DROP TABLE [dbo].[Customer Bearing Reference]
GO
/****** Object:  Table [dbo].[LoadIDCounter]    Script Date: 12/30/2006 07:06:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadIDCounter]') AND type in (N'U'))
DROP TABLE [dbo].[LoadIDCounter]
GO
/****** Object:  Table [dbo].[LogTrace]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogTrace]') AND type in (N'U'))
DROP TABLE [dbo].[LogTrace]
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Machines]') AND type in (N'U'))
DROP TABLE [dbo].[Machines]
GO
/****** Object:  Table [dbo].[Magna Flux NM Operation]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux NM Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Magna Flux NM Operation]
GO
/****** Object:  Table [dbo].[Wheel Lathe]    Script Date: 12/30/2006 07:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Lathe]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel Lathe]
GO
/****** Object:  Role [AxleTracking]    Script Date: 12/30/2006 07:06:46 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AxleTracking')
BEGIN
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AxleTracking' AND type = 'R')
CREATE ROLE [AxleTracking]

END
GO
/****** Object:  Table [dbo].[Magna Flux TT Operation]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux TT Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Magna Flux TT Operation](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__Tag I__3DDE0E16]  DEFAULT (NULL),
	[MG TT Scrap] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__MG TT__3ED2324F]  DEFAULT (NULL),
	[MG TT Operation] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__MG TT__3FC65688]  DEFAULT (NULL),
	[MG TT DT Stamp] [datetime] NULL,
	[MG TT Operator ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__MG TT__40BA7AC1]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Operators]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operators]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Operators](
	[Operator ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Operators__Opera__42A2C333]  DEFAULT (NULL),
	[Password] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Operators__Passw__4396E76C]  DEFAULT (NULL),
	[User Name] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Operators__User __448B0BA5]  DEFAULT (NULL),
	[Plant ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Operators__Plant__457F2FDE]  DEFAULT (NULL),
	[DefaulrWS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccessProfile] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoginStatus] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
INSERT [dbo].[Operators] ([Operator ID], [Password], [User Name], [Plant ID], [DefaulrWS], [AccessProfile], [LoginStatus]) VALUES (N'D123      ', N'password', N'Mr. Smith', N'13    ', NULL, N'Basic', NULL)
INSERT [dbo].[Operators] ([Operator ID], [Password], [User Name], [Plant ID], [DefaulrWS], [AccessProfile], [LoginStatus]) VALUES (N'D111      ', N'password', N'AxleTracking', N'13    ', NULL, N'Basic', NULL)
INSERT [dbo].[Operators] ([Operator ID], [Password], [User Name], [Plant ID], [DefaulrWS], [AccessProfile], [LoginStatus]) VALUES (N'Admin     ', N'password', N'AxleTracking', N'13    ', NULL, N'Admin', NULL)
/****** Object:  Table [dbo].[Plants]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Plants]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Plants](
	[Plant ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Plants__Plant ID__47677850]  DEFAULT (NULL),
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Plants__Descript__485B9C89]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[WD Operation]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WD Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WD Operation](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WD Operat__Tag I__4A43E4FB]  DEFAULT (NULL),
	[WD Operation] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WD Operat__WD Op__4B380934]  DEFAULT (NULL),
	[WD Result] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WD Operat__WD Re__4C2C2D6D]  DEFAULT (NULL),
	[WD DT Stamp] [datetime] NULL,
	[WD User] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WD Operat__WD Us__4D2051A6]  DEFAULT (NULL),
	[Good Wheels Removed] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WD Operat__Good __4E1475DF]  DEFAULT (NULL),
	[Bad Wheels Removed] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WD Operat__Bad W__4F089A18]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Axle Type]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle Type](
	[Axle Type ID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle Type__Axle __4222D4EF]  DEFAULT (NULL),
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle Type__Descr__4316F928]  DEFAULT (NULL),
	[Manufacturer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle Type__Manuf__440B1D61]  DEFAULT (NULL),
	[Size] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle Type__Size__44FF419A]  DEFAULT (NULL),
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle Type__Type__45F365D3]  DEFAULT (NULL)
)
END
GO
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'50TN', N'5 1/2 X 10 NEW', N'UNKNOWN', N'50', N'NEW')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'50TU', N'5 1/2 X 10 USED', N'NONE', N'50', N'USED')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'50TS', N'5 1/2 X 10 SCRAP', N'NONE', N'50', N'SCRAP')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'70TNSS', N'6 X 11 NEW STD STEEL', N'STANDARD STEEL', N'70', N'NEW')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'70TNSF', N'6 X 11 NEW STD FORGED', N'STANDARD FORGED', N'70', N'NEW')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'70TU', N'6 X 11 USED', N'NONE', N'70', N'USED')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'70TP', N'6 X 11 PLATABLE', N'NONE', N'70', N'PLATABLE')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'70TS', N'6 X 11 SCRAP', N'NONE', N'70', N'SCRAP')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'70TLU', N'6 X 9 USED', N'NONE', N'71', N'USED')
INSERT [dbo].[Axle Type] ([Axle Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'70TLS', N'6 X 9 SCRAP', N'NONE', N'71', N'SCRAP')
/****** Object:  Table [dbo].[AP Operation]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AP Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AP Operation](
	[Tag ID] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__AP Operat__Tag I__54F67D98]  DEFAULT (NULL),
	[Machine ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__AP Operat__Machi__55EAA1D1]  DEFAULT (NULL),
	[APS Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__AP Operat__APS C__56DEC60A]  DEFAULT (NULL),
	[AP Operator ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__AP Operat__AP Op__57D2EA43]  DEFAULT (NULL),
	[AD DT Stamp] [datetime] NULL,
	[Task1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__AP Operat__Task1__58C70E7C]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[ReceiveStatus]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiveStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReceiveStatus](
	[ReceiveStatus] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
INSERT [dbo].[ReceiveStatus] ([ReceiveStatus]) VALUES (N'Good New')
INSERT [dbo].[ReceiveStatus] ([ReceiveStatus]) VALUES (N'Good Used')
INSERT [dbo].[ReceiveStatus] ([ReceiveStatus]) VALUES (N'Scrap')
/****** Object:  Table [dbo].[BearingDemountStatusCodes]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BearingDemountStatusCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BearingDemountStatusCodes](
	[Demount Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
END
GO
INSERT [dbo].[BearingDemountStatusCodes] ([Demount Status]) VALUES (N'Mounted')
INSERT [dbo].[BearingDemountStatusCodes] ([Demount Status]) VALUES (N'One')
INSERT [dbo].[BearingDemountStatusCodes] ([Demount Status]) VALUES (N'None')
/****** Object:  Table [dbo].[WheelDemountStatusCodes]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WheelDemountStatusCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WheelDemountStatusCodes](
	[Demount Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
END
GO
INSERT [dbo].[WheelDemountStatusCodes] ([Demount Status]) VALUES (N'Both')
INSERT [dbo].[WheelDemountStatusCodes] ([Demount Status]) VALUES (N'One')
INSERT [dbo].[WheelDemountStatusCodes] ([Demount Status]) VALUES (N'None')
/****** Object:  Table [dbo].[Business Rules]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Business Rules]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Business Rules](
	[BusinessRuleName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Axle Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Bearing Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wheel Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Wheel Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Bearing 1 Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Bearing 2 Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
INSERT [dbo].[Business Rules] ([BusinessRuleName], [Axle Status], [Bearing Status], [Wheel Status], [Inbound Wheel Status], [Inbound Bearing 1 Status], [Inbound Bearing 2 Status]) VALUES (N'WheelMount', NULL, N'None', N'None', N'Scrap', NULL, NULL)
INSERT [dbo].[Business Rules] ([BusinessRuleName], [Axle Status], [Bearing Status], [Wheel Status], [Inbound Wheel Status], [Inbound Bearing 1 Status], [Inbound Bearing 2 Status]) VALUES (N'BearingMount', NULL, N'None', N'Mounted', NULL, NULL, NULL)
INSERT [dbo].[Business Rules] ([BusinessRuleName], [Axle Status], [Bearing Status], [Wheel Status], [Inbound Wheel Status], [Inbound Bearing 1 Status], [Inbound Bearing 2 Status]) VALUES (N'TurnedTread', NULL, N'None', N'Mounted', N'Good', NULL, NULL)
INSERT [dbo].[Business Rules] ([BusinessRuleName], [Axle Status], [Bearing Status], [Wheel Status], [Inbound Wheel Status], [Inbound Bearing 1 Status], [Inbound Bearing 2 Status]) VALUES (N'WheelDemount', NULL, N'None', N'Mounted', N'Scrap', NULL, NULL)
INSERT [dbo].[Business Rules] ([BusinessRuleName], [Axle Status], [Bearing Status], [Wheel Status], [Inbound Wheel Status], [Inbound Bearing 1 Status], [Inbound Bearing 2 Status]) VALUES (N'Inspection', NULL, N'None', N'Mounted', NULL, NULL, NULL)
/****** Object:  Table [dbo].[Wheel UT Operation]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel UT Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel UT Operation](
	[Tag ID] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel UT __Tag I__5AAF56EE]  DEFAULT (NULL),
	[Wheel UT Operation] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel UT __Wheel__5BA37B27]  DEFAULT (NULL),
	[Wheel UT Scrap] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel UT __Wheel__5C979F60]  DEFAULT (NULL),
	[Wheel UT DT Stamp] [datetime] NULL,
	[Wheel UT Operator ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel UT __Wheel__5D8BC399]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Wheel Scrap]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Scrap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel Scrap](
	[Scrap ID] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Scr__Scrap__5F740C0B]  DEFAULT (NULL),
	[Description] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Scr__Descr__60683044]  DEFAULT (NULL)
)
END
GO
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'1       ', N'Good New')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'2       ', N'Good Used')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'60      ', N'Thin Flange')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'64      ', N'High Flange')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'66      ', N'High Flange')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'73      ', N'Thin Rim')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'74      ', N'Thermal Cracks')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'75      ', N'Tread Shelled')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'76      ', N'Tread Build Up')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'77      ', N'Tread Grooved')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'78      ', N'Slid Flat')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'80      ', N'Gouged Wheel')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'88      ', N'Sub-Surface Defect')
INSERT [dbo].[Wheel Scrap] ([Scrap ID], [Description]) VALUES (N'94      ', N'Weld Arcing')
/****** Object:  Table [dbo].[Axle QA]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle QA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle QA](
	[Tag ID] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Tag ID__625078B6]  DEFAULT (NULL),
	[Created By] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Created__63449CEF]  DEFAULT (NULL),
	[Created On] [datetime] NULL,
	[Closed By] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Closed __6438C128]  DEFAULT (NULL),
	[Closed On] [datetime] NULL,
	[Axle Scrap Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Axle Sc__652CE561]  DEFAULT (NULL),
	[Axle Production Scrap Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Axle Pr__6621099A]  DEFAULT (NULL),
	[Wheel Scrap Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Wheel S__67152DD3]  DEFAULT (NULL),
	[Bearing Scrap Code 1] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Bearing__6809520C]  DEFAULT (NULL),
	[Bearing Scrap Code 2] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Bearing__68FD7645]  DEFAULT (NULL),
	[BD Issue] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__BD Issu__69F19A7E]  DEFAULT (NULL),
	[BD Resolutiuon] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__BD Reso__6AE5BEB7]  DEFAULT (NULL),
	[MG NM Required] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__MG NM R__6BD9E2F0]  DEFAULT (NULL),
	[MG TT Required] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__MG TT R__6CCE0729]  DEFAULT (NULL),
	[Wheel UT Required] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Wheel U__6DC22B62]  DEFAULT (NULL),
	[Axle UT Required] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Axle UT__6EB64F9B]  DEFAULT (NULL),
	[MG NM Scrap Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__MG NM S__6FAA73D4]  DEFAULT (NULL),
	[MG TT Scrap Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__MG TT S__709E980D]  DEFAULT (NULL),
	[Wheel UT Scrap Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Wheel U__7192BC46]  DEFAULT (NULL),
	[Axle UT Scrap Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle QA__Axle UT__7286E07F]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Axle UT Operation]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle UT Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle UT Operation](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle UT O__Tag I__068DD92C]  DEFAULT (NULL),
	[Axle UT Operation] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle UT O__Axle __0781FD65]  DEFAULT (NULL),
	[Axle UT Scrap] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle UT O__Axle __0876219E]  DEFAULT (NULL),
	[Axle UT DT Stamp] [datetime] NULL,
	[Axle UT Operator ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle UT O__Axle __096A45D7]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Axle Scrap]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Scrap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle Scrap](
	[Scrap ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle Scra__Scrap__0B528E49]  DEFAULT (NULL),
	[Description] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle Scra__Descr__0C46B282]  DEFAULT (NULL)
)
END
GO
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'GN    ', N'Good New')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'GP    ', N'Good Plated')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'GU    ', N'Good Used')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'BB    ', N'Broken Bolts')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'BE    ', N'Bent')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'CB    ', N'Cracked Body')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'CF    ', N'Cracked Fillet')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'CJ    ', N'Cracked Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'CS    ', N'Cracked Wheel Seat')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'DJ    ', N'Damaged Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'GB    ', N'Gouged Body')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'LJ    ', N'Long Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'OJ    ', N'Oversize Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SB    ', N'Spun Bearing')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SBY   ', N'Small Body')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SJ    ', N'Small Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SJP   ', N'Small J Plateable')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SR    ', N'Seal Ring')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SRP   ', N'Seal R Plateable')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SS    ', N'Small Wheel Set')
INSERT [dbo].[Axle Scrap] ([Scrap ID], [Description]) VALUES (N'SA    ', N'Scrap Axle')
/****** Object:  Table [dbo].[LoadID]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LoadID](
	[Load ID] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Customer ID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF__LoadID__Customer__656C112C]  DEFAULT (NULL),
	[Qty] [int] NOT NULL
)
END
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel Type](
	[Wheel Type ID] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Typ__Wheel__22751F6C]  DEFAULT (NULL),
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Typ__Descr__236943A5]  DEFAULT (NULL),
	[Manufacturer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Typ__Manuf__245D67DE]  DEFAULT (NULL),
	[Size] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Type__Size__25518C17]  DEFAULT (NULL),
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Type__Type__2645B050]  DEFAULT (NULL)
)
END
GO
INSERT [dbo].[Wheel Type] ([Wheel Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'28NSS', N'28" NEW STANDARD ST', N'STANDARD STEEL', N'28', N'NEW')
INSERT [dbo].[Wheel Type] ([Wheel Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'28NJA', N'28" NEW SUMITOMO', N'SUMITOMO JAPAN', N'28', N'NEW')
INSERT [dbo].[Wheel Type] ([Wheel Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'28NO', N'28"  NEW OTHER', N'OTHER', N'28', N'NEW')
/****** Object:  Table [dbo].[AccessProfiles]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccessProfiles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccessProfiles](
	[ProfileName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AllowedWorkCenterIDs] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_AccessProfiles_ReceiveAxle]  DEFAULT ((0))
)
END
GO
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'RLOAD')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'RAXLES')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KBD')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KWD')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KWM')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KNWL')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KAI')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KFL')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KWSAL')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KLAG')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KCBL')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'CAC')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'CAL1')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'CBAL')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KBM')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Admin', N'ADMIN')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Admin', N'LTRAC')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KUT')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'KTM')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'OBLID')
INSERT [dbo].[AccessProfiles] ([ProfileName], [AllowedWorkCenterIDs]) VALUES (N'Basic', N'OBPA')
/****** Object:  Table [dbo].[Axle]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle](
	[Tag ID] [varchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Tag ID__05A3D694]  DEFAULT (NULL),
	[Load ID] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Created By] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Created By__0697FACD]  DEFAULT (NULL),
	[Created On] [datetime] NULL,
	[Plant ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Plant ID__078C1F06]  DEFAULT (NULL),
	[Inbound Customer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Inbound Cu__0880433F]  DEFAULT (NULL),
	[Inbound Customer Location] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Inbound Cu__09746778]  DEFAULT (NULL),
	[Inbound Axle Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Inbound Ax__0A688BB1]  DEFAULT (NULL),
	[Inbound Bearing Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Inbound Be__0C50D423]  DEFAULT (NULL),
	[Inbound Bearing 1 Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Bearing 1 Scrap Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Bearing 2 Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Bearing 2 Scrap Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Wheel Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Inbound Wh__0B5CAFEA]  DEFAULT (NULL),
	[Inbound Wheel Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Wheel Scrap Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Axle Status Code] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Axle Scrap__0D44F85C]  DEFAULT (NULL),
	[Bearing Status] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Bearing Sc__0F2D40CE]  DEFAULT (NULL),
	[Wheel Status] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Wheel Scra__0E391C95]  DEFAULT (NULL),
	[Outbound Customer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Outbound C__11158940]  DEFAULT (NULL),
	[Outbound Sales Order] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Outbound S__1209AD79]  DEFAULT (NULL),
	[Shipped By] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Shipped By__12FDD1B2]  DEFAULT (NULL),
	[Shipped On] [datetime] NULL,
	[Outbound Axle Type] [char](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Axle Size__13F1F5EB]  DEFAULT (NULL),
	[Outbound Wheel Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Outbound W__14E61A24]  DEFAULT (NULL),
	[Outbound Bearing Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Outbound B__15DA3E5D]  DEFAULT (NULL),
	[Status Code] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Axle__Status Cod__16CE6296]  DEFAULT (NULL)
)
END
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BD Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BD Operation](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__BD Operat__Tag I__17B8652E]  DEFAULT (NULL),
	[BD Operation] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__BD Operat__BD Op__18AC8967]  DEFAULT (NULL),
	[BD Result] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__BD Operat__BD Re__19A0ADA0]  DEFAULT (NULL),
	[BD DT Stamp] [datetime] NULL,
	[BD User] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__BD Operat__BD Us__1A94D1D9]  DEFAULT (NULL),
	[Good Bearings Removed] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__BD Operat__Good __1B88F612]  DEFAULT (NULL),
	[Bad Bearings Removed] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__BD Operat__Bad B__1C7D1A4B]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Bearing Mount Operation]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Mount Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bearing Mount Operation](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing M__Tag I__1E6562BD]  DEFAULT (NULL),
	[Machine ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing M__Machi__1F5986F6]  DEFAULT (NULL),
	[BM Operator ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing M__BM Op__204DAB2F]  DEFAULT (NULL),
	[BM DT Stamp] [datetime] NULL,
	[Bearing Type ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing M__Beari__2141CF68]  DEFAULT (NULL),
	[Customer ID] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing M__Custo__2235F3A1]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Bearing Scrap]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Scrap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bearing Scrap](
	[Scrap ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing S__Scrap__241E3C13]  DEFAULT (NULL),
	[Description] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing S__Descr__2512604C]  DEFAULT (NULL)
)
END
GO
INSERT [dbo].[Bearing Scrap] ([Scrap ID], [Description]) VALUES (N'NB    ', N'New Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID], [Description]) VALUES (N'RB    ', N'Recon Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID], [Description]) VALUES (N'UB    ', N'Used Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID], [Description]) VALUES (N'DB    ', N'Damage Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID], [Description]) VALUES (N'DB    ', N'Scrap Bearing')
/****** Object:  Table [dbo].[Bearing Type]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bearing Type](
	[Bearing Type ID] [varchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing T__Beari__26FAA8BE]  DEFAULT (NULL),
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing T__Descr__27EECCF7]  DEFAULT (NULL),
	[Manufacturer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing T__Manuf__28E2F130]  DEFAULT (NULL),
	[Size] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing Ty__Size__29D71569]  DEFAULT (NULL),
	[Type] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Bearing Ty__Type__2ACB39A2]  DEFAULT (NULL)
)
END
GO
INSERT [dbo].[Bearing Type] ([Bearing Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'B50B', N'50 TON BROKEN BEARING', N'NONE', N'50', N'SCRAP')
INSERT [dbo].[Bearing Type] ([Bearing Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'B50R', N'50 TON RECONDITIONED BRG', N'UNKNOWN', N'50', N'RECON')
INSERT [dbo].[Bearing Type] ([Bearing Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'B50U', N'50 TON GOOD USED BRG', N'NONE', N'50', N'USED')
INSERT [dbo].[Bearing Type] ([Bearing Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'B70B', N'70 TON BROKEN BRG', N'NONE', N'70', N'SCRAP')
INSERT [dbo].[Bearing Type] ([Bearing Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'B70U', N'70 TON GOOD USED BRG', N'NONE', N'70', N'USED')
INSERT [dbo].[Bearing Type] ([Bearing Type ID], [Description], [Manufacturer], [Size], [Type]) VALUES (N'B70N', N'70 TON NEW BRG', N'UNKNOWN', N'70', N'NEW')
/****** Object:  Table [dbo].[AxleInspectionCodes]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AxleInspectionCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AxleInspectionCodes](
	[Status] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
INSERT [dbo].[AxleInspectionCodes] ([Status], [Description]) VALUES (N'Pass', NULL)
INSERT [dbo].[AxleInspectionCodes] ([Status], [Description]) VALUES (N'Fail', NULL)
INSERT [dbo].[AxleInspectionCodes] ([Status], [Description]) VALUES (N'Platable', NULL)
/****** Object:  Table [dbo].[OBLoadIDCounter]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBLoadIDCounter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OBLoadIDCounter](
	[Plant ID] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Counter] [int] NOT NULL
)
END
GO
INSERT [dbo].[OBLoadIDCounter] ([Plant ID], [Counter]) VALUES (N'13', 100002)
/****** Object:  Table [dbo].[OBLoadID]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBLoadID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OBLoadID](
	[OBLoadID] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Customer ID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Qty] [int] NULL
)
END
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Work Center]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Work Center](
	[Work Center ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Work Cent__Work __282DF8C2]  DEFAULT (NULL),
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Work Cent__Descr__29221CFB]  DEFAULT (NULL),
	[Plant ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Work Cent__Plant__2A164134]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[OBAxle]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBAxle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OBAxle](
	[OBLoadID] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Customer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created By] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created On] [datetime] NOT NULL,
	[Axle Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wheel Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Bearing Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wheel 1 Serial Number 1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wheel 1 Serial Number 2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wheel 2 Serial Number 1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wheel 2 Serial Number 2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WM Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WM Operation](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Tag I__4984CAEC]  DEFAULT (NULL),
	[Plant ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Plant__4A78EF25]  DEFAULT (NULL),
	[Machine ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Machi__4B6D135E]  DEFAULT (NULL),
	[WM Operator ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__WM Op__4C613797]  DEFAULT (NULL),
	[WM DT Stamp] [datetime] NULL,
	[Wheel 1 Serial Number 1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Wheel__4D555BD0]  DEFAULT (NULL),
	[Wheel 1 Serial Number 2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Wheel__4E498009]  DEFAULT (NULL),
	[Wheel 2 Serial Number 1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Wheel__4F3DA442]  DEFAULT (NULL),
	[Wheel 2 Serial Number 2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Wheel__5031C87B]  DEFAULT (NULL),
	[Wheel Type ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Wheel__5125ECB4]  DEFAULT (NULL),
	[Misfits] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Misfi__521A10ED]  DEFAULT (NULL),
	[Remounts] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__WM Operat__Remou__530E3526]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[Customer Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Customers__Custo__2CB38214]  DEFAULT (NULL),
	[Customer Location] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Customers__Custo__2DA7A64D]  DEFAULT (NULL),
	[Customer Code] [varchar](35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Customers__Custo__2E9BCA86]  DEFAULT (NULL)
)
END
GO
INSERT [dbo].[Customers] ([Customer Name], [Customer Location], [Customer Code]) VALUES (N'Company A', N'Location A', N'CC1')
INSERT [dbo].[Customers] ([Customer Name], [Customer Location], [Customer Code]) VALUES (N'Company B', N'Location B', N'CC2')
INSERT [dbo].[Customers] ([Customer Name], [Customer Location], [Customer Code]) VALUES (N'Company C', N'Location C', N'CC3')
INSERT [dbo].[Customers] ([Customer Name], [Customer Location], [Customer Code]) VALUES (N'Company D', N'Location D', N'CC4')
/****** Object:  Table [dbo].[Customer Bearing Reference]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer Bearing Reference]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer Bearing Reference](
	[Customer Name] [char](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Customer __Custo__308412F8]  DEFAULT (NULL),
	[Axle Type] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Customer __Axle __31783731]  DEFAULT (NULL),
	[Bearing Type] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Customer __Beari__326C5B6A]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[LoadIDCounter]    Script Date: 12/30/2006 07:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadIDCounter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LoadIDCounter](
	[Plant ID] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Counter] [int] NOT NULL
)
END
GO
INSERT [dbo].[LoadIDCounter] ([Plant ID], [Counter]) VALUES (N'12', 100000)
INSERT [dbo].[LoadIDCounter] ([Plant ID], [Counter]) VALUES (N'13', 100000)
/****** Object:  Table [dbo].[LogTrace]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogTrace]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogTrace](
	[DateTime] [varchar](80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Module] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EventDescription] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Machines]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Machines](
	[Machine ID] [varchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Machines__Descri__363CEC4E]  DEFAULT (NULL),
	[Plant ID] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PROCESS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ALLOWED FUNCTIONS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Machines__ALLOWE__37311087]  DEFAULT (NULL),
	[ASPModuleName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BusinessRule] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'RLOAD', N'RECEIVE LOAD KC', N'13', N'RLOAD', N'RLD', N'ReceiveLoad.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'RAXLES', N'RECEIVE AXLES KC', N'13', N'RLOAD', N'RLD', N'ReceiveAxle.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KBD', N'BEARING DEMOUNT KC', N'13', N'BRG DM', N'BDM', N'BearingDemount.aspx', N'BearingDemount')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KWD', N'WHEEL DEMOUNT KC', N'13', N'WHEEL DM', N'WDM', N'WheelDemount.aspx', N'WheelDemount')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KAI', N'INSPECTION LATHE KC', N'13', N'LOOSE AXLES', N'CIJ, CIB', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KFL', N'SELLERS LATHE KC', N'13', N'LOOSE AXLES', N'CIJ, CIB, RF, RJ', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KWSAL', N'WHEEL SEAT AXLE LATHE KC', N'13', N'LOOSE AXLES', N'CWS, RF', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KCBL', N'CUT BODY AXLE LATHE KC', N'13', N'LOOSE AXLES', N'CB,RF', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KLAM', N'LOOSE AXLE MAGNAFLUX KC', N'13', N'LOOSE AXLES', N'MLA', N'Magna.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KLAG', N'LOOSE AXLE GRINDING KC', N'13', N'LOOSE AXLES', N'RAB', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KWM', N'BORING MILL WHEEL MOUNT KC', N'13', N'WHEEL MOUNT', N'WM', N'WheelMount.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KNWL', N'WHEEL LATHE KC NORTH', N'13', N'TURN TREAD', N'TT', N'TurnTread.aspx', N'TurnTread')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KSWL', N'WHEEL LATHE KC SOUTH', N'13', N'TURN TREAD', N'TT', N'TurnTread.aspx', N'TurnTread')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KTM', N'MOUNTED SET MAG KC', N'13', N'TT INSPECTION', N'TT1', N'Inspection.aspx', N'Inspection')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KUT', N'TT ULTRASONIC TESTING KC', N'13', N'TT INSPECTION', N'TT1', N'Inspection.aspx', N'Inspection')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KWSG', N'WHEEL SET BODY GRINDING KC', N'13', N'WSABR', N'WSABR', NULL, NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'KBM', N'BEARING PRESS KC', N'13', N'BEARING MOUNT', N'MB', N'BearingMount.aspx', N'BearingMount')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'CBD', N'BEARING DEMOUNT TX', N'12', N'BRG DM', N'BDM', N'BearingDemount.aspx', N'BearingDemount')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'CWD', N'WHEEL DEMOUNT TX', N'12', N'WHEEL DM', N'WDM', N'WheelDemount.aspx', N'WheelDemount')
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'CAC', N'AXLE WASHER TX', N'12', N'LOOSE AXLES', N'WAB', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'CAL1', N'AXLE LATHE 1 TX', N'12', N'CIJ', N'CIB, RF, RJ', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'CBAL', N'ACUT BODY AXLE LATHE TX', N'12', N'LOOSE AXLES', N'CB,RF', N'LooseAxles.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'CLAM', N'LOOSE AXLE MAGNAFLUX TX', N'12', N'LOOSE AXLES', N'MLA', N'Magna.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'ADMIN', N'Admin', N'13', N'Administrator', N'MLA', N'Admin.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'LTRAC', N'Admin', N'13', N'Administrator', N'MLA', N'LogTrace.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'OBLID', N'Create OutBound ID', N'13', N'Shipping', N'OBOUT', N'OutBound.aspx', NULL)
INSERT [dbo].[Machines] ([Machine ID], [Description], [Plant ID], [PROCESS], [ALLOWED FUNCTIONS], [ASPModuleName], [BusinessRule]) VALUES (N'OBPA', N'Process Axles For Outboud', N'13', N'Shipping', N'OBPA', N'OBAxles.aspx', NULL)
/****** Object:  Table [dbo].[Magna Flux NM Operation]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux NM Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Magna Flux NM Operation](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__Tag I__391958F9]  DEFAULT (NULL),
	[MG NM Scrap] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__MG NM__3A0D7D32]  DEFAULT (NULL),
	[MG NM Operation] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__MG NM__3B01A16B]  DEFAULT (NULL),
	[MG NM DT Stamp] [datetime] NULL,
	[MG NM Operator ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Magna Flu__MG NM__3BF5C5A4]  DEFAULT (NULL)
)
END
GO
/****** Object:  Table [dbo].[Wheel Lathe]    Script Date: 12/30/2006 07:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Lathe]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel Lathe](
	[Tag ID] [char](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Tag I__3B36AB95]  DEFAULT (NULL),
	[Machine ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Machi__3C2ACFCE]  DEFAULT (NULL),
	[WLS Code] [char](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__WLS C__3D1EF407]  DEFAULT (NULL),
	[WL Operator ID] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__WL Op__3E131840]  DEFAULT (NULL),
	[Wheel Data 1] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__3F073C79]  DEFAULT (NULL),
	[Wheel Data 2] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__3FFB60B2]  DEFAULT (NULL),
	[Wheel Data 3] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__40EF84EB]  DEFAULT (NULL),
	[Wheel Data 4] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__41E3A924]  DEFAULT (NULL),
	[Wheel Data 5] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__42D7CD5D]  DEFAULT (NULL),
	[Wheel Data 6] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__43CBF196]  DEFAULT (NULL),
	[Wheel Data 7] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__44C015CF]  DEFAULT (NULL),
	[Wheel Data 8] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__45B43A08]  DEFAULT (NULL),
	[Wheel Data 9] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__46A85E41]  DEFAULT (NULL),
	[Wheel Data 10] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Wheel Lat__Wheel__479C827A]  DEFAULT (NULL)
)
END
GO
