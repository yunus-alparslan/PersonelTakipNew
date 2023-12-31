USE [Table_PersonelNew]
GO
/****** Object:  Table [dbo].[Table_Admin]    Script Date: 19.06.2023 14:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Admin](
	[Adminİd] [tinyint] IDENTITY(1,1) NOT NULL,
	[Adminİsim] [varchar](20) NULL,
	[AdminSoyad] [varchar](20) NULL,
	[AdminKullanıcıAdı] [varchar](20) NULL,
	[AdminSifre] [varchar](20) NULL,
	[AdminEposta] [varchar](50) NULL,
	[AdminTel] [nchar](11) NULL,
 CONSTRAINT [PK_Table_Admin] PRIMARY KEY CLUSTERED 
(
	[Adminİd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Personel]    Script Date: 19.06.2023 14:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Personel](
	[Personelİd] [tinyint] IDENTITY(1,1) NOT NULL,
	[Personelİsmi] [varchar](20) NULL,
	[PersonelSoyad] [varchar](20) NULL,
	[PersonelSehir] [varchar](20) NULL,
	[PersonelCinsiyet] [varchar](5) NULL,
	[PersonelBaslamaTarih] [smalldatetime] NULL,
	[PersonelMaas] [smallint] NULL,
	[PersonelTelefon] [varchar](15) NULL,
	[PersonelDurum] [varchar](10) NULL,
 CONSTRAINT [PK_Table_Personel] PRIMARY KEY CLUSTERED 
(
	[Personelİd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Table_Admin] ON 

INSERT [dbo].[Table_Admin] ([Adminİd], [Adminİsim], [AdminSoyad], [AdminKullanıcıAdı], [AdminSifre], [AdminEposta], [AdminTel]) VALUES (1, N'ALP', N'M', N'a', N'1', N'ada@gmail.com', N'05342185555')
SET IDENTITY_INSERT [dbo].[Table_Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_Personel] ON 

INSERT [dbo].[Table_Personel] ([Personelİd], [Personelİsmi], [PersonelSoyad], [PersonelSehir], [PersonelCinsiyet], [PersonelBaslamaTarih], [PersonelMaas], [PersonelTelefon], [PersonelDurum]) VALUES (1, N'ALP', N'MERT', N'İstanbul', N'Erkek', CAST(N'2023-06-06T00:00:00' AS SmallDateTime), 555, N'(555) 555-5555', N'Çalısıyor')
INSERT [dbo].[Table_Personel] ([Personelİd], [Personelİsmi], [PersonelSoyad], [PersonelSehir], [PersonelCinsiyet], [PersonelBaslamaTarih], [PersonelMaas], [PersonelTelefon], [PersonelDurum]) VALUES (2, N'F', N'F', N'Ankara', N'Kadın', CAST(N'2023-06-19T00:00:00' AS SmallDateTime), 33, N'(333) 333-3333', N'Çalısmıyor')
SET IDENTITY_INSERT [dbo].[Table_Personel] OFF
GO
ALTER TABLE [dbo].[Table_Personel] ADD  CONSTRAINT [DF_Table_Personel_PersonelMaas]  DEFAULT ((0)) FOR [PersonelMaas]
GO
