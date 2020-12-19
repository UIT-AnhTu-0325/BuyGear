CREATE TABLE Account
(
	ID int NOT NULL,
	username NVARCHAR(100) NOT NULL ,
	password NVARCHAR(100) NOT NULL ,
	type int DEFAULT 0,
	CONSTRAINT PK_Account PRIMARY KEY (ID)
)
--/////
CREATE TABLE Infor
(
	ma_infor int NOT NULL,
	ID int NOT NULL,
	name NVARCHAR(100) DEFAULT N'',
	numberphone VARCHAR(10) DEFAULT N'',
	email NVARCHAR(100) DEFAULT N'',
	address NVARCHAR(100) DEFAULT N'',
	sexual NVARCHAR(10) DEFAULT N'',
	birthday DATE
	CONSTRAINT PK_Infor PRIMARY KEY(ma_infor)
)
ALTER TABLE Infor
ADD CONSTRAINT FK_Infor_Account
FOREIGN KEY (ID) REFERENCES Account(ID)
--/////
CREATE PROC Pro_CheckLogin @username NVARCHAR(100), @password NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE username = @username AND password = @password
END
--/////
CREATE PROC Pro_IsExistUsername @username  NVARCHAR(100)
AS
BEGIN
	SELECT dbo.Account.username FROM dbo.Account WHERE username = @username
END
--/////
CREATE PROC Pro_UpdatePass @password NVARCHAR(100), @username NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Account SET password = @password WHERE username = @username
END
--/////
CREATE TABLE SanPham
(
	ma_sp NVARCHAR(10) NOT NULL,
	tensp NVARCHAR(50) DEFAULT N'',
	loaisp NVARCHAR(20) DEFAULT N'',
	dvt NVARCHAR(20) DEFAULT N'',
	xuatxu NVARCHAR(50) DEFAULT N'',
	nhasx NVARCHAR(40) DEFAULT N'',
	soluong INT,
	gia INT,
	CONSTRAINT PK_SanPham PRIMARY KEY(ma_sp)
)
--/////
CREATE TABLE HinhAnh
(
	ma_image INT NOT NULL,
	name NVARCHAR(50) DEFAULT N'',
	data varbinary(max),
	ma_sp NVARCHAR(10) NOT NULL,
	CONSTRAINT PK_HinhAnh PRIMARY KEY(ma_image)
)
--/////
ALTER TABLE HinhAnh
ADD CONSTRAINT FK_HinhAnh_SanPham
FOREIGN KEY (ma_sp) REFERENCES SanPham (ma_sp) 
--/////
CREATE TABLE Chuot
(
	ma_sp NVARCHAR(10) NOT NULL,
	DPI INT,
	loai NVARCHAR(40) DEFAULT N'',
	CONSTRAINT PK_Chuot PRIMARY KEY(ma_sp),
)
--/////
ALTER TABLE Chuot
ADD CONSTRAINT FK_Chuot_SanPham 
FOREIGN KEY(ma_sp) REFERENCES SanPham(ma_sp)
--/////
CREATE TABLE BanPhim
(
	ma_sp NVARCHAR(10) NOT NULL,
	loai_kichthuoc NVARCHAR(40) DEFAULT N'',
	loai_banphim NVARCHAR(40) DEFAULT N'',
	loai_led NVARCHAR(40) DEFAULT N'',
	CONSTRAINT PK_BanPhim PRIMARY KEY(ma_sp),
)
--/////
ALTER TABLE BanPhim
ADD CONSTRAINT FK_BanPhim_SanPham 
FOREIGN KEY(ma_sp) REFERENCES SanPham(ma_sp)
--/////
CREATE TABLE OCung
(
   ma_sp NVARCHAR (10) NOT NULL,
   loai_ocung NVARCHAR(10) DEFAULT N'',
   dungluong int DEFAULT 0
   CONSTRAINT PK_oCung PRIMARY KEY (ma_sp),
)
--/////
ALTER TABLE OCung
ADD CONSTRAINT FK_OCung_SanPham 
FOREIGN KEY(ma_sp) REFERENCES SanPham(ma_sp)
--////
CREATE TABLE ManHinh
(
	ma_sp NVARCHAR(10) NOT NULL,
	loai_manhinh NVARCHAR(10) DEFAULT N'',
	doPhanGiai VARCHAR(20) DEFAULT '',
	kichThuoc VARCHAR(30) DEFAULT '',
	tocDoLamTuoi INT DEFAULT 0,-- HZ
	CONSTRAINT PK_ManHinh PRIMARY KEY(ma_sp)
)
--/////
ALTER TABLE ManHinh
ADD CONSTRAINT FK_ManHinh_SanPham 
FOREIGN KEY(ma_sp) REFERENCES SanPham(ma_sp)
--/////
CREATE TABLE TanNhiet
(
	ma_sp NVARCHAR(10) NOT NULL,
	tiengOn INT DEFAULT 0 ,-- dB
	dienAp INT DEFAULT 0, -- VDC
	kichThuoc VARCHAR (20) DEFAULT '',
	soQuat INT DEFAULT 0,
	tocDoQuat INT DEFAULT 0,
	CONSTRAINT PK_TanNhiet PRIMARY KEY (ma_sp),
)	
--/////
ALTER TABLE TanNhiet
ADD CONSTRAINT FK_TanNhiet_SanPham 
FOREIGN KEY(ma_sp) REFERENCES SanPham(ma_sp)
--/////
CREATE TABLE USB
(
    ma_sp NVARCHAR(10) NOT NULL,
	loaiUSB VARCHAR(5) DEFAULT '',
	dungLuong INT DEFAULT 0, --GB
	chatLieu VARCHAR(15) DEFAULT '',
	tocDoDoc INT DEFAULT 0, --GB
	CONSTRAINT PK_USB PRIMARY KEY(ma_sp),
)
--/////
ALTER TABLE USB
ADD CONSTRAINT FK_USB_SanPham 
FOREIGN KEY(ma_sp) REFERENCES SanPham(ma_sp)
