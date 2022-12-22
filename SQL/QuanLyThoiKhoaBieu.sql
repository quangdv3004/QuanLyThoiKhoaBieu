-- =============================================
-- Author:		Đặng Văn Quang
-- Create date: 14/12/2022
-- Description:	DB Quản lý thời khóa biểu
-- =============================================
create database QuanLyThoiKhoaBieu
go
-- Tạo bảng
create table Phong
(
	maPhong int identity(1,1) primary key,
	tenPhong nvarchar(100)
)
create table Khoa
(
	maKhoa int identity(1,1) primary key,
	tenKhoa nvarchar(50)
)
create table Nganh
(
	maNganh int identity(1,1) primary key,
	tenNganh nvarchar(50),
	maKhoa int foreign key references Khoa(maKhoa)
)
create table Lop_QL
(
	maLop int identity(1,1) primary key,
	tenLop nvarchar(50),
	maNganh int foreign key references Nganh(maNganh)
)
create table HocPhan
(
	maHP int identity(1,1) primary key,
	tenHP nvarchar(50),
	soTinChi int
)
create table CTDT /* Chuog trinh dao tao*/
(
	maCTDT int identity(1,1) primary key,
	tenCTDT nvarchar(50),
	tgianDT nvarchar(50),
	ngayKy datetime,
	maNganh int foreign key references Nganh(maNganh)
)
create table ChiTietCTDT
(
	maChiTiet int identity(1,1) primary key,
	maHP int foreign key references HocPhan(maHP),
	maCTDT int foreign key references CTDT(maCTDT),
)
create table GiangVien
(
	maGV int identity(1,1) primary key,
	tenGV nvarchar(50),
	ngaySinh datetime,
	gioiTinh bit,
	email varchar(50),
	dienThoai varchar(10),
)
create table HocKy_NienKhoa
(
	maHK int identity(1,1) primary key,
	hocKy nvarchar(20),
	nienKhoa nvarchar(20)
)
create table PhanCongGiangDay
(
	maPCGD int identity(1,1) primary key,
	maHP int foreign key references HocPhan(maHP),
	maGV int foreign key references GiangVien(maGV),
	maHK int foreign key references HocKy_NienKHoa(maHK),
)
create table DangKy
(
	maDangKy int identity(1,1) primary key,
	maPCGD int foreign key references PhanCongGiangDay(maPCGD),
	maHP int foreign key references HocPhan(maHP),
	maGV int foreign key references GiangVien(maGV),
	maHK int foreign key references HocKy_NienKHoa(maHK),
)
create table SinhVien
(
	maSV int identity(1,1) primary key,
	tenSV nvarchar(50),
	maLop int foreign key references Lop_QL(maLop),
	ngaySinh datetime,
	gioiTinh bit,
	diaChi nvarchar(50),
	email nvarchar(50),
	dienThoai varchar(10),
	maDangKy int foreign key references DangKy(maDangKy),
	maHP int foreign key references HocPhan(maHP),
	maHK int foreign key references HocKy_NienKhoa(maHK)
)
create table ThoiKhoaBieu
(
	maTKB int identity(1,1) primary key,
	thu nvarchar(10),
	tiet int,
	maPhong int foreign key references  Phong(maPhong),
	maHP int foreign key references HocPhan(maHP),
	maGV int foreign key references  GiangVien(MaGV),
	maHK int foreign key references HocKy_NienKhoa(maHK),
	maPCGD int foreign key references PhanCongGiangDay(maPCGD)
)
----------------------Tạo procedure-----------------------------
---------------------Chi tiết CTDT------------------------------
use QuanLyThoiKhoaBieu
go
create procedure sp_danhSachChiTietCTDT
as
begin
	select maChiTiet as 'Mã chi tiết CTĐT', HocPhan.tenHP 'Tên học phần', HocPhan.soTinChi as 'Số tín chỉ',
	Nganh.tenNganh as 'Tên ngành', CTDT.tenCTDT as 'Tên CTĐT', CTDT.ngayKy as 'Ngày ký', CTDT.tgianDT as 'Thời gian đào tạo'
	from ChiTietCTDT inner join HocPhan on HocPhan.maHP = ChiTietCTDT.maHP
	inner join CTDT on CTDT.maCTDT = ChiTietCTDT.maCTDT
	inner join Nganh on Nganh.maNganh = CTDT.maNganh
