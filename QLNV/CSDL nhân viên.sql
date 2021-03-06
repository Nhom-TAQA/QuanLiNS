USE [QL_NV]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 11/8/2020 7:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[MA_ADMIN] [nchar](100) NOT NULL,
	[USERNAME] [nchar](100) NOT NULL,
	[PASSWORD] [nchar](100) NOT NULL,
	[CAPDO] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 11/8/2020 7:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [int] IDENTITY(1,1) NOT NULL,
	[HOVN] [nvarchar](50) NULL,
	[NGAYSINH] [date] NULL,
	[GT] [bit] NULL,
	[LUONG] [int] NULL,
	[MAPHONG] [int] NULL,
	[SDT] [nchar](12) NULL,
	[EMAIL] [nchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ADMIN] ([MA_ADMIN], [USERNAME], [PASSWORD], [CAPDO]) VALUES (N'1                                                                                                   ', N'a1                                                                                                  ', N'1                                                                                                   ', 3)
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (1, N'trần sang anh', CAST(N'1999-12-11' AS Date), 1, 1000000, 1, NULL, NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (2, N'Lê văn phiêu', CAST(N'1999-02-11' AS Date), 1, 2000000, 1, NULL, NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (3, N'Nguyễn thành nam', CAST(N'1999-03-11' AS Date), 1, 2000000, 1, N'0329620362  ', N'                                                                                                    ')
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (4, N'Lê trọng quyết', CAST(N'1998-02-11' AS Date), 1, 1000000, 1, N'0372515472  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (5, N'Trần thị quỳnh anh', CAST(N'1997-02-01' AS Date), 0, 4000000, 2, N'0375618374  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (6, N'Ngyễn Quốc Nhân', CAST(N'1999-01-03' AS Date), 1, 3000000, 2, N'0127361853  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (7, N'Đỗ thanh bình', CAST(N'1997-02-01' AS Date), 1, 1000000, 3, N'0351438527  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (8, N'Nguyễn thị thanh ', CAST(N'2000-02-03' AS Date), 0, 1500000, 3, N'0257157375  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (9, N'Cao quang san', CAST(N'2000-01-02' AS Date), 0, 1000000, 2, N'0271768562  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (10, N'Trần đình cao', CAST(N'2000-01-01' AS Date), 1, 1000000, 2, N'0357983896  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (11, N'Lê Đình Đức', CAST(N'1999-03-01' AS Date), 1, 2000000, 1, N'0357166377  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (12, N'Nguyễn đình hà', CAST(N'1997-04-05' AS Date), 1, 3000000, 2, N'0725817687  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (13, N'Hoàng đạt mập', CAST(N'2002-05-05' AS Date), 1, 1000000, 1, N'0467812667  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (14, N'Ngô sĩ huy', CAST(N'1996-02-01' AS Date), 1, 4000000, 1, N'0236812686  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (15, N'Hoàng thảo nguyên', CAST(N'1999-02-01' AS Date), 0, 3200000, 2, N'0182684626  ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (16, N'Trần hoài anh', CAST(N'1997-02-04' AS Date), 0, 1000000, 2, N'01273977628 ', NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [HOVN], [NGAYSINH], [GT], [LUONG], [MAPHONG], [SDT], [EMAIL]) VALUES (17, N'Bùi lê văn phiêu', CAST(N'1999-11-11' AS Date), 0, 2000000, 3, N'01823685826 ', NULL)
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
GO
