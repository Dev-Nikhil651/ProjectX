USE [jobs]
GO
/****** Object:  Table [dbo].[Fee]    Script Date: 7/1/2025 10:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnqueId] [uniqueidentifier] NULL,
	[General_OBC_EWS] [varchar](255) NULL,
	[SC_ST_PwD_Ex_Serviceman] [varchar](255) NULL,
	[For_Girls] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPosts]    Script Date: 7/1/2025 10:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Department] [nvarchar](100) NOT NULL,
	[LastDate] [date] NOT NULL,
	[AdvertisementDate] [date] NOT NULL,
	[Location] [nvarchar](max) NULL,
	[OfficialNotification] [nvarchar](max) NULL,
	[NO_Post] [nvarchar](max) NULL,
	[UniqueId] [uniqueidentifier] NULL,
	[mode] [varchar](max) NULL,
	[StateName] [nvarchar](max) NULL,
	[min_Age] [nvarchar](max) NULL,
	[max_Age] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostItem]    Script Date: 7/1/2025 10:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnqueId] [uniqueidentifier] NULL,
	[PostName] [varchar](max) NULL,
	[NoOfPosts] [nvarchar](50) NULL,
	[Qualification] [varchar](max) NULL,
	[Salary] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_jobLinks]    Script Date: 7/1/2025 10:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_jobLinks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnqueId] [uniqueidentifier] NULL,
	[link] [nvarchar](max) NULL,
	[linknamce] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Fee] ON 

INSERT [dbo].[Fee] ([id], [UnqueId], [General_OBC_EWS], [SC_ST_PwD_Ex_Serviceman], [For_Girls]) VALUES (8, N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'100', N'nill', NULL)
INSERT [dbo].[Fee] ([id], [UnqueId], [General_OBC_EWS], [SC_ST_PwD_Ex_Serviceman], [For_Girls]) VALUES (14, N'493b6464-8123-4aac-a673-6d249f413695', N'30', N'30', N'30')
SET IDENTITY_INSERT [dbo].[Fee] OFF
GO
SET IDENTITY_INSERT [dbo].[JobPosts] ON 

INSERT [dbo].[JobPosts] ([Id], [Department], [LastDate], [AdvertisementDate], [Location], [OfficialNotification], [NO_Post], [UniqueId], [mode], [StateName], [min_Age], [max_Age]) VALUES (60, N'Indian Coast Guard', CAST(N'2025-06-05' AS Date), CAST(N'2025-07-04' AS Date), N'State', NULL, N'260', N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'online', NULL, N'3', N'3')
INSERT [dbo].[JobPosts] ([Id], [Department], [LastDate], [AdvertisementDate], [Location], [OfficialNotification], [NO_Post], [UniqueId], [mode], [StateName], [min_Age], [max_Age]) VALUES (67, N'atulxx', CAST(N'2025-07-05' AS Date), CAST(N'2025-07-06' AS Date), N'State', NULL, N'340', N'493b6464-8123-4aac-a673-6d249f413695', N'ofline', N'Himachal Pradesh', N'230', N'240')
SET IDENTITY_INSERT [dbo].[JobPosts] OFF
GO
SET IDENTITY_INSERT [dbo].[PostItem] ON 

INSERT [dbo].[PostItem] ([Id], [UnqueId], [PostName], [NoOfPosts], [Qualification], [Salary]) VALUES (17, N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'Navik (General Duty)', N'260', N'Class 12th passed with Maths and Physics from an education board recognized by Council of Boards for School Education (COBSE).', N'Basic pay of ? 21700/- (Pay Level-3) plus Dearness Allowance and other allowances based on nature of duty/ place of posting as per the prevailing regulations.')
INSERT [dbo].[PostItem] ([Id], [UnqueId], [PostName], [NoOfPosts], [Qualification], [Salary]) VALUES (18, N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'Navik (Domestic Branch)', N'50', N'Class 10th passed from an education board recognized by Council of Boards for School Education (COBSE).', N'Basic Pay Scale for Navik (DB) is ? 21700/- (Pay Level-3) plus Dearness Allowance and other allowances based on nature of duty/ place of posting as per the prevailing regulation')
INSERT [dbo].[PostItem] ([Id], [UnqueId], [PostName], [NoOfPosts], [Qualification], [Salary]) VALUES (19, N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'Havildar X - Ray Assistant', N'60', N'Class 10th passed from an education board recognized by Council of Boards for School Education (COBSE) and Diploma in Electrical/ Mechanical / Electronics/ Telecommunication (Radio/Power) Engineering of duration 03 or 04 years approved by All India Council of Technical Education (AICTE). Class 10th & Class 12th passed from an education board recognized by Council of Boards for School Education (COBSE) “AND” Diploma in Electrical/ Mechanical / Electronics/ Telecommunication (Radio/Power) Engineering of duration 02 or 03 years approved by All India Council of Technical Education (AICTE).', N'Basic pay ? 29200/- (Pay Level-5). In addition, you will be paid Yantrik pay @ ? 6200/- plus Dearness Allowance and other allowances based on nature of duty/place of posting as per the prevailing regulation.')
SET IDENTITY_INSERT [dbo].[PostItem] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_jobLinks] ON 

INSERT [dbo].[tb_jobLinks] ([id], [UnqueId], [link], [linknamce]) VALUES (14, N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'WWWWWWWWWWWW', N'Official Notification')
INSERT [dbo].[tb_jobLinks] ([id], [UnqueId], [link], [linknamce]) VALUES (15, N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'WWWWWWWWWWWWW', N'Official Website')
INSERT [dbo].[tb_jobLinks] ([id], [UnqueId], [link], [linknamce]) VALUES (16, N'cd52caed-dd9f-487c-8775-c8d9033191f9', N'DDDDDDDDD', N'APPLY ONLINE')
INSERT [dbo].[tb_jobLinks] ([id], [UnqueId], [link], [linknamce]) VALUES (20, N'493b6464-8123-4aac-a673-6d249f413695', N'dddxx', N'Official Notification')
INSERT [dbo].[tb_jobLinks] ([id], [UnqueId], [link], [linknamce]) VALUES (21, N'493b6464-8123-4aac-a673-6d249f413695', N'dddxx', N'Official Website')
INSERT [dbo].[tb_jobLinks] ([id], [UnqueId], [link], [linknamce]) VALUES (22, N'493b6464-8123-4aac-a673-6d249f413695', N'dddxx', N'How to Apply')
SET IDENTITY_INSERT [dbo].[tb_jobLinks] OFF
GO