end
go
create procedure sp_themChiTietCTDT
(
	@maHp int, @maCTDT int
)
as
begin
	insert into ChiTietCTDT(maHP, maCTDT)
	values(@maHp, @maCTDT)
end
go
create procedure sp_suaChiTietCTDT
(
	@maChiTiet int, @maHp int, @maCTDT int
)
as
begin
	update ChiTietCTDT
	set maHP = @maHP, maCTDT = @maCTDT
	where maChiTiet = @maChiTiet
end
go
create procedure sp_xoaChiTietCTDT
(
	@maChiTiet int
)
as
begin
	delete from ChiTietCTDT where maChiTiet = @maChiTiet
end
go
-----------------------Chương trình đào tạo---------------
create procedure sp_danhSachCTDT
as
begin
	select maCTDT as 'Mã CTDT', tenCTDT as 'tenCTDT', tgianDT as 'Thời gian đào tạo', ngayKy as 'Ngày ký', Nganh.tenNganh as 'Tên ngành', Khoa.tenKhoa as 'Khoa'
	from CTDT inner join Nganh on Nganh.maNganh = CTDT.maNganh
	inner join Khoa on Khoa.maKhoa = Nganh.maKhoa
end
go
create procedure sp_themCTDT
(
	@tenCTDT nvarchar(50), @tgianDT nvarchar(50), @ngayKy datetime, @maNganh int 
)
as
begin
	insert into CTDT(tenCTDT, tgianDT, ngayKy, maNganh)
	values(@tenCTDT, @tgianDT, @ngayKy, @maNganh)
end
go
create procedure sp_suaCTDT
(
	@maCTDT int, @tenCTDT nvarchar(50), @tgianDT nvarchar(50), @ngayKy datetime, @maNganh int 
)
as
begin
	update CTDT
	set tenCTDT = @tenCTDT, tgianDT = @tgianDT, ngayKy = @ngayKy, maNganh = @maNganh
	where maCTDT = @maCTDT
end
go
create procedure sp_xoaCTDT
(
	@maCTDT int
)
as
begin
	delete from CTDT where maCTDT = @maCTDT
end
go
create trigger CTDT_xoaCTDT on CTDT instead of delete
as
begin
	Delete ChiTietCTDT from ChiTietCTDT inner join deleted on deleted.maCTDT = ChiTietCTDT.maCTDT
end
go
-------------------Đăng ký---------------------------------------------------
create procedure sp_danhSachDangKy
as
begin
	select maDangKy as 'Mã đăng ký', GiangVien.tenGV as 'Tên giảng viên', PhanCongGiangDay.maPCGD as 'Mã phân công giảng dạy',
	HocPhan.tenHP as 'Tên học phần', HocPhan.soTinChi as 'Số tín chỉ', HocKy_NienKhoa.hocKy as 'Học kỳ'
	from DangKy inner join PhanCongGiangDay on PhanCongGiangDay.maPCGD = DangKy.maPCGD
	inner join HocPhan on HocPhan.maHP = DangKy.maHP
	inner join GiangVien on GiangVien.maGV = DangKy.maGV
	inner join HocKy_NienKhoa on HocKy_NienKhoa.maHK = DangKy.maHK
end
go
create procedure sp_themDangKy
(
	@maPCGD int, @maHP int, @maGV int, @maHK int
)
as
begin
	insert into DangKy(maPCGD, maHP, maGV, maHK)
	values(@maPCGD, @maHP, @maGV, @maHK)
