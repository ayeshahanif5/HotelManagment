USE [master]
GO
/****** Object:  Database [hotel]    Script Date: 12/10/2018 11:01:44 PM ******/
CREATE DATABASE [hotel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hotel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.ANUMSQL\MSSQL\DATA\hotel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hotel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.ANUMSQL\MSSQL\DATA\hotel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [hotel] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [hotel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hotel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hotel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hotel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hotel] SET  MULTI_USER 
GO
ALTER DATABASE [hotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hotel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hotel] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [hotel] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'hotel', N'ON'
GO
ALTER DATABASE [hotel] SET QUERY_STORE = OFF
GO
USE [hotel]
GO
/****** Object:  Table [dbo].[bookingtable]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bookingtable](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NULL,
	[HallName] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Phone No] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[checkindate] [nvarchar](max) NULL,
	[Time] [time](7) NULL,
	[personno] [int] NULL,
 CONSTRAINT [PK_bookingtable] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[c]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[c](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NULL,
	[image] [image] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_City_1] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[conference]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conference](
	[HallId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NULL,
	[HallName] [nvarchar](50) NULL,
	[facilities] [nvarchar](50) NULL,
	[image] [image] NULL,
	[fooditems] [nvarchar](50) NULL,
	[capacity] [int] NULL,
	[date] [nvarchar](50) NULL,
	[time] [nvarchar](50) NULL,
	[budget] [int] NULL,
	[address] [nvarchar](50) NULL,
 CONSTRAINT [PK_conference] PRIMARY KEY CLUSTERED 
(
	[HallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[conferenceadmin1]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conferenceadmin1](
	[HallId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[HallName] [nvarchar](max) NULL,
	[facilities] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
	[fooditems] [nvarchar](max) NULL,
	[capacity] [int] NULL,
	[date] [date] NULL,
	[time] [time](7) NULL,
	[budget] [int] NULL,
	[address] [nvarchar](max) NULL,
 CONSTRAINT [PK_conferenceadmin1] PRIMARY KEY CLUSTERED 
(
	[HallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[conferencebooking]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conferencebooking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[HallId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Phone No] [nvarchar](max) NULL,
	[Address] [nvarchar](50) NULL,
	[checkindate] [date] NULL,
	[checkoutdate] [date] NULL,
	[HallName] [nvarchar](max) NULL,
	[Noofpeople] [int] NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_conferencebooking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Telephone] [int] NULL,
	[Subject] [nvarchar](50) NULL,
	[Message] [nvarchar](50) NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotel]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotel](
	[HotelId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[hotelname] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[roomtype] [nvarchar](50) NULL,
	[facilities] [nvarchar](50) NULL,
	[image] [image] NULL,
	[budget] [int] NULL,
	[avaliablerooms] [nvarchar](50) NULL,
	[checkindate] [date] NULL,
	[checkoutdate] [date] NULL,
	[CityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_hotel] PRIMARY KEY CLUSTERED 
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoteladmin1]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoteladmin1](
	[HotelId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[hotelname] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[roomtype] [nvarchar](max) NULL,
	[facilities] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
	[budget] [int] NULL,
	[avaliablerooms] [int] NULL,
	[checkindate] [date] NULL,
	[checkoutdate] [date] NULL,
	[CityName] [nvarchar](max) NULL,
 CONSTRAINT [PK_hoteladmin1] PRIMARY KEY CLUSTERED 
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roombooking2]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roombooking2](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[HotellId] [int] NULL,
	[Roomno] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Phoneno] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[checkindate] [date] NULL,
	[checkoutdate] [date] NULL,
	[Hallname] [nvarchar](max) NULL,
 CONSTRAINT [PK_roombooking2] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roombookingsssssss]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roombookingsssssss](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[HotellId] [int] NULL,
	[Roomno] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Phoneno] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[checkindate] [date] NULL,
	[checkoutdate] [date] NULL,
	[Hallname] [nchar](10) NULL,
 CONSTRAINT [PK_roombooking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sign_In]    Script Date: 12/10/2018 11:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sign_In](
	[UserName] [nvarchar](max) NULL,
	[Gender] [bit] NULL,
	[DOB] [date] NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[ConfirmPassword] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sign_In] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tableadmin1]    Script Date: 12/10/2018 11:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tableadmin1](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[HallName] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[personno] [int] NULL,
	[date] [date] NULL,
	[starttime] [time](7) NULL,
	[endtime] [time](7) NULL,
	[budget] [int] NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_tableadmin1] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tablebooking]    Script Date: 12/10/2018 11:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tablebooking](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NULL,
	[HallName] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[personno] [int] NULL,
	[date] [date] NULL,
	[starttime] [time](7) NULL,
	[endtime] [time](7) NULL,
	[budget] [int] NULL,
	[image] [image] NULL,
 CONSTRAINT [PK_tablebooking] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wedding1]    Script Date: 12/10/2018 11:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wedding1](
	[HallId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NULL,
	[HallName] [nvarchar](50) NULL,
	[facilities] [nvarchar](50) NULL,
	[image] [nvarchar](max) NULL,
	[fooditems] [nvarchar](50) NULL,
	[capacity] [int] NULL,
	[date] [date] NULL,
	[time] [time](7) NULL,
	[budget] [int] NULL,
	[address] [nvarchar](50) NULL,
 CONSTRAINT [PK_wedding1] PRIMARY KEY CLUSTERED 
(
	[HallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[weddingbooking]    Script Date: 12/10/2018 11:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[weddingbooking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[HallId] [int] NULL,
	[HallName] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Phone No] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[checkindate] [date] NULL,
	[checkoutdate] [date] NULL,
	[Noofpeople] [int] NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_weddingbooking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[bookingtable]  WITH CHECK ADD  CONSTRAINT [FK_bookingtable_tableadmin1] FOREIGN KEY([TableId])
REFERENCES [dbo].[tableadmin1] ([TableId])
GO
ALTER TABLE [dbo].[bookingtable] CHECK CONSTRAINT [FK_bookingtable_tableadmin1]
GO
ALTER TABLE [dbo].[bookingtable]  WITH CHECK ADD  CONSTRAINT [FK_bookingtable_tablebooking] FOREIGN KEY([TableId])
REFERENCES [dbo].[tablebooking] ([TableId])
GO
ALTER TABLE [dbo].[bookingtable] CHECK CONSTRAINT [FK_bookingtable_tablebooking]
GO
ALTER TABLE [dbo].[conferencebooking]  WITH CHECK ADD  CONSTRAINT [FK_conferencebooking_conference] FOREIGN KEY([HallId])
REFERENCES [dbo].[conference] ([HallId])
GO
ALTER TABLE [dbo].[conferencebooking] CHECK CONSTRAINT [FK_conferencebooking_conference]
GO
ALTER TABLE [dbo].[conferencebooking]  WITH CHECK ADD  CONSTRAINT [FK_conferencebooking_conferenceadmin1] FOREIGN KEY([HallId])
REFERENCES [dbo].[conferenceadmin1] ([HallId])
GO
ALTER TABLE [dbo].[conferencebooking] CHECK CONSTRAINT [FK_conferencebooking_conferenceadmin1]
GO
ALTER TABLE [dbo].[hotel]  WITH CHECK ADD  CONSTRAINT [FK_hotel_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[c] ([CityId])
GO
ALTER TABLE [dbo].[hotel] CHECK CONSTRAINT [FK_hotel_City]
GO
ALTER TABLE [dbo].[roombooking2]  WITH CHECK ADD  CONSTRAINT [FK_roombooking2_hoteladmin1] FOREIGN KEY([HotellId])
REFERENCES [dbo].[hoteladmin1] ([HotelId])
GO
ALTER TABLE [dbo].[roombooking2] CHECK CONSTRAINT [FK_roombooking2_hoteladmin1]
GO
ALTER TABLE [dbo].[roombookingsssssss]  WITH CHECK ADD  CONSTRAINT [FK_roombooking_hotel] FOREIGN KEY([HotellId])
REFERENCES [dbo].[hotel] ([HotelId])
GO
ALTER TABLE [dbo].[roombookingsssssss] CHECK CONSTRAINT [FK_roombooking_hotel]
GO
ALTER TABLE [dbo].[weddingbooking]  WITH CHECK ADD  CONSTRAINT [FK_weddingbooking_wedding1] FOREIGN KEY([HallId])
REFERENCES [dbo].[wedding1] ([HallId])
GO
ALTER TABLE [dbo].[weddingbooking] CHECK CONSTRAINT [FK_weddingbooking_wedding1]
GO
ALTER TABLE [dbo].[weddingbooking]  WITH CHECK ADD  CONSTRAINT [FK_weddingbooking_wedding11] FOREIGN KEY([HallId])
REFERENCES [dbo].[wedding1] ([HallId])
GO
ALTER TABLE [dbo].[weddingbooking] CHECK CONSTRAINT [FK_weddingbooking_wedding11]
GO
USE [master]
GO
ALTER DATABASE [hotel] SET  READ_WRITE 
GO
