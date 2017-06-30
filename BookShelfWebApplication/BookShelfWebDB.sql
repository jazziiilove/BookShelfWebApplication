CREATE DATABASE [BookShelfWeb]
GO
USE [BookShelfWeb]
GO

/****** Object:  ForeignKey [FK_Book_User]    Script Date: 01/02/2012 15:55:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Book_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK_Book_User]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 01/02/2012 15:55:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
DROP TABLE [dbo].[Book]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/02/2012 15:55:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Default [DF__Book__bookstatus__03317E3D]    Script Date: 01/02/2012 15:55:22 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Book__bookstatus__03317E3D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Book__bookstatus__03317E3D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Book] DROP CONSTRAINT [DF__Book__bookstatus__03317E3D]
END


End
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/02/2012 15:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[password] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[city] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([userID], [fullName], [password], [email], [address], [city]) VALUES (1, N'baran     ', N'baran     ', N'topal@kth.se', N'Kolbackgrand', N'Stockholm ')
INSERT [dbo].[User] ([userID], [fullName], [password], [email], [address], [city]) VALUES (2, N'ola       ', N'ola       ', N'ola@backstrom.com', N'Sundyberg', N'Stockholm ')
INSERT [dbo].[User] ([userID], [fullName], [password], [email], [address], [city]) VALUES (3, N'niclas    ', N'niclas    ', N'niclas@wendel.com', N'Sundyberg', N'Stockholm ')
INSERT [dbo].[User] ([userID], [fullName], [password], [email], [address], [city]) VALUES (4, N'sinan     ', N'sinan     ', N'sinan@yenigul.com', N'Bahceli', N'Ankara    ')
INSERT [dbo].[User] ([userID], [fullName], [password], [email], [address], [city]) VALUES (5, N'gunilla   ', N'landin    ', N'gunilla@landin.com', N'Bjorkhagen', N'Stockholm ')
INSERT [dbo].[User] ([userID], [fullName], [password], [email], [address], [city]) VALUES (6, N'ahmet     ', N'tekneci   ', N'ahmet@tekneci.com', N'Cankaya', N'Ankare    ')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Book]    Script Date: 01/02/2012 15:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Book](
	[bookID] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[bookName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[authorName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[userID] [int] NULL,
	[bookStatus] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[bookID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Book] ON
INSERT [dbo].[Book] ([bookID], [isbn], [bookName], [authorName], [userID], [bookStatus]) VALUES (1, N'1ABC      ', N'A Tale of Two Cities', N'Charles Dickens', NULL, 0)
INSERT [dbo].[Book] ([bookID], [isbn], [bookName], [authorName], [userID], [bookStatus]) VALUES (2, N'2BCD      ', N'Anna Karenina', N'Leo Tolstoy', 1, 1)
INSERT [dbo].[Book] ([bookID], [isbn], [bookName], [authorName], [userID], [bookStatus]) VALUES (3, N'3CDE      ', N'Les Miserables', N'Victor Hugo', 2, 2)
INSERT [dbo].[Book] ([bookID], [isbn], [bookName], [authorName], [userID], [bookStatus]) VALUES (4, N'4DEF      ', N'The Power of Subconscious Mind', N'Joseph Murphy', NULL, 0)
INSERT [dbo].[Book] ([bookID], [isbn], [bookName], [authorName], [userID], [bookStatus]) VALUES (5, N'5EFGHIJ   ', N'The Hitchhiker''s Guide to the Galaxy', N'Douglas Adams', 1, 2)
SET IDENTITY_INSERT [dbo].[Book] OFF
/****** Object:  Default [DF__Book__bookstatus__03317E3D]    Script Date: 01/02/2012 15:55:22 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Book__bookstatus__03317E3D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Book__bookstatus__03317E3D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF__Book__bookstatus__03317E3D]  DEFAULT ((0)) FOR [bookStatus]
END


End
GO
/****** Object:  ForeignKey [FK_Book_User]    Script Date: 01/02/2012 15:55:22 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Book_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Book_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_User]
GO