end
go
create procedure sp_suaDangKy
(
	@maDangKy int, @maPCGD int, @maHP int, @maGV int, @maHK int
)
as
begin
	update DangKy
	set maPCGD = @maPCGD, maGV = @maGV, maHK = @maHK
	where maDangKy = @maDangKy
end
go
create procedure sp_xoaDangKy
(
	@maDangKy int
)
as
begin
	delete from DangKy where maDangKy = @maDangKy
end
go
create trigger dangKy_xoaDangKy on DangKy instead of delete
as
begin
	Delete SinhVien from SinhVien inner join deleted on SinhVien.maDangKy = deleted.maDangKy
end
go
----------------------------------Giảng viên---------------------------------------------
use QuanLyThoiKhoaBieu
go
create procedure sp_danhSachGiangVienFix
as
begin
	select maGV as 'Mã giảng viên', tenGV as 'Tên giảng viên', ngaySinh as 'Ngày sinh', 
	gioiTinh as 'Giới tính', email as 'Email', dienThoai as 'Điện thoại'
	from GiangVien
end

alter procedure sp_danhSachGiangVien
as
begin
	select maGV as 'Mã giảng viên', tenGV as 'Tên giảng viên', ngaySinh as 'Ngày sinh', 
	gioiTinh as 'Giới tính', email as 'Email', dienThoai as 'Điện thoại'
	from GiangVien
end
go
create procedure sp_themGiangVien
(
	@tenGV nvarchar(50), @ngaySinh datetime, @gioiTinh bit, @email varchar(50), @dienThoai varchar(10)
)
as
begin
	insert into GiangVien(tenGV, ngaySinh, gioiTinh, email, dienThoai)
	values(@tenGV, @ngaySinh, @gioiTinh, @email, @dienThoai)
end
go
create procedure sp_suaGiangVien
(
	@maGV int, @tenGV nvarchar(50), @ngaySinh datetime, @gioiTinh bit, @email varchar(50), @dienThoai varchar(10)
)
as
begin
	update GiangVien
	set tenGV = @tenGV, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, email = @email, dienThoai = @dienThoai
	where maGV = @maGV
end
go
create procedure sp_xoaGiangVien
(
	@maGV int
)
as
begin
	delete from GiangVien where maGV = @maGV
end
go
----------------------------------------------Học kỳ----------------------------------------------------------
use QuanLyThoiKhoaBieu
go
create procedure sp_danhSachHocKy
as
begin
	select maHK as 'Mã học kỳ', hocKy as 'Học kỳ', nienKhoa as 'Niên khóa'
	from HocKy_NienKhoa
end
go
create procedure sp_themHocKy
(
	@hocKy nvarchar(20), @nienKhoa nvarchar(20)
)
as
begin
	insert into HocKy_NienKhoa(hocKy, nienKhoa)
	values(@hocKy, @nienKhoa)
end
go
create procedure sp_suaHocKy
(
	@maHK int, @hocKy nvarchar(20), @nienKhoa nvarchar(20)
)
as
begin
	update HocKy_NienKhoa
	set hocKy = @hocKy, nienKhoa = @nienKhoa
	where maHK = @maHK
end
go
create procedure sp_xoaHocKy
(
	@maHK int
)
as
begin
	delete from HocKy_NienKhoa where maHK = @maHK
end
go
create trigger hocKy_xoaHocKy on HocKy_NienKhoa instead of delete
as
begin
	delete DangKy from DangKy inner join deleted on deleted.maHK = DangKy.maHK
	delete PhanCongGiangDay from PhanCongGiangDay inner join deleted on deleted.maHK = PhanCongGiangDay.maHK
	delete SinhVien from SinhVien inner join deleted on deleted.maHK = SinhVien.maHK
	delete ThoiKhoaBieu from ThoiKhoaBieu inner join deleted on deleted.maHK = ThoiKhoaBieu.maHK
