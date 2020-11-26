CREATE DATABASE BuyGear
-------------------------------
USE BuyGear
-------------------------------
---//Written By Ngo Tan Hoai//---
CREATE TABLE Account
(
	username NVARCHAR(100) NOT NULL PRIMARY KEY,
	password NVARCHAR(100) NOT NULL ,
	type BIT DEFAULT 0
)
--TABLE INFOR--
CREATE TABLE Infor
(
	username NVARCHAR(100) NOT NULL,
	name NVARCHAR(100) DEFAULT N'',
	numberphone VARCHAR(10) DEFAULT N'',
	email NVARCHAR(100) DEFAULT N'',
	address NVARCHAR(100) DEFAULT N'',
	sexual NVARCHAR(10) DEFAULT N'',
	birthday DATE

	FOREIGN KEY(username) REFERENCES dbo.Account (username)
)
--CHECK LOGIN--
CREATE PROC Pro_CheckLogin @username NVARCHAR(100), @password NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE username = @username AND password = @password
END
--CHECK EXIST USERNAME--
CREATE PROC Pro_IsExistUsername @username  NVARCHAR(100)
AS
BEGIN
	SELECT dbo.Account.username FROM dbo.Account WHERE username = @username
END
--CHANGE PASSWORD--
CREATE PROC Pro_UpdatePass @password NVARCHAR(100), @username NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Account SET password = @password WHERE username = @username
END
-------------------------------
--//Written By Dang Anh Tu//---
--TABLE HINHANH--
CREATE TABLE HinhAnh
(
	id INT,
	name NVARCHAR(50) DEFAULT N'',
	url TEXT,
	relation_masp NVARCHAR(10) DEFAULT N'',
	typesp VARCHAR(20) DEFAULT N'',
	CONSTRAINT PK_HinhAnh PRIMARY KEY(id)
)
--TABLE SANPHAM--
CREATE TABLE SanPham
(
	masp NVARCHAR(10) NOT NULL,
	tensp NVARCHAR(50) DEFAULT N'',
	loaisp NVARCHAR(20) DEFAULT N'',
	dvt NVARCHAR(20) DEFAULT N'',
	xuatxu NVARCHAR(50) DEFAULT N'',
	nhasx NVARCHAR(40) DEFAULT N'',
	soluong INT,
	gia INT,
	--mota1 NVARCHAR(200) DEFAULT N'',
	--mota2 NVARCHAR (200) DEFAULT N'',
	--mota3 NVARCHAR (200) DEFAULT N'',
	CONSTRAINT PK_SanPham PRIMARY KEY(masp)
)
--TABLE CHUOT--
CREATE TABLE Chuot
(
	masp NVARCHAR(10) NOT NULL,
	DPI INT,
	loai NVARCHAR(40) DEFAULT N'',
	CONSTRAINT PK_Chuot PRIMARY KEY(masp),
	CONSTRAINT FK_Chuot_SanPham FOREIGN KEY(masp) REFERENCES SanPham(masp)
)
--TABLE BANPHIM--
CREATE TABLE BanPhim
(
	masp NVARCHAR(10) NOT NULL,
	loai_kichthuoc NVARCHAR(40) DEFAULT N'',
	loai_banphim NVARCHAR(40) DEFAULT N'',
	loai_led NVARCHAR(40) DEFAULT N'',
	CONSTRAINT PK_BanPhim PRIMARY KEY(masp),
	CONSTRAINT FK_BanPhim_SanPham FOREIGN KEY(masp) REFERENCES SanPham(masp)
)

