select *from sanpham
select * from hinhanh
select * from hoadon
select * from cthd

----------
set dateformat dmy
alter table cthd 
add ngaybatdaugiao datetime null

alter table cthd 
add ngayhoanthanh datetime null

alter table cthd
add trigia bigint default 0

create trigger update_trigia_cthd on cthd 
for insert
as
	update cthd set trigia = sl * (select gia from sanpham where ma_sp=cthd.masp)

-----------
select count (C.masp) as con
from cthd C, hoadon H
where c.sohd=h.sohd and h.nghd > '29-11-2020 10:04:40.003'
Select count (masp) as sl from CTHD where trangthai = 'dang giao hang'  and ngayhoanthanh is NUll
                and masp in(select ma_sp from sanpham  where ID_ngban = 10013 )

update cthd set trigia = sl * (select gia from sanpham where ma_sp=cthd.masp) where sohd>0

select sum(trigia) as dt from cthd 
where trangthai = 'da giao hang' 
and masp in(select ma_sp from sanpham  where ID_ngban = 10013 )

select sum(trigia) as dt, format(ngayhoanthanh,'MM/yyyy') as my
from cthd
where masp in(select ma_sp from sanpham  where ID_ngban = 10013 ) and ngayhoanthanh is not NULL
and ngayhoanthanh < '31/12/2020'
group by format(ngayhoanthanh,'MM/yyyy')