end
go
--------------------------Học phần----------------------------------
create procedure sp_danhSachHocPhan
as
begin
	select maHP as 'Mã học phần', tenHP as 'Tên học phần', soTinChi as 'Số tín chỉ'
	from HocPhan
end
go
create procedure sp_themHocPhan
(
	@tenHP nvarchar(50), @soTinChi int
)
as
begin
	insert into HocPhan(tenHP, soTinChi)
	values(@tenHP, @soTinChi)
end
go
create procedure sp_suaHocPhan
(
	@maHP int, @tenHP nvarchar(50), @soTinChi int
)
as
begin
	update HocPhan
	set tenHP = @tenHP, soTinChi = @soTinChi
	where maHP = @maHP
end
go
create procedure sp_xoaHocPhan
(
	@maHP int
)
as
begin
	delete from HocPhan where maHP = @maHP
end
go
create trigger hocPhan_XoaHocPhan on HocPhan instead of delete
as
begin
	delete ChiTietCTDT from ChiTietCTDT inner join deleted on deleted.maHP = ChiTietCTDT.maHP
	delete DangKy from DangKy inner join deleted on deleted.maHP = DangKy.maHP
	delete PhanCongGiangDay from PhanCongGiangDay inner join deleted on deleted.maHP = PhanCongGiangDay.maHP
	delete SinhVien from SinhVien inner join deleted on deleted.maHP = SinhVien.maHP
	delete ThoiKhoaBieu from ThoiKhoaBieu inner join deleted on deleted.maHP = ThoiKhoaBieu.maHP
end
go
--------------------Khoa-----------------------------
create procedure sp_danhSanhKhoa
as
begin
	select maKhoa as 'Mã khoa', tenKhoa as 'Tên khoa'
	from Khoa
end
go
create procedure sp_themKhoa
(
	@tenKhoa nvarchar(50)
)
as
begin
	insert into Khoa(tenKhoa)
	values(@tenKhoa)
end
go
create procedure sp_suaKhoa
(
	@maKhoa int, @tenKhoa nvarchar(50)
)
as
begin
	update Khoa
	set tenKhoa = @tenKhoa
	where maKhoa = @maKhoa
end
go
create procedure sp_xoaKhoa
(
	@maKhoa int
)
as
begin
	delete from Khoa where maKhoa = @maKhoa
end
go
create trigger khoa_xoaKhoa on Khoa instead of delete
as
begin
	delete Nganh from Nganh inner join deleted on deleted.maKhoa = Nganh.maKhoa
end
go
------------------------Lớp quản lý----------------------
create procedure sp_danhSachLopQuanLy
as
begin
	select maLop as 'Mã lớp', tenLop as 'Tên lớp',
	Nganh.tenNganh as 'Tên ngành', Khoa.tenKhoa as 'Tên khoa'
	from Lop_QL inner join Nganh on Nganh.maNganh = Lop_QL.maNganh
	inner join Khoa on Khoa.maKhoa = Nganh.maKhoa
end
go
create procedure sp_themLopQuanLy
(
	@tenLop nvarchar(50), @maNganh int
)
as
begin
	insert into Lop_QL(tenLop, maNganh)
	values(@tenLop, @maNganh)
end
go
create procedure sp_suaLopQuanLy
(
	@maLop int, @tenLop nvarchar(50), @maNganh int
)
as
begin
	update Lop_QL
	set tenLop = @tenLop, maNganh = @maNganh
	where maLop = @maLop
end
go
create procedure sp_xoaLopQuanLy
(
	@maLop int
)
as
begin
	delete from Lop_QL where maLop = @maLop
end
go
create trigger lop_xoaLop on Lop_QL instead of delete
as
begin
	delete SinhVien from SinhVien inner join deleted on deleted.maLop = SinhVien.maLop