---//Written By Lam Van Hong//---
-- TABLE OCUNG
CREATE TABLE oCung
(
   masp NVARCHAR (10) NOT NULL,
   loai_ocung NVARCHAR(10) DEFAULT N'',
   dungluong int DEFAULT 0
   CONSTRAINT PK_oCung PRIMARY KEY (masp),
   CONSTRAINT FK_oCung_SanPham FOREIGN KEY (masp) REFERENCES SanPham(masp)
)
-- TABLE MAN HINH
CREATE TABLE ManHinh
(
	masp NVARCHAR(10) NOT NULL,
	loai_manhinh NVARCHAR(10) DEFAULT N'',
	doPhanGiai VARCHAR(20) DEFAULT '',
	kichThuoc VARCHAR(30) DEFAULT '',
	tocDoLamTuoi INT DEFAULT 0,-- HZ
	CONSTRAINT PK_ManHinh PRIMARY KEY(masp),
	CONSTRAINT FK_ManHinh_SanPham FOREIGN KEY (masp) REFERENCES SanPham(masp)
)
-- TABLE TAN NHIET
CREATE TABLE TanNhiet
(
	masp NVARCHAR(10) NOT NULL,
	tiengOn INT DEFAULT 0 ,-- dB
	dienAp INT DEFAULT 0, -- VDC
	kichThuoc VARCHAR (20) DEFAULT '',
	soQuat INT DEFAULT 0,
	tocDoQuat INT DEFAULT 0,
	CONSTRAINT PK_TanNhiet PRIMARY KEY (masp),
	CONSTRAINT FK_TanNhiet_SanPham FOREIGN KEY (masp) REFERENCES SanPham(masp)
)	
-- TABLE USB
CREATE TABLE USB
(
    masp NVARCHAR(10) NOT NULL,
	loaiUSB VARCHAR(5) DEFAULT '',
	dungLuong INT DEFAULT 0, --GB
	chatLieu VARCHAR(15) DEFAULT '',
	tocDoDoc INT DEFAULT 0, --GB
	CONSTRAINT PK_USB PRIMARY KEY(masp),
	CONSTRAINT FK_USB_SanPham FOREIGN KEY (masp) REFERENCES SanPham(masp)
)





--CHAY DATA DEN DAY---------------------------------------------------------------------------

