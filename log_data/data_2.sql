create table CTBH 
(	
	ma_ban int NOT NULL,
	ID_nguoiban int NOT NULL,
	ma_sp nvarchar(10) NOT NULL,
	ngayban datetime,
	constraint PK_CTBH primary key(ma_ban)
)
alter table CTBH
add constraint FK_CTBH_Account
foreign key (ID_nguoiban) references Account(ID)
 
alter table CTBH
add constraint FK_CTBH_SanPham
foreign key(ma_sp) references SanPham(ma_sp)



create table CTKD
(
	ma_kiemduyet int NOT NULL,
	ma_ban int NOT NULL,
	ID_nguoikiemduyet int NOT NULL,
	ngaykiemduyet datetime,
	trangthai varchar(10),
	constraint PK_CTKD primary key(ma_kiemduyet)
)

alter table CTKD
add constraint FK_CTKD_Account 
foreign key(ID_nguoikiemduyet) references Account(ID)

alter table CTKD
add constraint FK_CTKD_CTBH
foreign key(ma_ban) references CTBH(ma_ban)

alter table SanPham
add chitiet text