end
go
-----------------------------Ngành---------------------------------------
create procedure sp_danhSachNganh
as
begin
	select maNganh as 'Mã ngành', tenNganh as 'Tên ngành', Khoa.tenKhoa as 'Tên khoa'
	from Nganh
	inner join Khoa on Khoa.maKhoa = Nganh.maKhoa
end
go
create procedure sp_themNganh
(
	@tenNganh nvarchar(50), @maKhoa int
)
as
begin
	insert into Nganh(tenNganh, maKhoa)
	values(@tenNganh, @maKhoa)
end
go
create procedure sp_suaNganh
(
	@maNganh int, @tenNganh nvarchar(50), @maKhoa int
)
as
begin
	update Nganh
	set tenNganh = @tenNganh, maKhoa = @maKhoa
	where maNganh = @maNganh
end
go
create procedure sp_xoaNganh
(
	@maNganh int
)
as
begin
	delete from Nganh where maNganh = @maNganh
end
go
create trigger nganh_xoaNganh on Nganh instead of delete
as
begin
	delete CTDT from CTDT inner join deleted on deleted.maNganh = CTDT.maNganh
	delete Lop_QL from Lop_QL inner join deleted on deleted.maNganh = Lop_QL.maNganh
end
go
------------------------Lớp quản lý----------------------
create procedure sp_danhSachLopQuanLy
as
begin
	select maLop as 'Mã lớp', tenLop as 'Tên lớp',
	Nganh.tenNganh as 'Tên ngành', Khoa.tenKhoa as 'Tên khoa'
	from Lop_QL inner join Nganh on Nganh.maNganh = Lop_QL.maNganh
	inner join Khoa on Khoa.maKhoa = Nganh.maKhoa
end
go
create procedure sp_themLopQuanLy
(
	@tenLop nvarchar(50), @maNganh int
)
as
begin
	insert into Lop_QL(tenLop, maNganh)
	values(@tenLop, @maNganh)
end
go
create procedure sp_suaLopQuanLy
(
	@maLop int, @tenLop nvarchar(50), @maNganh int
)
as
begin
	update Lop_QL
	set tenLop = @tenLop, maNganh = @maNganh
	where maLop = @maLop
end
go
create procedure sp_xoaLopQuanLy
(
	@maLop int
)
as
begin
	delete from Lop_QL where maLop = @maLop
end
go
create trigger lop_xoaLop on Lop_QL instead of delete
as
begin
	delete SinhVien from SinhVien inner join deleted on deleted.maLop = SinhVien.maLop
end
go
-----------------------------Phân công giảng dạy---------------------------------------
create procedure sp_danhSachPCGD
as
begin
	select maPCGD as 'Mã PCGD',  HocPhan.tenHP as 'Tên học phần',
	GiangVien.tenGV as 'Tên giảng viên', HocKy_NienKhoa.hocKy as 'Học kỳ'
	from PhanCongGiangDay
	inner join HocPhan on HocPhan.maHP = PhanCongGiangDay.maHP
	inner join GiangVien on GiangVien.maGV = PhanCongGiangDay.maGV
	inner join HocKy_NienKhoa on HocKy_NienKhoa.maHK = PhanCongGiangDay.maHK
end
go
create procedure sp_themPCGD
(
	@maHP int, @maGV int, @maHK int
)
as
begin
	insert into PhanCongGiangDay(maHP, maGV, maHK)
	values(@maHP, @maGV, @maHK)
end
go
create procedure sp_suaPCGD
(
	@maPCGD int, @maHP int, @maGV int, @maHK int
)
as
begin
	update PhanCongGiangDay
	set maHP = @maHP, maGV = @maGV, maHK = @maHK
	where maPCGD = @maPCGD
end
go
create procedure sp_xoaPCGD
(
	@maPCGD int
)
as
begin
	delete from PhanCongGiangDay where maPCGD = @maPCGD