-- import man hinh
INSERT INTO SanPham VALUES ('M15',N'Màn hình 25inch','ManHinh','CAI','CHINA','LOGITECT',5,20000)
INSERT INTO ManHinh VALUES ('M15','oled','4K','50inch', 120)
INSERT INTO HinhAnh VALUES (1215,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh1a.jpg','M15','ManHinh')
INSERT INTO HinhAnh VALUES (1315,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh1b.jpg','M15','ManHinh')
INSERT INTO HinhAnh VALUES (1415,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh1c.jpg','M15','ManHinh')
INSERT INTO HinhAnh VALUES (1515,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh1d.jpg','M15','ManHinh')

INSERT INTO SanPham VALUES ('M16','Màn hình Asus Gaming','ManHinh','CAI','Thai Lan','Asus',5,3400000)
INSERT INTO ManHinh VALUES ('M16','oled','4K','50inch', 120)
INSERT INTO HinhAnh VALUES (1216,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh2a.jpg','M16','ManHinh')
INSERT INTO HinhAnh VALUES (1316,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh2b.jpg','M16','ManHinh')
INSERT INTO HinhAnh VALUES (1416,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh2c.jpg','M16','ManHinh')
INSERT INTO HinhAnh VALUES (1516,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh2d.jpg','M16','ManHinh')

INSERT INTO SanPham VALUES ('M17','Màn hình LCD LG','ManHinh','CAI','Thai Lan','LG',5,2400000)
INSERT INTO ManHinh VALUES ('M17','oled','4K','50inch', 120)
INSERT INTO HinhAnh VALUES (1217,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh3a.jpg','M17','ManHinh')
INSERT INTO HinhAnh VALUES (1317,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh3b.jpg','M17','ManHinh')
INSERT INTO HinhAnh VALUES (1417,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh3c.jpg','M17','ManHinh')
INSERT INTO HinhAnh VALUES (1517,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh3d.jpg','M17','ManHinh')

INSERT INTO SanPham VALUES ('M18','Màn hình SamSung4K','ManHinh','CAI','Thai Lan','Sam Sung',5,5700000)
INSERT INTO ManHinh VALUES ('M18','oled','4K','50inch', 120)
INSERT INTO HinhAnh VALUES (1218,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh4a.jpg','M18','ManHinh')
INSERT INTO HinhAnh VALUES (1318,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh4b.jpg','M18','ManHinh')
INSERT INTO HinhAnh VALUES (1418,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh4c.jpg','M18','ManHinh')
INSERT INTO HinhAnh VALUES (1518,'DEMOMANHINH','../../../../Data_Image/ManHinh/manhinh4d.jpg','M18','ManHinh')
--Import Chuot

INSERT INTO SanPham VALUES ('M80', N'Chuột RGB Gaming ', 'Chuot', 'CAI', 'Japan', 'Consair', 5, 1400000)
INSERT INTO Chuot VALUES ('M80','300','BLUETOOTH')
INSERT INTO HinhAnh VALUES (1280,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot1a.jpg','M80','Chuot')
INSERT INTO HinhAnh VALUES (1380,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot1b.jpg','M80','Chuot')
INSERT INTO HinhAnh VALUES (1480,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot1c.jpg','M80','Chuot')
INSERT INTO HinhAnh VALUES (1580,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot1d.jpg','M80','Chuot')


INSERT INTO SanPham VALUES ('M81', N'Chuột Bluetooth Logitech ', 'Chuot', 'CAI', 'Han Quoc', 'Logitech', 5, 125000)
INSERT INTO Chuot VALUES ('M81','300','BLUETOOTH')
INSERT INTO HinhAnh VALUES (1281,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot2a.jpg','M81','Chuot')
INSERT INTO HinhAnh VALUES (1381,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot2b.jpg','M81','Chuot')
INSERT INTO HinhAnh VALUES (1481,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot2c.jpg','M81','Chuot')
INSERT INTO HinhAnh VALUES (1581,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot2d.jpg','M81','Chuot')

INSERT INTO SanPham VALUES ('M82', N'Chuột Gaming Logitech ', 'Chuot', 'CAI', 'Japan', 'Logitech', 5, 990000)
INSERT INTO Chuot VALUES ('M82','300','BLUETOOTH')
INSERT INTO HinhAnh VALUES (1282,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot3a.jpg','M82','Chuot')
INSERT INTO HinhAnh VALUES (1382,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot3b.jpg','M82','Chuot')
INSERT INTO HinhAnh VALUES (1482,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot3c.jpg','M82','Chuot')
INSERT INTO HinhAnh VALUES (1582,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot3d.jpg','M82','Chuot')

INSERT INTO SanPham VALUES ('M83', N'Chuột có dây T-WOLF', 'Chuot', 'CAI', 'Japan', 'wolf', 5, 250000)
INSERT INTO Chuot VALUES ('M83','300','BLUETOOTH')
INSERT INTO HinhAnh VALUES (1283,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot4a.jpg','M83','Chuot')
INSERT INTO HinhAnh VALUES (1383,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot4b.jpg','M83','Chuot')
INSERT INTO HinhAnh VALUES (1483,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot4c.jpg','M83','Chuot')
INSERT INTO HinhAnh VALUES (1583,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot4d.jpg','M83','Chuot')

INSERT INTO SanPham VALUES ('M84', N'Chuột Gaming Fuhlen G90s', 'Chuot', 'CAI', 'Japan', 'Fuhlen', 5, 2320000)
INSERT INTO Chuot VALUES ('M84','300','BLUETOOTH')
INSERT INTO HinhAnh VALUES (1284,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot5a.jpg','M84','Chuot')
INSERT INTO HinhAnh VALUES (1384,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot5b.jpg','M84','Chuot')
INSERT INTO HinhAnh VALUES (1484,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot5c.jpg','M84','Chuot')
INSERT INTO HinhAnh VALUES (1584,'DEMOMOUSE','../../../../Data_Image/Chuot/chuot5d.jpg','M84','Chuot')
-- Import Ban Phim
INSERT INTO SanPham VALUES ('M20', 'Bàn phím Akko WT', 'BanPhim', 'CAI', 'Japan', 'Akko', 5, 1400000)
INSERT INTO BanPhim VALUES ('M20', 'TO', 'MAGIC', 'RGB')
INSERT INTO HinhAnh VALUES (1220,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim1a.jpg','M20','BanPhim')
INSERT INTO HinhAnh VALUES (1320,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim1b.jpg','M20','BanPhim')
INSERT INTO HinhAnh VALUES (1420,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim1c.jpg','M20','BanPhim')
INSERT INTO HinhAnh VALUES (1520,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim1d.jpg','M20','BanPhim')

INSERT INTO SanPham VALUES ('M21', 'Bàn phím MagicKeyboard', 'BanPhim', 'CAI', 'Singapor', 'Apple', 5, 2560000)
INSERT INTO BanPhim VALUES ('M21', 'TO', 'MAGIC', 'RGB')
INSERT INTO HinhAnh VALUES (1221,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim2a.jpg','M21','BanPhim')
INSERT INTO HinhAnh VALUES (1321,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim2b.jpg','M21','BanPhim')
INSERT INTO HinhAnh VALUES (1421,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim2c.jpg','M21','BanPhim')
INSERT INTO HinhAnh VALUES (1521,'DEMOKEYBOARD','../../../../Data_Image/banPhim/banphim2d.jpg','M21','BanPhim')

--Inport Hinh Quat

INSERT INTO SanPham VALUES ('M30',N'Tản nhiệt 5W','TanNhiet','CAI','Canada','asus',5,50000)
INSERT INTO TanNhiet VALUES ('M30',10,20,'20x20',10, 120)
INSERT INTO HinhAnh VALUES (1230,'DEMOFAN','../../../../Data_Image/quat/quat1a.jpg','M30','TanNhiet')
INSERT INTO HinhAnh VALUES (1330,'DEMOFAN','../../../../Data_Image/quat/quat1b.jpg','M30','TanNhiet')
INSERT INTO HinhAnh VALUES (1430,'DEMOFAN','../../../../Data_Image/quat/quat1c.jpg','M30','TanNhiet')
INSERT INTO HinhAnh VALUES (1530,'DEMOFAN','../../../../Data_Image/quat/quat1d.jpg','M30','TanNhiet')



INSERT INTO SanPham VALUES ('M31',N'Tản nhiệt RGB','TanNhiet','CAI','Canada','asus',5,50000)
INSERT INTO TanNhiet VALUES ('M31',10,20,'20x20',10, 120)
INSERT INTO HinhAnh VALUES (1231,'DEMOFAN','../../../../Data_Image/quat/quat2a.jpg','M31','TanNhiet')
INSERT INTO HinhAnh VALUES (1331,'DEMOFAN','../../../../Data_Image/quat/quat2b.jpg','M31','TanNhiet')
INSERT INTO HinhAnh VALUES (1431,'DEMOFAN','../../../../Data_Image/quat/quat2c.jpg','M31','TanNhiet')
INSERT INTO HinhAnh VALUES (1531,'DEMOFAN','../../../../Data_Image/quat/quat2d.jpg','M31','TanNhiet')

INSERT INTO SanPham VALUES ('M32',N'Tản nhiệt T400i','TanNhiet','CAI','trung quoc','TD',5,130000)
INSERT INTO TanNhiet VALUES ('M32',10,20,'20x20',10, 120)
INSERT INTO HinhAnh VALUES (1232,'DEMOFAN','../../../../Data_Image/quat/quat3a.jpg','M32','TanNhiet')
INSERT INTO HinhAnh VALUES (1332,'DEMOFAN','../../../../Data_Image/quat/quat3b.jpg','M32','TanNhiet')
INSERT INTO HinhAnh VALUES (1432,'DEMOFAN','../../../../Data_Image/quat/quat3c.jpg','M32','TanNhiet')
INSERT INTO HinhAnh VALUES (1532,'DEMOFAN','../../../../Data_Image/quat/quat3d.jpg','M32','TanNhiet')

INSERT INTO SanPham VALUES ('M33',N'Tản nhiệt Mini5W','TanNhiet','CAI','HanQuoc','Koata',5,30000)
INSERT INTO TanNhiet VALUES ('M33',10,20,'20x20',10, 120)
INSERT INTO HinhAnh VALUES (1233,'DEMOFAN','../../../../Data_Image/quat/quat4a.jpg','M33','TanNhiet')
INSERT INTO HinhAnh VALUES (1333,'DEMOFAN','../../../../Data_Image/quat/quat4b.jpg','M33','TanNhiet')
INSERT INTO HinhAnh VALUES (1433,'DEMOFAN','../../../../Data_Image/quat/quat4c.jpg','M33','TanNhiet')
INSERT INTO HinhAnh VALUES (1533,'DEMOFAN','../../../../Data_Image/quat/quat4d.jpg','M33','TanNhiet')

INSERT INTO SanPham VALUES ('M34',N'Tản nhiệt RGB Build','TanNhiet','CAI','HanQuoc','Koata',5,120000)
INSERT INTO TanNhiet VALUES ('M34',10,20,'20x20',10, 120)
INSERT INTO HinhAnh VALUES (1234,'DEMOFAN','../../../../Data_Image/quat/quat5a.jpg','M34','TanNhiet')
INSERT INTO HinhAnh VALUES (1334,'DEMOFAN','../../../../Data_Image/quat/quat5b.jpg','M34','TanNhiet')
INSERT INTO HinhAnh VALUES (1434,'DEMOFAN','../../../../Data_Image/quat/quat5c.jpg','M34','TanNhiet')
INSERT INTO HinhAnh VALUES (1534,'DEMOFAN','../../../../Data_Image/quat/quat5d.jpg','M34','TanNhiet')
--insertUSB
INSERT INTO SanPham VALUES ('M40',N'USB 16GB','USB','CAI','VIETNAM','KINGTON',5,168000)
INSERT INTO USB VALUES ('M40','3.0',16,'NHUA', 100)
INSERT INTO HinhAnh VALUES (1241,'DEMOFAN','../../../../Data_Image/USB/usb2a.png','M40','USB')
INSERT INTO HinhAnh VALUES (1341,'DEMOFAN','../../../../Data_Image/USB/usb2b.png','M40','USB')
INSERT INTO HinhAnh VALUES (1441,'DEMOFAN','../../../../Data_Image/USB/usb2c.png','M40','USB')
INSERT INTO HinhAnh VALUES (1541,'DEMOFAN','../../../../Data_Image/USB/usb2d.png','M40','USB')

-- INSERT OCUNG 
INSERT INTO SanPham VALUES ('M50',N'Ổ cứng SSD Gắn ngoài','oCung','CAI','VIETNAM','samsung',5,1168000)
INSERT INTO oCung VALUES ('M50','SSD',128)
INSERT INTO HinhAnh VALUES (1250,'DEMOOCUNG','../../../../Data_Image/oCung/ocung1a.jpg','M50','oCung')
INSERT INTO HinhAnh VALUES (1350,'DEMOOCUNG','../../../../Data_Image/oCung/ocung1b.jpg','M50','oCung')
INSERT INTO HinhAnh VALUES (1450,'DEMOOCUNG','../../../../Data_Image/oCung/ocung1c.jpg','M50','oCung')
INSERT INTO HinhAnh VALUES (1550,'DEMOOCUNG','../../../../Data_Image/oCung/ocung1d.jpg','M50','oCung')

INSERT INTO SanPham VALUES ('M51',N'Ổ cứng HDD 256GB','oCung','CAI','thailan','toshiba',5,2264000)
INSERT INTO oCung VALUES ('M51','SSD',256)
INSERT INTO HinhAnh VALUES (1251,'DEMOOCUNG','../../../../Data_Image/oCung/ocung2a.jpg','M51','oCung')
INSERT INTO HinhAnh VALUES (1351,'DEMOOCUNG','../../../../Data_Image/oCung/ocung2b.jpg','M51','oCung')
INSERT INTO HinhAnh VALUES (1451,'DEMOOCUNG','../../../../Data_Image/oCung/ocung2c.jpg','M51','oCung')
INSERT INTO HinhAnh VALUES (1551,'DEMOOCUNG','../../../../Data_Image/oCung/ocung2d.jpg','M51','oCung')

INSERT INTO SanPham VALUES ('M52',N'Ổ cứng WD 256GB','oCung','CAI','trung quoc','wd',5,1999000)
INSERT INTO oCung VALUES ('M52','SSD',256)
INSERT INTO HinhAnh VALUES (1252,'DEMOOCUNG','../../../../Data_Image/oCung/ocung3a.jpg','M52','oCung')
INSERT INTO HinhAnh VALUES (1352,'DEMOOCUNG','../../../../Data_Image/oCung/ocung3b.jpg','M52','oCung')
INSERT INTO HinhAnh VALUES (1452,'DEMOOCUNG','../../../../Data_Image/oCung/ocung3c.jpg','M52','oCung')
INSERT INTO HinhAnh VALUES (1552,'DEMOOCUNG','../../../../Data_Image/oCung/ocung3d.jpg','M52','oCung')

INSERT INTO SanPham VALUES ('M53',N'Ổ cứng SSD M2 256','oCung','CAI','trung quoc','wd',5,1999000)
INSERT INTO oCung VALUES ('M53','SSD',256)
INSERT INTO HinhAnh VALUES (1253,'DEMOOCUNG','../../../../Data_Image/oCung/ocung4a.jpg','M53','oCung')
INSERT INTO HinhAnh VALUES (1353,'DEMOOCUNG','../../../../Data_Image/oCung/ocung4b.jpg','M53','oCung')
INSERT INTO HinhAnh VALUES (1453,'DEMOOCUNG','../../../../Data_Image/oCung/ocung4c.jpg','M53','oCung')
INSERT INTO HinhAnh VALUES (1553,'DEMOOCUNG','../../../../Data_Image/oCung/ocung4d.jpg','M53','oCung')





















--CODE DUOI DAY KHONG CHAY

DELETE FROM HinhAnh where relation_masp='M12'
select * from dbo.SanPham
SELECT * FROM dbo.SanPham s INNER JOIN dbo.BanPhim bp on s.masp = bp.masp
SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.BanPhim bp ON h.relation_masp = bp.masp
SELECT * FROM dbo.SanPham s INNER JOIN dbo.Chuot c on s.masp=c.masp
SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.Chuot c ON h.relation_masp = c.masp

DELETE FROM SANPHAM WHERE masp='M31'
DELETE FROM TanNhiet WHERE masp='M31'
DELETE FROM HINHANH WHERE relation_masp='M31'

select * FROM HinhAnh h INNER JOIN dbo.BanPhim bp on h.relation_masp = bp.masp
select loaisp from SanPham where masp = 'M12'
SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.Chuot c ON h.relation_masp = c.masp where c.masp='M12'
select *from dbo.HinhAnh h inner join dbo.BanPhim bp ON h.relation_masp= bp.masp where bp.masp='M12'
SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.BanPhim bp ON h.relation_masp = bp.masp where bp.masp='M12'
SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.BanPhim bp ON h.relation_masp = bp.masp where bp.masp= 'M12'

SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.BanPhim bp ON h.relation_masp = bp.masp
SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.BanPhim bp ON h.relation_masp = bp.masp where bp.masp='M12'
select *from dbo.chuot c inner join dbo.HinhAnh h on h.relation_masp = c.masp
