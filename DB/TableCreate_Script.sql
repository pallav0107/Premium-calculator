CREATE DATABASE [TAL]
GO
USE [TAL]
GO
/****** Object:  Table [dbo].[Occupation]    Script Date: 28/08/2020 12:08:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupation](
	[OccupationId] [int] IDENTITY(1,1) NOT NULL,
	[Occupation] [varchar](50) NOT NULL,
	[RatingId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Occupation] PRIMARY KEY CLUSTERED 
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OccupationRating]    Script Date: 28/08/2020 12:08:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccupationRating](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [varchar](50) NOT NULL,
	[Factor] [decimal](18, 2) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_OccupationRating] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Occupation] ON 
GO
INSERT [dbo].[Occupation] ([OccupationId], [Occupation], [RatingId], [CreatedOn]) VALUES (1, N'Cleaner', 3, CAST(N'2020-08-27T03:17:51.827' AS DateTime))
GO
INSERT [dbo].[Occupation] ([OccupationId], [Occupation], [RatingId], [CreatedOn]) VALUES (2, N'Doctor', 1, CAST(N'2020-08-27T03:18:11.163' AS DateTime))
GO
INSERT [dbo].[Occupation] ([OccupationId], [Occupation], [RatingId], [CreatedOn]) VALUES (3, N'Author', 2, CAST(N'2020-08-27T03:18:19.167' AS DateTime))
GO
INSERT [dbo].[Occupation] ([OccupationId], [Occupation], [RatingId], [CreatedOn]) VALUES (4, N'Farmer', 4, CAST(N'2020-08-27T03:18:28.670' AS DateTime))
GO
INSERT [dbo].[Occupation] ([OccupationId], [Occupation], [RatingId], [CreatedOn]) VALUES (5, N'Mechanic', 4, CAST(N'2020-08-27T03:18:34.353' AS DateTime))
GO
INSERT [dbo].[Occupation] ([OccupationId], [Occupation], [RatingId], [CreatedOn]) VALUES (6, N'Florist', 3, CAST(N'2020-08-27T03:18:44.070' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Occupation] OFF
GO
SET IDENTITY_INSERT [dbo].[OccupationRating] ON 
GO
INSERT [dbo].[OccupationRating] ([RatingId], [Rating], [Factor], [CreatedOn]) VALUES (1, N'Professional', CAST(1.00 AS Decimal(18, 2)), CAST(N'2020-08-27T03:16:03.963' AS DateTime))
GO
INSERT [dbo].[OccupationRating] ([RatingId], [Rating], [Factor], [CreatedOn]) VALUES (2, N'White Collar', CAST(1.25 AS Decimal(18, 2)), CAST(N'2020-08-27T03:16:14.367' AS DateTime))
GO
INSERT [dbo].[OccupationRating] ([RatingId], [Rating], [Factor], [CreatedOn]) VALUES (3, N'Light Manual', CAST(1.50 AS Decimal(18, 2)), CAST(N'2020-08-27T03:16:20.267' AS DateTime))
GO
INSERT [dbo].[OccupationRating] ([RatingId], [Rating], [Factor], [CreatedOn]) VALUES (4, N'Heavy Manual', CAST(1.75 AS Decimal(18, 2)), CAST(N'2020-08-27T03:16:32.307' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[OccupationRating] OFF
GO
ALTER TABLE [dbo].[Occupation] ADD  CONSTRAINT [DF_Occupation_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[OccupationRating] ADD  CONSTRAINT [DF_OccupationRating_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Occupation]  WITH CHECK ADD  CONSTRAINT [FK_Occupation_OccupationRating] FOREIGN KEY([RatingId])
REFERENCES [dbo].[OccupationRating] ([RatingId])
GO
ALTER TABLE [dbo].[Occupation] CHECK CONSTRAINT [FK_Occupation_OccupationRating]
GO
