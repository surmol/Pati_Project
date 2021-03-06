USE [master]
GO
/****** Object:  Database [Pati_project]    Script Date: 12/02/2017 23:41:50 ******/
CREATE DATABASE [Pati_project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pati_project', FILENAME = N'C:\Users\Adrian Surma\Pati_project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pati_project_log', FILENAME = N'C:\Users\Adrian Surma\Pati_project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Pati_project] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pati_project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pati_project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pati_project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pati_project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pati_project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pati_project] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pati_project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pati_project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pati_project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pati_project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pati_project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pati_project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pati_project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pati_project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pati_project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pati_project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pati_project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pati_project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pati_project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pati_project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pati_project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pati_project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pati_project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pati_project] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pati_project] SET  MULTI_USER 
GO
ALTER DATABASE [Pati_project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pati_project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pati_project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pati_project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pati_project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pati_project] SET QUERY_STORE = OFF
GO
USE [Pati_project]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Pati_project]
GO
/****** Object:  Table [dbo].[companies]    Script Date: 12/02/2017 23:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [text] NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[employees]    Script Date: 12/02/2017 23:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [text] NULL,
	[surname] [text] NULL,
	[age] [int] NULL,
	[street] [text] NULL,
	[house_name_number] [text] NULL,
	[region] [text] NULL,
	[post_code] [text] NULL,
	[hours_per_week] [float] NULL,
 CONSTRAINT [PK_employees2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[projects]    Script Date: 12/02/2017 23:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[projects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [text] NULL,
	[company_id] [int] NULL,
 CONSTRAINT [PK_projects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[staff_project_allocation]    Script Date: 12/02/2017 23:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff_project_allocation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employee_id] [int] NULL,
	[project1_id] [int] NULL,
	[project2_id] [int] NULL,
	[project1_percentage] [int] NULL,
	[year] [int] NULL,
	[month] [int] NULL,
 CONSTRAINT [PK_staff_project_allocation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[staff_time_allocation]    Script Date: 12/02/2017 23:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff_time_allocation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[allocation_id] [int] NULL,
	[gross_salary] [decimal](18, 2) NULL,
	[insurance] [decimal](18, 2) NULL,
	[pension] [decimal](18, 2) NULL,
 CONSTRAINT [PK_staff_time_allocation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD  CONSTRAINT [FK_projects_companies] FOREIGN KEY([company_id])
REFERENCES [dbo].[companies] ([id])
GO
ALTER TABLE [dbo].[projects] CHECK CONSTRAINT [FK_projects_companies]
GO
ALTER TABLE [dbo].[staff_project_allocation]  WITH CHECK ADD  CONSTRAINT [FK_staff_project_allocation_staff_project_allocation] FOREIGN KEY([id])
REFERENCES [dbo].[staff_project_allocation] ([id])
GO
ALTER TABLE [dbo].[staff_project_allocation] CHECK CONSTRAINT [FK_staff_project_allocation_staff_project_allocation]
GO
ALTER TABLE [dbo].[staff_time_allocation]  WITH CHECK ADD  CONSTRAINT [FK_staff_time_allocation_staff_project_allocation] FOREIGN KEY([allocation_id])
REFERENCES [dbo].[staff_project_allocation] ([id])
GO
ALTER TABLE [dbo].[staff_time_allocation] CHECK CONSTRAINT [FK_staff_time_allocation_staff_project_allocation]
GO
USE [master]
GO
ALTER DATABASE [Pati_project] SET  READ_WRITE 
GO
