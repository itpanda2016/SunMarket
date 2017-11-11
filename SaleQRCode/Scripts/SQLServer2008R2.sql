USE [master]
GO
/****** Object:  Database [SunMarketCRM]    Script Date: 11/11/2017 15:52:53 ******/
CREATE DATABASE [SunMarketCRM] ON  PRIMARY 
( NAME = N'SunMarketCRM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.PDSQL2008\MSSQL\DATA\SunMarketCRM.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SunMarketCRM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.PDSQL2008\MSSQL\DATA\SunMarketCRM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SunMarketCRM] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SunMarketCRM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SunMarketCRM] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SunMarketCRM] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SunMarketCRM] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SunMarketCRM] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SunMarketCRM] SET ARITHABORT OFF
GO
ALTER DATABASE [SunMarketCRM] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SunMarketCRM] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SunMarketCRM] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SunMarketCRM] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SunMarketCRM] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SunMarketCRM] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SunMarketCRM] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SunMarketCRM] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SunMarketCRM] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SunMarketCRM] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SunMarketCRM] SET  DISABLE_BROKER
GO
ALTER DATABASE [SunMarketCRM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SunMarketCRM] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SunMarketCRM] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SunMarketCRM] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SunMarketCRM] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SunMarketCRM] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SunMarketCRM] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SunMarketCRM] SET  READ_WRITE
GO
ALTER DATABASE [SunMarketCRM] SET RECOVERY FULL
GO
ALTER DATABASE [SunMarketCRM] SET  MULTI_USER
GO
ALTER DATABASE [SunMarketCRM] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SunMarketCRM] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SunMarketCRM', N'ON'
GO
USE [SunMarketCRM]
GO
/****** Object:  Table [dbo].[wechat_qrcode]    Script Date: 11/11/2017 15:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[wechat_qrcode](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gmt_create] [datetime] NOT NULL,
	[gmt_modified] [datetime] NULL,
	[qrcode_type] [varchar](16) NOT NULL,
	[scene_id] [int] NOT NULL,
	[scene_str] [varchar](254) NULL,
	[expire_seconds] [int] NULL,
	[ticket] [varchar](254) NOT NULL,
 CONSTRAINT [PK_wechat_qrcode_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应接口的action_name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wechat_qrcode', @level2type=N'COLUMN',@level2name=N'qrcode_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'只有当qrcode_type =  QR_SCENE/QR_STR_SCENE时才有值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wechat_qrcode', @level2type=N'COLUMN',@level2name=N'expire_seconds'
GO
/****** Object:  Table [dbo].[saler_customer]    Script Date: 11/11/2017 15:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[saler_customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[saler_id] [int] NOT NULL,
	[customer_id] [varchar](254) NOT NULL,
	[gmt_create] [datetime] NOT NULL,
	[gmt_modified] [datetime] NULL,
	[follow_time] [datetime] NOT NULL,
	[qrcode_id] [int] NOT NULL,
 CONSTRAINT [PK_saler_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[crm_saler]    Script Date: 11/11/2017 15:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[crm_saler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gmt_create] [datetime] NOT NULL,
	[gmt_modified] [datetime] NULL,
	[name] [varchar](32) NOT NULL,
	[mobile] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_crm_saler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认为0，如果为-1，则表示离职' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'crm_saler', @level2type=N'COLUMN',@level2name=N'status'
GO
/****** Object:  Default [DF_crm_saler_status]    Script Date: 11/11/2017 15:52:54 ******/
ALTER TABLE [dbo].[crm_saler] ADD  CONSTRAINT [DF_crm_saler_status]  DEFAULT ((0)) FOR [status]
GO
