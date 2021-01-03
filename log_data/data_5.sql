create table GioHang
(
	idnguoimua int not null, 
	soluong_giohang int default 1,
	isSelect bit default 1,
	ma_sp nvarchar(10) not null
)
alter table giohang 
add constraint FK_giohang_account 
foreign key (idnguoimua) references Account(ID)
select * from dbo.hinhanh

create table NhanXet
(
   idnguoimua int not null, 
   vote int not null, 
   ma_sp nvarchar(10) not null, 
   nhanxet_chinh nvarchar(100), 
   nhanxet_chitiet nvarchar(400), 
   ngayNhanXet datetime default getdate()    
)
alter table NhanXet 
add constraint FK_nhanxet_account
foreign key (idnguoimua) references Account(ID)

alter table NhanXet 
add constraint FK_nhanxet_sanpham 
foreign key (ma_sp) references SanPham (ma_sp)

--create view
create view nhanxetItem as
select a.id, nx.ma_sp, name, ngaynhanxet, vote, nhanxet_chinh, nhanxet_chitiet
from dbo.nhanxet nx, dbo.account a, dbo.infor info
where nx.idnguoimua= a.id and a.username= info.username

/* Cac San pham DAXEM, DA MUA...*/
create table SanPhamDaXem
(
     ma_sanphamdaxem int identity,
	 idnguoimua int not null ,
	 ma_sp nvarchar(10) not null,
	 constraint PK_SanPhamDaXem primary key(ma_sanphamdaxem)
)

create table SanPhamYeuThich
(
     ma_sanphamyeuthich int identity,
	 idnguoimua int not null ,
	 ma_sp nvarchar(10) not null,
	 constraint PK_SanPhamYeuThich primary key(ma_sanphamyeuthich)
)
create table SanPhamMuaSau
(
     ma_sanphammuasau int identity,
	 idnguoimua int not null ,
	 ma_sp nvarchar(10) not null,
	 constraint PK_SanPhamMuaSau primary key(ma_sanphammuasau)
)
create table SanPhamDaMua
(
     ma_sanphamdamua int identity,
	 idnguoimua int not null ,
	 ma_sp nvarchar(10) not null,
	 constraint PK_SanPhamDaMua primary key(ma_sanphamdamua)
)



go
SELECT * FROM dbo.SanPham sp ,giohang gh where sp.ma_sp = gh.ma_sp and
idnguoimua=''
select * from dbo.sanpham sp left join giohang gh on sp.ma_sp = gh.ma_sp
where idnguoimua=(
select id from dbo.account where username='lamhong')

drop table dbo.GioHang