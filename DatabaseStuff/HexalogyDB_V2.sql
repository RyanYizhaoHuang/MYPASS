USE [master]
GO
if exists (select * from sysdatabases where name='HexylogyDB')
		drop database HexylogyDB
GO
/****** Object:  Database [HexylogyDB]******/
CREATE DATABASE [HexylogyDB]
ALTER DATABASE HexylogyDB MODIFY FILE
( NAME = N'HexylogyDB', SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
ALTER DATABASE HexylogyDB MODIFY FILE
( NAME = N'HexylogyDB_log', SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [HexylogyDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HexylogyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HexylogyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HexylogyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HexylogyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HexylogyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HexylogyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HexylogyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HexylogyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HexylogyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HexylogyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HexylogyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HexylogyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HexylogyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HexylogyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HexylogyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HexylogyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HexylogyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HexylogyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HexylogyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HexylogyDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HexylogyDB] SET  MULTI_USER 
GO
ALTER DATABASE [HexylogyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HexylogyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HexylogyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HexylogyDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HexylogyDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HexylogyDB', N'ON'
GO
USE [HexylogyDB]
GO
/****** Object:  Table [dbo].[Categories]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserAccountID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[SecurityType] [int] NULL,
	[SecurityQuestion] [varchar](50) NULL,
	[SecurityAnswer] [varchar](50) NULL,
	[KPI] [varchar](50) NULL,
	CONSTRAINT [SecurityType] CHECK ([SecurityType] BETWEEN 0 and 1 ),/*SecurityType only accept 0 or 1*/
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRecord]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRecord](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserPassword] [varchar](50) NULL,
	[Note] [varchar](50) NULL,
	[UserAccountID] [int] NULL,
	CONSTRAINT [FK_UserRecord_UserAccount] FOREIGN KEY 
	(
		[UserAccountID]
	) REFERENCES [dbo].[UserAccount] (
		[UserAccountID]
	),
 CONSTRAINT [PK_UserRecord] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRecordCategories]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRecordCategories](
	[RecordID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	CONSTRAINT [FK_UserRecordCategories_UserRecord] FOREIGN KEY 
	(
		[RecordID]
	) REFERENCES [dbo].[UserRecord] (
		[RecordID]
	),
		CONSTRAINT [FK_UserRecordCategories_Categories] FOREIGN KEY 
	(
		[CategoryID]
	) REFERENCES [dbo].[Categories] (
		[CategoryID]
	),
 CONSTRAINT [PK_UserRecordCategories_UserRecord] PRIMARY KEY CLUSTERED 
(
	[RecordID],[CategoryID]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
set identity_insert [UserAccount] on
GO
INSERT [UserAccount] ([UserAccountID],[Name],[Password],[SecurityType],[SecurityQuestion],[SecurityAnswer],[KPI]) Values (1,'Hexalogy','admin',0,'Who is our master','Taera','')
GO
set identity_insert [UserAccount] off
GO
INSERT [UserRecord] ([UserName],[UserPassword],[Note],[UserAccountID]) Values ('Westboro','PW1','Note 1',1)
INSERT [UserRecord] ([UserName],[UserPassword],[Note],[UserAccountID])Values ('Ryan','PW2','Note 2',1)
INSERT [UserRecord] ([UserName],[UserPassword],[Note],[UserAccountID])Values ('Giho','PW3','Note 3',1)
INSERT [UserRecord] ([UserName],[UserPassword],[Note],[UserAccountID])Values ('Taera','PW4','Note 4',1)
INSERT [UserRecord] ([UserName],[UserPassword],[Note],[UserAccountID])Values ('Dom','PW5','Note 5',1)
INSERT [UserRecord] ([UserName],[UserPassword],[Note],[UserAccountID])Values ('Mekhal','PW6','Note 6',1)
INSERT [UserRecord] ([UserName],[UserPassword],[Note],[UserAccountID])Values ('Partik','PW7','Note 7',1)
GO
INSERT [Categories] ([CategoryName]) Values ('Centennial')
INSERT [Categories] ([CategoryName]) Values ('Google')
GO
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (1,1)
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (1,2)
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (2,1)
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (3,1)
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (3,2)
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (4,2)
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (5,1)
INSERT [UserRecordCategories]([RecordID],[CategoryID]) Values (5,2)
GO
USE [master]
GO
ALTER DATABASE [HexylogyDB] SET  READ_WRITE 
GO