end
go
create trigger giangVien_xoaGiangVien on GiangVien instead of delete
as
begin
	delete PhanCongGiangDay from PhanCongGiangDay inner join deleted on deleted.maGV = PhanCongGiangDay.maGV
end
go
create trigger PCGD_xoaPCGD on PhanCongGiangDay instead of delete
as
begin
	delete ThoiKhoaBieu from ThoiKhoaBieu inner join deleted on deleted.maPCGD = ThoiKhoaBieu.maPCGD
	delete DangKy from DangKy inner join deleted on deleted.maPCGD = DangKy.maPCGD
end
go
-----------------------------Phòng---------------------------------------
create procedure sp_danhSachPhong
as
begin
	select maPhong as 'Mã phòng',  tenPhong as 'Tên phòng'
	from Phong
end
go
create procedure sp_themPhong
(
	@tenPhong nvarchar(100)
)
as
begin
	insert into Phong(tenPhong)
	values(@tenPhong)
end
go
create procedure sp_suaPhong
(
	@maPhong int, @tenPhong nvarchar(100)
)
as
begin
	update Phong
	set tenPhong = @tenPhong
	where maPhong = @maPhong
end
go
create procedure sp_xoaPhong
(
	@maPhong int
)
as
begin
	delete from Phong where maPhong = @maPhong
end
go
create trigger phong_xoaPhong on Phong instead of delete
as
begin
	delete ThoiKhoaBieu from ThoiKhoaBieu inner join deleted on deleted.maPhong = ThoiKhoaBieu.maPhong
end
go
-----------------------------Sinh viên---------------------------------------
create procedure sp_danhSachSinhVien
as
begin
	select maSV as 'Mã sinh viên',  tenSV as 'Tên sinh viên', Lop_QL.tenLop as 'Tên lớp',
	ngaySinh as 'Ngày sinh', gioiTinh as 'Giới tính', diaChi as 'Địa chỉ',
	email as 'Email', dienThoai as 'Điện thoại', DangKy.maDangKy as 'Mã đăng ký',
	HocPhan.tenHP as 'Tên học phần', HocKy_NienKhoa.hocKy as 'Học kỳ'
	from SinhVien
	inner join Lop_QL on Lop_QL.maLop = SinhVien.maLop
	inner join DangKy on DangKy.maDangKy = SinhVien.maDangKy
	inner join HocPhan on HocPhan.maHP = SinhVien.maHP
	inner join HocKy_NienKhoa on HocKy_NienKhoa.maHK = SinhVien.maHK
end
go

insert into Khoa(tenKhoa)
values(N'Công nghệ thông tin')

insert into Nganh(tenNganh, maKhoa)
values(N'Lập trình Web', 1)

insert into SinhVien(tenSV)
values(N'Đặng Văn Quang')

insert into Lop_QL(tenLop, maNganh)
values(N'Công nghệ thông tin 1', 1)


alter table SinhVien
add tenDangNhap varchar(20),
matKhau varchar(20)
alter table ThoiKhoaBieu
add maLop int foreign key references Lop_QL(maLop)
go

use QuanLyThoiKhoaBieu
go
create procedure sp_danhSachTKB
(
	@maSV int
)
as
begin
	select maTKB as 'Mã TKB', thu as 'Thứ', tiet as 'Tiết', GiangVien.tenGV as 'Tên giảng viên',
	Phong.tenPhong as 'Phòng', HocPhan.tenHP as 'Học phần', PhanCongGiangDay.maPCGD 'Mã phân công giảng dạy',
	HocKy_NienKhoa.hocKy as 'Học kì'
	from ThoiKhoaBieu
	inner join Phong on Phong.maPhong = ThoiKhoaBieu.maPhong
	inner join HocPhan on HocPhan.maHP = ThoiKhoaBieu.maHP
	inner join GiangVien on GiangVien.maGV = ThoiKhoaBieu.maGV
	inner join HocKy_NienKhoa on HocKy_NienKhoa.maHK = ThoiKhoaBieu.maHK
	inner join PhanCongGiangDay on PhanCongGiangDay.maPCGD = ThoiKhoaBieu.maPCGD
	inner join Lop_QL on Lop_QL.maLop = ThoiKhoaBieu.maLop
	where Lop_QL.maLop = (select maLop from SinhVien where SinhVien.maSV = @maSV)
