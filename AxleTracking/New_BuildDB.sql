USE [RFDB]
GO
/****** Object:  Table [dbo].[Axle Scrap]    Script Date: 12/14/2006 09:48:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Scrap]') AND type in (N'U'))
DROP TABLE [dbo].[Axle Scrap]
GO
/****** Object:  Table [dbo].[AccessProfiles]    Script Date: 12/08/2006 07:40:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccessProfiles]') AND type in (N'U'))
DROP TABLE [dbo].[AccessProfiles]

USE [RFDB]
GO
/****** Object:  Table [dbo].[AP Operation]    Script Date: 12/07/2006 23:38:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AP Operation]') AND type in (N'U'))
DROP TABLE [dbo].[AP Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Axle]    Script Date: 12/07/2006 23:38:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle]') AND type in (N'U'))
DROP TABLE [dbo].[Axle]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Axle QA]    Script Date: 12/07/2006 23:39:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle QA]') AND type in (N'U'))
DROP TABLE [dbo].[Axle QA]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Axle Type]    Script Date: 12/07/2006 23:39:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Type]') AND type in (N'U'))
DROP TABLE [dbo].[Axle Type]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Axle UT Operation]    Script Date: 12/07/2006 23:40:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle UT Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Axle UT Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[BD Operation]    Script Date: 12/07/2006 23:40:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BD Operation]') AND type in (N'U'))
DROP TABLE [dbo].[BD Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Bearing Mount Operation]    Script Date: 12/07/2006 23:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Mount Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Bearing Mount Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Bearing Scrap]    Script Date: 12/07/2006 23:41:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Scrap]') AND type in (N'U'))
DROP TABLE [dbo].[Bearing Scrap]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Bearing Type]    Script Date: 12/07/2006 23:41:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Type]') AND type in (N'U'))
DROP TABLE [dbo].[Bearing Type]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Customer Bearing Reference]    Script Date: 12/07/2006 23:42:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer Bearing Reference]') AND type in (N'U'))
DROP TABLE [dbo].[Customer Bearing Reference]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/07/2006 23:42:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]

USE [RFDB]
GO
/****** Object:  Table [dbo].[LoadID]    Script Date: 12/07/2006 23:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadID]') AND type in (N'U'))
DROP TABLE [dbo].[LoadID]
USE [RFDB]
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 12/07/2006 23:43:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Machines]') AND type in (N'U'))
DROP TABLE [dbo].[Machines]
USE [RFDB]
GO
/****** Object:  Table [dbo].[Magna Flux NM Operation]    Script Date: 12/07/2006 23:44:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux NM Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Magna Flux NM Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Magna Flux TT Operation]    Script Date: 12/07/2006 23:44:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux TT Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Magna Flux TT Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Operators]    Script Date: 12/07/2006 23:44:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operators]') AND type in (N'U'))
DROP TABLE [dbo].[Operators]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Plants]    Script Date: 12/07/2006 23:45:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Plants]') AND type in (N'U'))
DROP TABLE [dbo].[Plants]

USE [RFDB]
GO
/****** Object:  Table [dbo].[WD Operation]    Script Date: 12/07/2006 23:45:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WD Operation]') AND type in (N'U'))
DROP TABLE [dbo].[WD Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Wheel Lathe]    Script Date: 12/07/2006 23:46:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Lathe]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel Lathe]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Wheel Scrap]    Script Date: 12/07/2006 23:46:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Scrap]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel Scrap]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Wheel Type]    Script Date: 12/07/2006 23:47:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Type]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel Type]
USE [RFDB]
GO
/****** Object:  Table [dbo].[Wheel UT Operation]    Script Date: 12/07/2006 23:47:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel UT Operation]') AND type in (N'U'))
DROP TABLE [dbo].[Wheel UT Operation]
USE [RFDB]
GO
/****** Object:  Table [dbo].[WM Operation]    Script Date: 12/07/2006 23:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WM Operation]') AND type in (N'U'))
DROP TABLE [dbo].[WM Operation]

USE [RFDB]
GO
/****** Object:  Table [dbo].[LoadIDCounter]    Script Date: 12/08/2006 10:09:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadIDCounter]') AND type in (N'U'))
DROP TABLE [dbo].[LoadIDCounter]

USE [RFDB]
GO
/****** Object:  Table [dbo].[Business Rules]    Script Date: 12/24/2006 10:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Business Rules](
	[BusinessRuleName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Axle Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Bearing Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wheel Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Wheel Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Bearing 1 Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inbound Bearing 2 Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Lathe]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel Lathe](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[Machine ID] [char](10) NULL DEFAULT (NULL),
	[WLS Code] [char](4) NULL DEFAULT (NULL),
	[WL Operator ID] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 1] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 2] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 3] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 4] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 5] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 6] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 7] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 8] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 9] [char](10) NULL DEFAULT (NULL),
	[Wheel Data 10] [char](10) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WM Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WM Operation](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[Plant ID] [char](6) NULL DEFAULT (NULL),
	[Machine ID] [char](10) NULL DEFAULT (NULL),
	[WM Operator ID] [char](10) NULL DEFAULT (NULL),
	[WM DT Stamp] [datetime] NULL,
	[Wheel 1 Serial Number 1] [char](25) NULL DEFAULT (NULL),
	[Wheel 1 Serial Number 2] [char](25) NULL DEFAULT (NULL),
	[Wheel 2 Serial Number 1] [char](25) NULL DEFAULT (NULL),
	[Wheel 2 Serial Number 2] [char](25) NULL DEFAULT (NULL),
	[Wheel Type ID] [char](6) NULL DEFAULT (NULL),
	[Misfits] [char](6) NULL DEFAULT (NULL),
	[Remounts] [char](6) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AP Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AP Operation](
	[Tag ID] [char](8) NULL DEFAULT (NULL),
	[Machine ID] [char](10) NULL DEFAULT (NULL),
	[APS Code] [char](4) NULL DEFAULT (NULL),
	[AP Operator ID] [char](10) NULL DEFAULT (NULL),
	[AD DT Stamp] [datetime] NULL,
	[Task1] [varchar](50) NULL DEFAULT (NULL)
) ON [PRIMARY]
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel UT Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel UT Operation](
	[Tag ID] [char](8) NULL DEFAULT (NULL),
	[Wheel UT Operation] [char](1) NULL DEFAULT (NULL),
	[Wheel UT Scrap] [char](1) NULL DEFAULT (NULL),
	[Wheel UT DT Stamp] [datetime] NULL,
	[Wheel UT Operator ID] [char](6) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Scrap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel Scrap](
	[Scrap ID] [char](8) NULL DEFAULT (NULL),
	[Description] [varchar](20) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle QA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle QA](
	[Tag ID] [char](8) NULL DEFAULT (NULL),
	[Created By] [varchar](35) NULL DEFAULT (NULL),
	[Created On] [datetime] NULL,
	[Closed By] [varchar](35) NULL DEFAULT (NULL),
	[Closed On] [datetime] NULL,
	[Axle Scrap Code] [char](4) NULL DEFAULT (NULL),
	[Axle Production Scrap Code] [char](4) NULL DEFAULT (NULL),
	[Wheel Scrap Code] [char](4) NULL DEFAULT (NULL),
	[Bearing Scrap Code 1] [char](4) NULL DEFAULT (NULL),
	[Bearing Scrap Code 2] [char](4) NULL DEFAULT (NULL),
	[BD Issue] [char](4) NULL DEFAULT (NULL),
	[BD Resolutiuon] [char](4) NULL DEFAULT (NULL),
	[MG NM Required] [char](1) NULL DEFAULT (NULL),
	[MG TT Required] [char](1) NULL DEFAULT (NULL),
	[Wheel UT Required] [char](1) NULL DEFAULT (NULL),
	[Axle UT Required] [char](1) NULL DEFAULT (NULL),
	[MG NM Scrap Code] [char](4) NULL DEFAULT (NULL),
	[MG TT Scrap Code] [char](4) NULL DEFAULT (NULL),
	[Wheel UT Scrap Code] [char](4) NULL DEFAULT (NULL),
	[Axle UT Scrap Code] [char](4) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Work Center]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Work Center](
	[Work Center ID] [char](6) NULL DEFAULT (NULL),
	[Description] [varchar](50) NULL DEFAULT (NULL),
	[Plant ID] [char](6) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle](
	[Tag ID] [varchar](6) NULL CONSTRAINT [DF__Axle__Tag ID__05A3D694]  DEFAULT (NULL),
	[Load ID] [varchar](8) NULL,
	[Created By] [varchar](35) NULL CONSTRAINT [DF__Axle__Created By__0697FACD]  DEFAULT (NULL),
	[Created On] [datetime] NULL,
	[Plant ID] [char](6) NULL CONSTRAINT [DF__Axle__Plant ID__078C1F06]  DEFAULT (NULL),
	[Inbound Customer] [varchar](50) NULL CONSTRAINT [DF__Axle__Inbound Cu__0880433F]  DEFAULT (NULL),
	[Inbound Customer Location] [varchar](50) NULL CONSTRAINT [DF__Axle__Inbound Cu__09746778]  DEFAULT (NULL),
	[Inbound Axle Type] [varchar](50) NULL CONSTRAINT [DF__Axle__Inbound Ax__0A688BB1]  DEFAULT (NULL),
	[Inbound Bearing Type] [varchar](50) NULL CONSTRAINT [DF__Axle__Inbound Be__0C50D423]  DEFAULT (NULL),
	[Inbound Bearing 1 Status] [varchar](50) NULL,
	[Inbound Bearing 1 Scrap Code] [varchar](50) NULL,

	[Inbound Bearing 2 Status] [varchar](50) NULL,
	[Inbound Bearing 2 Scrap Code] [varchar](50) NULL,

	[Inbound Wheel Type] [varchar](50) NULL CONSTRAINT [DF__Axle__Inbound Wh__0B5CAFEA]  DEFAULT (NULL),
	[Inbound Wheel Status] [varchar](50) NULL,
	[Inbound Wheel Scrap Code] [varchar](50) NULL,



	[Axle Status Code] [varchar](35) NULL CONSTRAINT [DF__Axle__Axle Scrap__0D44F85C]  DEFAULT (NULL),
	[Bearing Status] [varchar](35) NULL CONSTRAINT [DF__Axle__Bearing Sc__0F2D40CE]  DEFAULT (NULL),
	[Wheel Status] [varchar](35) NULL CONSTRAINT [DF__Axle__Wheel Scra__0E391C95]  DEFAULT (NULL),
	[Outbound Customer] [varchar](50) NULL CONSTRAINT [DF__Axle__Outbound C__11158940]  DEFAULT (NULL),
	[Outbound Sales Order] [varchar](20) NULL CONSTRAINT [DF__Axle__Outbound S__1209AD79]  DEFAULT (NULL),
	[Shipped By] [varchar](50) NULL CONSTRAINT [DF__Axle__Shipped By__12FDD1B2]  DEFAULT (NULL),
	[Shipped On] [datetime] NULL,
	[Outbound Axle Type] [char](20) NULL CONSTRAINT [DF__Axle__Axle Size__13F1F5EB]  DEFAULT (NULL),
	[Outbound Wheel Type] [varchar](50) NULL CONSTRAINT [DF__Axle__Outbound W__14E61A24]  DEFAULT (NULL),
	[Outbound Bearing Type] [varchar](50) NULL CONSTRAINT [DF__Axle__Outbound B__15DA3E5D]  DEFAULT (NULL),
	[Status Code] [char](10) NULL CONSTRAINT [DF__Axle__Status Cod__16CE6296]  DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle UT Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle UT Operation](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[Axle UT Operation] [char](1) NULL DEFAULT (NULL),
	[Axle UT Scrap] [char](1) NULL DEFAULT (NULL),
	[Axle UT DT Stamp] [datetime] NULL,
	[Axle UT Operator ID] [char](6) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Scrap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle Scrap](
	[Scrap ID] [char](6) NULL DEFAULT (NULL),
	[Description] [varchar](20) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LoadID](
	[Load ID] [varchar](8) NOT NULL,
	[Customer ID] [varchar](50) NOT NULL CONSTRAINT [DF__LoadID__Customer__656C112C]  DEFAULT (NULL),
	[Qty] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wheel Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wheel Type](
	[Wheel Type ID] [varchar](10) NULL CONSTRAINT [DF__Wheel Typ__Wheel__22751F6C]  DEFAULT (NULL),
	[Description] [varchar](50) NULL CONSTRAINT [DF__Wheel Typ__Descr__236943A5]  DEFAULT (NULL),
	[Manufacturer] [varchar](50) NULL CONSTRAINT [DF__Wheel Typ__Manuf__245D67DE]  DEFAULT (NULL),
	[Size] [char](2) NULL CONSTRAINT [DF__Wheel Type__Size__25518C17]  DEFAULT (NULL),
	[Type] [varchar](50) NULL CONSTRAINT [DF__Wheel Type__Type__2645B050]  DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccessProfiles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccessProfiles](
	[ProfileName] [varchar](50) NOT NULL,
	[AllowedWorkCenterIDs] [varchar](50) NOT NULL CONSTRAINT [DF_AccessProfiles_ReceiveAxle]  DEFAULT ((0))
) ON [PRIMARY]
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BD Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BD Operation](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[BD Operation] [char](1) NULL DEFAULT (NULL),
	[BD Result] [char](1) NULL DEFAULT (NULL),
	[BD DT Stamp] [datetime] NULL,
	[BD User] [char](10) NULL DEFAULT (NULL),
	[Good Bearings Removed] [char](2) NULL DEFAULT (NULL),
	[Bad Bearings Removed] [char](2) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Mount Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bearing Mount Operation](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[Machine ID] [char](10) NULL DEFAULT (NULL),
	[BM Operator ID] [char](10) NULL DEFAULT (NULL),
	[BM DT Stamp] [datetime] NULL,
	[Bearing Type ID] [char](10) NULL DEFAULT (NULL),
	[Customer ID] [varchar](20) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Scrap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bearing Scrap](
	[Scrap ID] [char](6) NULL DEFAULT (NULL),
	[Description] [varchar](20) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bearing Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bearing Type](
	[Bearing Type ID] [varchar](6) NULL DEFAULT (NULL),
	[Description] [varchar](50) NULL DEFAULT (NULL),
	[Manufacturer] [varchar](50) NULL DEFAULT (NULL),
	[Size] [char](2) NULL DEFAULT (NULL),
	[Type] [varchar](20) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[Customer Name] [varchar](50) NULL DEFAULT (NULL),
	[Customer Location] [varchar](35) NULL DEFAULT (NULL),
	[Customer Code] [varchar](35) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer Bearing Reference]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer Bearing Reference](
	[Customer Name] [char](50) NULL DEFAULT (NULL),
	[Axle Type] [char](2) NULL DEFAULT (NULL),
	[Bearing Type] [char](10) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO


USE [RFDB]
GO
/****** Object:  Table [dbo].[LoadIDCounter]    Script Date: 12/08/2006 10:04:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoadIDCounter](
	[Plant ID] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Counter] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


USE [RFDB]
GO
/****** Object:  Table [dbo].[LogTrace]    Script Date: 12/19/2006 11:58:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogTrace]') AND type in (N'U'))
DROP TABLE [dbo].[LogTrace]


USE [RFDB]
GO
/****** Object:  Table [dbo].[LogTrace]    Script Date: 12/19/2006 11:58:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogTrace](
	[DateTime] [varchar](80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Module] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EventDescription] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Machines]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Machines](
	[Machine ID] [varchar](6) NOT NULL,
	[Description] [varchar](50) NULL DEFAULT (NULL),
	[Plant ID] [char](2) NOT NULL,
	[PROCESS] [varchar](50) NOT NULL,
	[ALLOWED FUNCTIONS] [varchar](50) NULL DEFAULT (NULL),
	[ASPModuleName] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux NM Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Magna Flux NM Operation](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[MG NM Scrap] [char](1) NULL DEFAULT (NULL),
	[MG NM Operation] [char](1) NULL DEFAULT (NULL),
	[MG NM DT Stamp] [datetime] NULL,
	[MG NM Operator ID] [char](6) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Magna Flux TT Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Magna Flux TT Operation](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[MG TT Scrap] [char](1) NULL DEFAULT (NULL),
	[MG TT Operation] [char](1) NULL DEFAULT (NULL),
	[MG TT DT Stamp] [datetime] NULL,
	[MG TT Operator ID] [char](6) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operators]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Operators](
	[Operator ID] [char](10) NULL DEFAULT (NULL),
	[Password] [varchar](35) NULL DEFAULT (NULL),
	[User Name] [varchar](35) NULL DEFAULT (NULL),
	[Plant ID] [char](6) NULL DEFAULT (NULL),
	[DefaulrWS] [varchar](50) NULL,
	[AccessProfile] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Plants]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Plants](
	[Plant ID] [char](6) NULL DEFAULT (NULL),
	[Description] [varchar](50) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WD Operation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WD Operation](
	[Tag ID] [char](6) NULL DEFAULT (NULL),
	[WD Operation] [char](1) NULL DEFAULT (NULL),
	[WD Result] [char](1) NULL DEFAULT (NULL),
	[WD DT Stamp] [datetime] NULL,
	[WD User] [char](10) NULL DEFAULT (NULL),
	[Good Wheels Removed] [char](2) NULL DEFAULT (NULL),
	[Bad Wheels Removed] [char](2) NULL DEFAULT (NULL)
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Axle Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Axle Type](
	[Axle Type ID] [varchar](50) NULL CONSTRAINT [DF__Axle Type__Axle __4222D4EF]  DEFAULT (NULL),
	[Description] [varchar](50) NULL CONSTRAINT [DF__Axle Type__Descr__4316F928]  DEFAULT (NULL),
	[Manufacturer] [varchar](50) NULL CONSTRAINT [DF__Axle Type__Manuf__440B1D61]  DEFAULT (NULL),
	[Size] [varchar](50) NULL CONSTRAINT [DF__Axle Type__Size__44FF419A]  DEFAULT (NULL),
	[Type] [varchar](50) NULL CONSTRAINT [DF__Axle Type__Type__45F365D3]  DEFAULT (NULL)
) ON [PRIMARY]
END

USE [RFDB]
GO
/****** Object:  Table [dbo].[ReceiveStatus]    Script Date: 12/19/2006 10:41:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiveStatus]') AND type in (N'U'))
DROP TABLE [dbo].[ReceiveStatus]

USE [RFDB]
GO
/****** Object:  Table [dbo].[ReceiveStatus]    Script Date: 12/19/2006 10:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReceiveStatus](
	[ReceiveStatus] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','RLOAD')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','RAXLES')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KBD')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KWD')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KWM')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KNWL')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KAI')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KFL')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KWSAL')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KLAG')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KCBL')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','CAC')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','CAL1')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','CBAL')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Basic','KBM')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Admin','ADMIN')
INSERT INTO [AccessProfiles] ([ProfileName],[AllowedWorkCenterIDs])VALUES('Admin','LTRAC')







INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('1','Good New')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('2','Good Used')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('60','Thin Flange')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('64','High Flange')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('66','High Flange')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('73','Thin Rim')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('74','Thermal Cracks')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('75','Tread Shelled')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('76','Tread Build Up')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('77','Tread Grooved')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('78','Slid Flat')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('80','Gouged Wheel')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('88','Sub-Surface Defect')
INSERT [dbo].[Wheel Scrap] ([Scrap ID],[Description])VALUES('94','Weld Arcing')


INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('GN','Good New')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('GP','Good Plated')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('GU','Good Used')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('BB','Broken Bolts')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('BE','Bent')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('CB','Cracked Body')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('CF','Cracked Fillet')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('CJ','Cracked Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('CS','Cracked Wheel Seat')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('DJ','Damaged Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('GB','Gouged Body')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('LJ','Long Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('OJ','Oversize Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SB','Spun Bearing')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SBY','Small Body')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SJ','Small Journal')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SJP','Small J Plateable')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SR','Seal Ring')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SRP','Seal R Plateable')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SS','Small Wheel Set')
INSERT [dbo].[Axle Scrap] ([Scrap ID],[Description])VALUES('SA','Scrap Axle')



INSERT [dbo].[Wheel Type] ([Wheel Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('28NSS','28" NEW STANDARD ST','STANDARD STEEL','28','NEW')
INSERT [dbo].[Wheel Type] ([Wheel Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('28NJA','28" NEW SUMITOMO','SUMITOMO JAPAN','28','NEW')
INSERT [dbo].[Wheel Type] ([Wheel Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('28NO','28"  NEW OTHER','OTHER','28','NEW')

INSERT [dbo].[Bearing Scrap] ([Scrap ID],[Description])VALUES('NB','New Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID],[Description])VALUES('RB','Recon Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID],[Description])VALUES('UB','Used Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID],[Description])VALUES('DB','Damage Bearing')
INSERT [dbo].[Bearing Scrap] ([Scrap ID],[Description])VALUES('DB','Scrap Bearing')


INSERT [dbo].[Bearing Type] ([Bearing Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('B50B','50 TON BROKEN BEARING','NONE','50','SCRAP')
INSERT [dbo].[Bearing Type] ([Bearing Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('B50R','50 TON RECONDITIONED BRG','UNKNOWN','50','RECON')
INSERT [dbo].[Bearing Type] ([Bearing Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('B50U','50 TON GOOD USED BRG','NONE','50','USED')
INSERT [dbo].[Bearing Type] ([Bearing Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('B70B','70 TON BROKEN BRG','NONE','70','SCRAP')
INSERT [dbo].[Bearing Type] ([Bearing Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('B70U','70 TON GOOD USED BRG','NONE','70','USED')
INSERT [dbo].[Bearing Type] ([Bearing Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('B70N','70 TON NEW BRG','UNKNOWN','70','NEW')


INSERT [dbo].[Customers] ([Customer Name],[Customer Location],[Customer Code])VALUES('Company A','Location A','CC1')
INSERT [dbo].[Customers] ([Customer Name],[Customer Location],[Customer Code])VALUES('Company B','Location B','CC2')
INSERT [dbo].[Customers] ([Customer Name],[Customer Location],[Customer Code])VALUES('Company C','Location C','CC3')
INSERT [dbo].[Customers] ([Customer Name],[Customer Location],[Customer Code])VALUES('Company D','Location D','CC4')

INSERT INTO [LoadIDCounter] ([Plant ID],[Counter])VALUES('12',100000)
INSERT INTO [LoadIDCounter] ([Plant ID],[Counter])VALUES('13',100000)



INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('RLOAD','RECEIVE LOAD KC','13','RLOAD','RLD','ReceiveLoad.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('RAXLES','RECEIVE AXLES KC','13','RLOAD','RLD','ReceiveAxle.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KBD','BEARING DEMOUNT KC','13','BRG DM','BDM','BearingDemount.aspx','BearingDemount')
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KWD','WHEEL DEMOUNT KC','13','WHEEL DM','WDM','WheelDemount.aspx','WheelDemount')
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KAI','INSPECTION LATHE KC','13','LOOSE AXLES','CIJ, CIB','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KFL','SELLERS LATHE KC','13','LOOSE AXLES','CIJ, CIB, RF, RJ','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KWSAL','WHEEL SEAT AXLE LATHE KC','13','LOOSE AXLES','CWS, RF','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KCBL','CUT BODY AXLE LATHE KC','13','LOOSE AXLES','CB,RF','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KLAM','LOOSE AXLE MAGNAFLUX KC','13','LOOSE AXLES','MLA','Magna.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KLAG','LOOSE AXLE GRINDING KC','13','LOOSE AXLES','RAB','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KWM','BORING MILL WHEEL MOUNT KC','13','WHEEL MOUNT','WM','WheelMount.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KNWL','WHEEL LATHE KC NORTH','13','TURN TREAD','TT','TurnTread.aspx','TurnTread')
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KSWL','WHEEL LATHE KC SOUTH','13','TURN TREAD','TT','TurnTread.aspx','TurnTread')
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KTM','MOUNTED SET MAG KC','13','TT INSPECTION','TT1','Magna.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KUT','TT ULTRASONIC TESTING KC','13','TT INSPECTION','TT1','Magna.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KWSG','WHEEL SET BODY GRINDING KC','13','WSABR','WSABR',NULL,NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('KBM','BEARING PRESS KC','13','BEARING MOUNT','MB','BearingMount.aspx','BearingMount')
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('CBD','BEARING DEMOUNT TX','12','BRG DM','BDM','BearingDemount.aspx','BearingDemount')
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('CWD','WHEEL DEMOUNT TX','12','WHEEL DM','WDM','WheelDemount.aspx','WheelDemount')
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('CAC','AXLE WASHER TX','12','LOOSE AXLES','WAB','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('CAL1','AXLE LATHE 1 TX','12','CIJ','CIB, RF, RJ','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('CBAL','ACUT BODY AXLE LATHE TX','12','LOOSE AXLES','CB,RF','LooseAxles.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('CLAM','LOOSE AXLE MAGNAFLUX TX','12','LOOSE AXLES','MLA','Magna.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('ADMIN','Admin','13','Administrator','MLA','Admin.aspx',NULL)
INSERT INTO [Machines] ([Machine ID],[Description],[Plant ID],[PROCESS],[ALLOWED FUNCTIONS],[ASPModuleName],[BusinessRule])VALUES('LTRAC','Admin','13','Administrator','MLA','LogTrace.aspx',NULL)

INSERT INTO [Operators] ([Operator ID],[Password], [User Name],[Plant ID],[DefaulrWS],[AccessProfile])VALUES('D123','password','Mr. Smith','13',NULL,'Basic')
INSERT INTO [Operators] ([Operator ID],[Password], [User Name],[Plant ID],[DefaulrWS],[AccessProfile])VALUES('D111','password','AxleTracking','13',NULL,'Basic')
INSERT INTO [Operators] ([Operator ID],[Password], [User Name],[Plant ID],[DefaulrWS],[AccessProfile])VALUES('Admin','password','AxleTracking','13',NULL,'Admin')

INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('50TN','5 1/2 X 10 NEW','UNKNOWN','50','NEW')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('50TU','5 1/2 X 10 USED','NONE','50','USED')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('50TS','5 1/2 X 10 SCRAP','NONE','50','SCRAP')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('70TNSS','6 X 11 NEW STD STEEL','STANDARD STEEL','70','NEW')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('70TNSF','6 X 11 NEW STD FORGED','STANDARD FORGED','70','NEW')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('70TU','6 X 11 USED','NONE','70','USED')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('70TP','6 X 11 PLATABLE','NONE','70','PLATABLE')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('70TS','6 X 11 SCRAP','NONE','70','SCRAP')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('70TLU','6 X 9 USED','NONE','71','USED')
INSERT [dbo].[Axle Type] ([Axle Type ID],[Description],[Manufacturer],[Size],[Type])VALUES('70TLS','6 X 9 SCRAP','NONE','71','SCRAP')



USE [RFDB]
GO
/****** Object:  Table [dbo].[BearingDemountStatusCodes]    Script Date: 12/10/2006 14:10:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BearingDemountStatusCodes]') AND type in (N'U'))
DROP TABLE [dbo].[BearingDemountStatusCodes]

USE [RFDB]
GO
/****** Object:  Table [dbo].[BearingDemountStatusCodes]    Script Date: 12/10/2006 14:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BearingDemountStatusCodes](
	[Demount Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

INSERT INTO [BearingDemountStatusCodes] ([Demount Status])VALUES('Mounted')
INSERT INTO [BearingDemountStatusCodes] ([Demount Status])VALUES('One')
INSERT INTO [BearingDemountStatusCodes] ([Demount Status])VALUES('None')


USE [RFDB]
GO
/****** Object:  Table [dbo].[BearingDemountStatusCodes]    Script Date: 12/10/2006 14:10:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WheelDemountStatusCodes]') AND type in (N'U'))
DROP TABLE [dbo].[WheelDemountStatusCodes]

USE [RFDB]
GO
/****** Object:  Table [dbo].[WheelDemountStatusCodes]    Script Date: 12/10/2006 14:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WheelDemountStatusCodes](
	[Demount Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

INSERT INTO [WheelDemountStatusCodes] ([Demount Status])VALUES('Mounted')
INSERT INTO [WheelDemountStatusCodes] ([Demount Status])VALUES('None')
INSERT INTO [WheelDemountStatusCodes] ([Demount Status])VALUES('Scrap');


INSERT INTO [ReceiveStatus] ([ReceiveStatus])VALUES('Good New')
INSERT INTO [ReceiveStatus] ([ReceiveStatus])VALUES('Good Used')
INSERT INTO [ReceiveStatus] ([ReceiveStatus])VALUES('Scrap')

INSERT INTO [Business Rules] ([BusinessRuleName],[Axle Status],[Bearing Status],[Wheel Status],[Inbound Wheel Status],[Inbound Bearing 1 Status],[Inbound Bearing 2 Status])VALUES('WheelMount',NULL,'None','None','Scrap',NULL,NULL)
INSERT INTO [Business Rules] ([BusinessRuleName],[Axle Status],[Bearing Status],[Wheel Status],[Inbound Wheel Status],[Inbound Bearing 1 Status],[Inbound Bearing 2 Status])VALUES('BearingMount',NULL,'None','Mounted',NULL,NULL,NULL)