end
go
create procedure sp_themThoiKHoaBieu
(
	@thu nvarchar(10), @tiet int, @maPhong int, @maHP int, @maGV int, @maHK int, @maPCGD int, @maLop int
)
as
begin
	insert into ThoiKhoaBieu(thu, tiet, maPhong, maHP, maGV, maHK, maPCGD, maLop)
	values(@thu, @tiet, @maPhong, @maHP, @maGV, @maHK, @maPCGD, @maLop)
end
go
create procedure sp_suaThoiKHoaBieu
(
	@maTKB int, @thu nvarchar(10), @tiet int, @maPhong int, @maHP int, @maGV int, @maHK int, @maPCGD int, @maLop int
)
as
begin
	update ThoiKhoaBieu
	set thu = @thu, tiet = @tiet, maPhong = @maPhong, maHP = @maHP, maGV = @maGV, maHK = @maHK, maPCGD = @maPCGD, maLop = @maLop
	where ThoiKhoaBieu.maTKB = @maTKB
end
go
create procedure sp_xoaThoiKhoaBieu
(
	@maTKB int
)
as
begin
	delete from ThoiKhoaBieu
	where ThoiKhoaBieu.maTKB = @maTKB
end
go

create procedure sp_themGiangVienTest
(
	@tenGV nvarchar(50), @gioiTinh bit, @email varchar(50), @dienThoai varchar(10)
)
as
begin
	insert into GiangVien(tenGV, gioiTinh, email, dienThoai)
	values(@tenGV, @gioiTinh, @email, @dienThoai)
end
go
alter table GiangVien
alter column ngaySinh date
create procedure sp_danhSachGiangVienFixSecond
as
begin
	select maGV as 'Mã giảng viên', tenGV as 'Tên giảng viên', ngaySinh as 'Ngày sinh', 
	case 
		when gioiTinh = 1 then 'Nam'
		when gioiTinh = 0 then 'Nữ'
	end as 'Giới tính',
	email as 'Email', dienThoai as 'Điện thoại'
	from GiangVien
end
use QuanLyThoiKhoaBieu
go
create procedure sp_getPCGD4CB
as
begin
	select maPCGD as 'id', maPCGD as 'name'
	from PhanCongGiangDay
end
go
create procedure sp_getGiangVien4CB
as
begin
	select maGV as 'id', tenGV as 'name'
	from GiangVien
end
go
create procedure sp_getHocPhan4CB
as
begin
	select maHP as 'id', tenHP as 'name'
	from HocPhan
end
go
create procedure sp_getHocKy4CB
as
begin
	select maHK as 'id', hocKy as 'name'
	from HocKy_NienKhoa
end
go

use QuanLyThoiKhoaBieu
go
create procedure sp_getLop4CB
as
begin
	select maLop as 'id', tenLop as 'name'
	from Lop_QL
end
go
use QuanLyThoiKhoaBieu
go
create procedure sp_danhSachSinhVienFouth
as
begin
	select maSV as 'Mã sinh viên', avatar as 'Ảnh đại diện' , tenSV as 'Tên sinh viên', Lop_QL.tenLop as 'Tên lớp',
	ngaySinh as 'Ngày sinh', 
	case 
		when gioiTinh = 1 then 'Nam'
		when gioiTinh = 0 then 'Nữ'
	end as 'Giới tính',
	diaChi as 'Địa chỉ',
	email as 'Email', dienThoai as 'Điện thoại', tenDangNhap as 'Tên đăng nhâp',
	matKhau as 'Mật khẩu', DangKy.maDangKy as 'Mã đăng ký',
	HocPhan.tenHP as 'Tên học phần', HocKy_NienKhoa.hocKy as 'Học kỳ'
	from SinhVien
	inner join Lop_QL on Lop_QL.maLop = SinhVien.maLop
	inner join DangKy on DangKy.maDangKy = SinhVien.maDangKy
	inner join HocPhan on HocPhan.maHP = SinhVien.maHP
	inner join HocKy_NienKhoa on HocKy_NienKhoa.maHK = SinhVien.maHK
end
go
create procedure sp_danhSachSinhVienSecond
as
begin
	select maSV as 'Mã sinh viên', avatar as 'Ảnh đại diện' , tenSV as 'Tên sinh viên', Lop_QL.tenLop as 'Tên lớp',
	ngaySinh as 'Ngày sinh', gioiTinh as 'Giới tính', diaChi as 'Địa chỉ',
	email as 'Email', dienThoai as 'Điện thoại', DangKy.maDangKy as 'Mã đăng ký',
	HocPhan.tenHP as 'Tên học phần', HocKy_NienKhoa.hocKy as 'Học kỳ'
	from SinhVien
	inner join Lop_QL on Lop_QL.maLop = SinhVien.maLop
	inner join DangKy on DangKy.maDangKy = SinhVien.maDangKy
	inner join HocPhan on HocPhan.maHP = SinhVien.maHP
	inner join HocKy_NienKhoa on HocKy_NienKhoa.maHK = SinhVien.maHK
end
go
create procedure sp_themSinhVien
(
	@tenSV nvarchar(50), @maLop int, @ngaySinh datetime, @gioiTinh bit, @diaChi nvarchar(50),
	@email nvarchar(50), @dienThoai nvarchar(50), @maDangKy int, @maHP int, @maHK int, @tenDangNhap varchar(20),
	@matKhau varchar(20), @avatar image
)
as
begin
	insert into SinhVien(tenSV, maLop, ngaySinh, gioiTinh, diaChi, email, dienThoai, maDangKy, maHP, maHK, tenDangNhap, matKhau, avatar)
	values (@tenSV, @maLop, @ngaySinh, @gioiTinh, @diaChi,
	@email, @dienThoai, @maDangKy, @maHP, @maHK, @tenDangNhap,
	@matKhau, @avatar)
end
go
create procedure sp_suaSinhVien
(
	@maSV int, @tenSV nvarchar(50), @maLop int, @ngaySinh datetime, @gioiTinh bit, @diaChi nvarchar(50),
	@email nvarchar(50), @dienThoai nvarchar(50), @maDangKy int, @maHP int, @maHK int, @tenDangNhap varchar(20),
	@matKhau varchar(20), @avatar image
)
as
begin
	update SinhVien
	set tenSV = @tenSV, maLop = @maLop, ngaySinh = @ngaySinh, diaChi = @diaChi, email = @email,
	dienThoai = @dienThoai, maDangKy = @maDangKy, maHP = @maHP, maHK = @maHK, tenDangNhap = @tenDangNhap, matKhau = @matKhau, avatar = @avatar
	where maSV = @maSV
end
go
create procedure sp_xoaSinhVien
( @maSV int )
as
begin
	delete from SinhVien where SinhVien.maSV = @maSV
end
go
alter table SinhVien
add avatar image
go
create procedure sp_getCTDT4CB
as
begin
	select maCTDT as 'id', tenCTDT as 'name'
	from CTDT
end
go
create procedure sp_getNganh4CB
as
begin
	select maNganh as 'id', tenNganh as 'name'
	from Nganh
end
go
create procedure sp_getKhoa4CB
as
begin
	select maKhoa as 'id', tenKhoa as 'name'
	from Khoa
end
go