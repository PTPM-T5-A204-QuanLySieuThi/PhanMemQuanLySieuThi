CREATE DATABASE DB_SIEUTHI
GO

USE DB_SIEUTHI
GO

--------------------------------------------------- [ KHỞI TẠO CÁC BẢNG DỮ LIỆU ] ---------------------------------------------------
--------------------- BẢNG QUYỀN TRUY CẬP
CREATE TABLE QUYENTRUYCAP
(
	MAQTC			INT NOT NULL IDENTITY(1, 1),
	TENQTC			NVARCHAR(50),
	CONSTRAINT PK_QUYENTRUYCAP PRIMARY KEY(MAQTC)
);

--------------------- BẢNG TÀI KHOẢN
CREATE TABLE TAIKHOAN
(
	ID				INT IDENTITY(1,1) NOT NULL,
    MATK			AS 'TK' + RIGHT('000' + CAST(ID AS VARCHAR(3)), 3) PERSISTED NOT NULL,
	MATKHAU			NVARCHAR(6),
	MAQTC			INT NOT NULL,
	CONSTRAINT PK_TAIKHOAN PRIMARY KEY(MATK)
);

--------------------- BẢNG NHÂN VIÊN
CREATE TABLE NHANVIEN
(
	MANV			VARCHAR(10) NOT NULL,
	HOTEN			NVARCHAR(50),
	ANHDAIDIEN		VARCHAR(100),
	NGAYSINH		DATE,
	GIOITINH		NVARCHAR(5),
	DIACHI			NVARCHAR(200),
	SODIENTHOAI		VARCHAR(10),
	EMAIL			VARCHAR(30),
	MATK			VARCHAR(5) NOT NULL,
	CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANV)
);

--------------------- BẢNG ĐƠN VỊ TÍNH
CREATE TABLE DONVITINH
(
	MADVT			VARCHAR(10) NOT NULL,
	TENDVT			NVARCHAR(50),
	CONSTRAINT PK_DONVITINH PRIMARY KEY(MADVT)
);

--------------------- BẢNG NƯỚC XUẤT XỨ
CREATE TABLE NUOCXUATXU
(
	MANXX			VARCHAR(10) NOT NULL,
	TENNXX			NVARCHAR(50),
	CONSTRAINT PK_NUOCXUATXU PRIMARY KEY(MANXX)
);

--------------------- BẢNG NHÀ CUNG CẤP
CREATE TABLE NHACUNGCAP
(
	MANCC			VARCHAR(10) NOT NULL,
	TENNCC			NVARCHAR(50),
	DIACHI			NVARCHAR(200),
	SODIENTHOAI		VARCHAR(25),
	CONSTRAINT PK_NHACUNGCAP PRIMARY KEY(MANCC)
);

--------------------- BẢNG LOẠI SẢN PHẨM
CREATE TABLE LOAISANPHAM
(
	MALSP			VARCHAR(10) NOT NULL,
	TENLSP			NVARCHAR(50),
	CONSTRAINT PK_LOAISANPHAM PRIMARY KEY(MALSP)
);

--------------------- BẢNG CHI TIẾT LOẠI SẢN PHẨM
CREATE TABLE CTLOAISANPHAM
(
	MACTLSP			VARCHAR(10) NOT NULL,
	TENCTLSP		NVARCHAR(50),
	MALSP			VARCHAR(10) NOT NULL,
	CONSTRAINT PK_CTLOAISANPHAM PRIMARY KEY(MACTLSP)
);

--------------------- BẢNG SẢN PHẨM
CREATE TABLE SANPHAM
(
	MASP			VARCHAR(10) NOT NULL,
	BARCODE			VARCHAR(20),
	TENSP			NVARCHAR(150),
	ANHSANPHAM		VARCHAR(100),
	NGAYSX			DATE,
	HANSD			DATE,
	GIASP			DECIMAL(18, 0),
	MOTA			NVARCHAR(500),
	SLTON			INT,
	MANXX			VARCHAR(10) NOT NULL,
	MANCC			VARCHAR(10) NOT NULL,
	MADVT			VARCHAR(10) NOT NULL,
	MACTLSP			VARCHAR(10) NOT NULL,
	CONSTRAINT PK_SANPHAM PRIMARY KEY(MASP)
);

--------------------- BẢNG KHUYẾN MÃI
CREATE TABLE KHUYENMAI
(
	MAKM			VARCHAR(10) NOT NULL,
	TENKM			NVARCHAR(50),
	NGAYBATDAU		DATE,
	NGAYKETTHUC		DATE,
	SOGIAM			INT,
	CONSTRAINT PK_KHUYENMAI PRIMARY KEY(MAKM)
);

--------------------- BẢNG CHI TIẾT KHUYẾN MÃI
CREATE TABLE CHITIETKHUYENMAI
(
	MAKM			VARCHAR(10) NOT NULL,
	MASP			VARCHAR(10) NOT NULL,
	CONSTRAINT PK_CHITIETKHUYENMAI PRIMARY KEY(MAKM, MASP)
);


--------------------- BẢNG VOUCHER
CREATE TABLE VOUCHER
(
	MAVOR			VARCHAR(15) NOT NULL,
	TENVOR			NVARCHAR(50),
	CONHAN			BIT,
	SOGIAM			VARCHAR(20),
	DIEUKIEN		NVARCHAR(100),
	CONSTRAINT PK_VOUCHER PRIMARY KEY(MAVOR)
);

--------------------- BẢNG KHÁCH HÀNG
CREATE TABLE KHACHHANG
(
	MAKH			VARCHAR(10) NOT NULL,
	HOTEN			NVARCHAR(50),
	ANHDAIDIEN		VARCHAR(100),
	NGAYSINH		DATE,
	GIOITINH		NVARCHAR(5),
	DIACHI			NVARCHAR(100),
	SODIENTHOAI		VARCHAR(10),
	MATKHAU			VARCHAR(20),
	EMAIL			VARCHAR(30),
	TINHTHANH		VARCHAR(20),
	DIEMTICHLUY		DECIMAL(5,2),
	CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKH)
);

--------------------- BẢNG HÓA ĐƠN
CREATE TABLE HOADON
(
	MAHD			VARCHAR(10) NOT NULL,
	NGAYLAP			DATE,
	TONGTIEN		DECIMAL(18, 0),
	THANHTIEN		DECIMAL(18, 0),
	MANV			VARCHAR(10) NOT NULL,
	CONSTRAINT PK_HOADON PRIMARY KEY(MAHD)
);

--------------------- BẢNG CHI TIẾT VOUCHER
CREATE TABLE CHITIETVOUCHER
(
	MAHD			VARCHAR(10) NOT NULL,
	MAVOR			VARCHAR(15) NOT NULL,
	CONSTRAINT PK_CHITIETVOUCHER PRIMARY KEY(MAHD, MAVOR)
);

--------------------- BẢNG CHI TIẾT HÓA ĐƠN
CREATE TABLE CHITIETHOADON
(
	MAHD			VARCHAR(10) NOT NULL,
	MASP			VARCHAR(10) NOT NULL,
	SOLUONG			INT,
	CONSTRAINT PK_CHITIETHOADON PRIMARY KEY(MAHD, MASP)
);

--------------------- BẢNG TÍCH ĐIỂM
CREATE TABLE TICHDIEM
(
	MATICHDIEM		VARCHAR(6) NOT NULL,
	MAHD			VARCHAR(10) NOT NULL,
	MAKH			VARCHAR(10) NOT NULL,
	CONSTRAINT PK_TICHDIEM PRIMARY KEY(MATICHDIEM)
);

--------------------------------------------------- [ RÀNG BUỘC ] ---------------------------------------------------

--------------------------------------------------------- KHÓA NGOẠI
--------------------- BẢNG TÀI KHOẢN
ALTER TABLE TAIKHOAN 
ADD CONSTRAINT FK_TAIKHOAN_QUYENTRUYCAP FOREIGN KEY(MAQTC) REFERENCES QUYENTRUYCAP(MAQTC)

--------------------- BẢNG NHÂN VIÊN
ALTER TABLE NHANVIEN 
ADD CONSTRAINT FK_NHANVIEN_TAIKHOAN FOREIGN KEY(MATK) REFERENCES TAIKHOAN(MATK)

--------------------- BẢNG CHI TIẾT LOẠI SẢN PHẨM
ALTER TABLE CTLOAISANPHAM 
ADD CONSTRAINT FK_CTLOAISANPHAM_LOAISANPHAM FOREIGN KEY(MALSP) REFERENCES LOAISANPHAM(MALSP)

--------------------- BẢNG SẢN PHẨM
ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SANPHAM_NUOCXUATXU FOREIGN KEY(MANXX) REFERENCES NUOCXUATXU(MANXX),
	CONSTRAINT FK_SANPHAM_NHACUNGCAP FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC),
	CONSTRAINT FK_SANPHAM_DONVITINH FOREIGN KEY(MADVT) REFERENCES DONVITINH(MADVT),
	CONSTRAINT FK_SANPHAM_CTLOAISANPHAM FOREIGN KEY(MACTLSP) REFERENCES CTLOAISANPHAM(MACTLSP)

--------------------- BẢNG CHI TIẾT KHUYẾN MÃI
ALTER TABLE CHITIETKHUYENMAI
ADD CONSTRAINT FK_CHITIETKHUYENMAI_SANPHAM FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP),
	CONSTRAINT FK_CHITIETKHUYENMAI_KHUYENMAI FOREIGN KEY(MAKM) REFERENCES KHUYENMAI(MAKM)

--------------------- BẢNG CHI TIẾT VOUCHER
ALTER TABLE CHITIETVOUCHER
ADD CONSTRAINT FK_CHITIETVOUCHER_HOADON FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD),
	CONSTRAINT FK_CHITIETVOUCHER_VOUCHER FOREIGN KEY(MAVOR) REFERENCES VOUCHER(MAVOR)

--------------------- BẢNG HÓA ĐƠN
ALTER TABLE HOADON
ADD	CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

--------------------- BẢNG CHI TIẾT HÓA ĐƠN
ALTER TABLE CHITIETHOADON
ADD CONSTRAINT FK_CHITIETHOADON_HOADON FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD),
	CONSTRAINT FK_CHITIETHOADON_SANPHAM FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)

--------------------- BẢNG TÍCH ĐIỂM
ALTER TABLE TICHDIEM
ADD CONSTRAINT FK_TICHDIEM_HOADON FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD),
	CONSTRAINT FK_TICHDIEM_KHACHHANG FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)

----------------------------------------------------------- TRIGGER
----------------------- TRIGGER TẠO MÃ TÀI KHOẢN THEO ĐỊNH DẠNG	
CREATE TRIGGER TAOMATAIKHOANTHEODINHDANG
ON TAIKHOAN
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO TAIKHOAN (MATKHAU, MAQTC)
    SELECT I.MATKHAU, I.MAQTC
    FROM inserted I;
END
GO

--------------------------------------------------- [ KHỞI TẠO CÁC BẢNG DỮ LIỆU ] ---------------------------------------------------
--------------------- BẢNG QUYỀN TRUY CẬP
INSERT INTO QUYENTRUYCAP(TENQTC)
VALUES
(N'Nhân viên quản lý'),
(N'Nhân viên bán hàng'),
(N'Nhân viên kiểm kê và quản lý kho')

--------------------- BẢNG TÀI KHOẢN
INSERT INTO TAIKHOAN( MATKHAU, MAQTC)
VALUES
('admin', 1),
('123', 2),
('456', 3)

--------------------- BẢNG NHÂN VIÊN
SET DATEFORMAT DMY
INSERT INTO NHANVIEN(MANV, HOTEN, ANHDAIDIEN, EMAIL, NGAYSINH, GIOITINH, DIACHI, SODIENTHOAI, MATK)
VALUES
('1011826', N'Phạm Trần Tấn Đạt', '', 'datptt@gmail.com', '22/09/2002', N'Nam', N'F11/27E2 đường Phạm Thị Nghĩ, ấp 6, Xã Vĩnh Lộc A, Huyện Bình Chánh, TP Hồ Chí Minh', '0123456789', 'TK001'),
('1011168', N'Trần Bích Phượng', '', 'phuongtb@gmail.com', '12/01/1999', N'Nữ', N' 2/33 đường 147, KP5, Phường Tăng Nhơn Phú B, Thành phố Thủ Đức, TP Hồ Chí Minh', '0987654321', 'TK002'),
('1016056', N'Phùng Thanh Độ', '', 'dopt@gmail.com', '28/10/2001', N'Nam', N'223 Hoàng Văn Thụ (K3.28 Cao ốc Kingston Residence), Phường 08, Quận Phú Nhuận, TP Hồ Chí Minh', '0123412345', 'TK002'),
('1013178', N'Phan Tấn Trung', '', 'trungpt@gmail.com', '04/04/1996', N'Nam', N'Số 103, đường số 5, Phường Linh Xuân, Thành phố Thủ Đức, TP Hồ Chí Minh', '0234567890', 'TK002'),
('1016502', N'Đặng Ngọc Bảo Châu', '', 'chaudnb@gmail.com', '25/12/1998', N'Nữ', N'Tầng 16, tòa nhà E, Town Central, số 11 Đoàn Văn Bơ, phường 13, Quận 4, TP Hồ Chí Minh', '0345678912', 'TK003'),
('1011869', N'Nguyễn Trung Thịnh', '', 'thinhnt@gmail.com', '12/07/2000', N'Nam', N'Số 473 Đỗ Xuân Hợp, Phường Phước Long B, Thành phố Thủ Đức, TP Hồ Chí Minh', '0456789123', 'TK003'),
('1011893', N'Nguyễn Quốc Bảo', '', 'baonq@gmail.com', '07/12/2000', N'Nam', N'120 Vũ Tông Phan , Khu Phố 5, Phường An Phú, Thành phố Thủ Đức, TP Hồ Chí Minh', '0567891234', 'TK002'),
('1011570', N'Trần Quốc Quy', '', 'quytq@gmail.com', '06/11/2001', N'Nam', N'72 Bình Giã, Phường 13, Quận Tân Bình, TP Hồ Chí Minh', '0678912345', 'TK003'),
('1016036', N'Lâm Quốc Huy', '', 'huylq@gmail.com', '17/08/1998', N'Nam', N'C10 Rio Vista, 72 Dương Đình Hội, Phường Phước Long B, Thành phố Thủ Đức, TP Hồ Chí Minh', '0789123456', 'TK003'),
('1019717', N'Trần Thị Vân Anh', '', 'anhttv@gmail.com', '22/02/1993', N'Nữ', N'K02, Park Riverside, 09 Bưng ông Thoàn, Phường Phú Hữu, Thành phố Thủ Đức, TP Hồ Chí Minh', '0891234567', 'TK002')

--------------------- BẢNG ĐƠN VỊ TÍNH
INSERT INTO DONVITINH(MADVT, TENDVT)
VALUES 
('1', N'Kilogram '),
('2', N'Quả '),
('3', N'Gói'),
('4', N'Hộp'),
('5', N'Lon'),
('6', N'Gram'),
('7', N'Cuốn'),
('8', N'Túi'),
('9', N'Chai'),
('10', N'Cái'),
('11', N'Thùng'),
('12', N'Lốc'),
('13', N'Can'),
('14', N'Bao'),
('15', N'Bình'),
('16', N'Bộ'),
('17', N'Cây'),
('18', N'Vỉ'),
('19', 'Ly')

--------------------- BẢNG NƯỚC XUẤT XỨ
INSERT INTO NUOCXUATXU(MANXX, TENNXX)
VALUES 
('XX001', N'Việt Nam'),
('XX002', N'Thái Lan'),
('XX003', N'Úc'),
('XX004', N'New Zealand'),
('XX005', N'Indonesia'),
('XX006', N'Đài Loan'),
('XX007', N'Đức'),
('XX008', N'Singapore'),
('XX009', N'Mỹ'),
('XX010', N'Nhật Bản'),
('XX011', N'Hàn Quốc'),
('XX012', N'Ý'),
('XX013', N'Hong Kong'),
('XX014', N'Trung Quốc'),
('XX015', N'Nga')

--------------------- BẢNG NHÀ CUNG CẤP
INSERT INTO NHACUNGCAP(MANCC, TENNCC, DIACHI, SODIENTHOAI)
VALUES
('CC001', N'Vinamilk', N'Số 10, Đường Tân Trào, phường Tân Phú, quận 7, Tp. HCM', '(028) 54 155 555'),
('CC002', N'Ba Huân', N'Trang trại chăn nuôi gà Công nghệ cao Ba Huân – Bình Dương', '1800 6002'),
('CC003', N'Tường An', N'48/5 Phan Huy ích, P. 15, Q. Tân Bình,Tp. Hồ Chí Minh (TPHCM)', '(028) 38153972'),
('CC004', N'Acecook', N'Lô số II-3,Đường số 11,Nhóm CN II, Khu Công nghiệp Tân Bình, Phường Tây Thạnh, Quận Tân Phú, Thành phố Hồ Chí Minh, Việt Nam', '(028) 3815 4064'),
('CC005', N'Nam Ngư', N'Khu Công nghiệp Tân Đông Hiệp A, huyện Dĩ An, tỉnh Bình Dương', ''),
('CC006', N'Nongshim', N'112 Yeouidaebang-Ro, Dongjak-Gu, Seoul (Shindaebang-Dong)', '080-023-5181'),
('CC007', N'Bel Việt Nam', N'Lô CN1, KCN Sóng Thần 3, Tp Thủ Dầu Một, Bình Dương', '1800 1110'),
('CC008', N'', N'', ''),
('CC009', N'', N'', ''),
('CC010', N'', N'', ''),
('CC011', N'', N'', ''),
('CC012', N'', N'', ''),
('CC013', N'', N'', ''),
('CC014', N'', N'', ''),
('CC015', N'', N'', ''),
('CC016', N'', N'', ''),
('CC017', N'', N'', '')

--------------------- BẢNG LOẠI SẢN PHẨM
INSERT INTO LOAISANPHAM(MALSP, TENLSP)
VALUES
('LS000', N'--'),
('LS001', N'Thịt, cá, trứng, hải sản'),
('LS002', N'Rau, củ, nấm, trái cây'),
('LS003', N'Dầu ăn, nước chấm, gia vị'),
('LS004', N'Kem, thực phẩm đông mát'),
('LS005', N'Mì, miến, cháo, phở'),
('LS006', N'Gạo, bột, đồ khô'),
('LS007', N'Bia, nước giải khát'),
('LS008', N'Sữa các loại'),
('LS009', N'Bánh kẹo các loại'),
('LS010', N'Chăm sóc cá nhân'),
('LS011', N'Sản phẩm cho mẹ và bé'),
('LS012', N'Vệ sinh nhà cửa'),
('LS013', N'Đồ dùng gia đình'),
('LS014', N'Chăm sóc thú cưng')

--------------------- BẢNG CHI TIẾT LOẠI SẢN PHẨM
INSERT INTO CTLOAISANPHAM(MACTLSP, TENCTLSP, MALSP)
VALUES
('CS001', N'Thịt heo', 'LS001'),
('CS002', N'Thịt bò', 'LS001'),
('CS003', N'Thịt gà, thịt vịt, thịt chim', 'LS001'),
('CS004', N'Thịt sơ chế, tẩm ướp', 'LS001'),
('CS005', N'Cá, hải sản', 'LS001'),
('CS006', N'Trứng gà, vịt, cút', 'LS001'),
('CS007', N'Thực phẩm làm sẵn', 'LS001'),
('CS008', N'Rau lá', 'LS002'),
('CS009', N'Củ, quả', 'LS002'),
('CS010', N'Nấm các loại', 'LS002'),
('CS011', N'Rau, củ làm sẵn', 'LS002'),
('CS012', N'Rau, củ đông lạnh', 'LS002'),
('CS013', N'Trái cây', 'LS002'),
('CS014', N'Dầu ăn', 'LS003'),
('CS015', N'Nước mắm', 'LS003'),
('CS016', N'Nước tương', 'LS003'),
('CS017', N'Đường', 'LS003'),
('CS018', N'Hạt nêm, bột ngọt, bột canh', 'LS003'),
('CS019', N'Muối', 'LS003'),
('CS020', N'Tương ớt - đen, mayonnaise', 'LS003'),
('CS021', N'Dầu hào, giấm, bơ', 'LS003'),
('CS022', N'Gia vị nêm sẵn', 'LS003'),
('CS023', N'Nước chấm, mắm', 'LS003'),
('CS024', N'Tiêu, sa tế, ớt bột', 'LS003'),
('CS025', N'Bột nghệ, tỏi, hồi, quế,...', 'LS003'),
('CS026', N'Sữa tươi', 'LS008'),
('CS027', N'Mì ăn liền', 'LS005'),
('CS028', N'Hủ tiếu, miến', 'LS005'),
('CS029', N'Phở, bún ăn liền', 'LS005'),
('CS030', N'Cháo gói, cháo tươi', 'LS005'),
('CS031', N'Bánh gạo Hàn Quốc', 'LS005'),
('CS032', N'Mì, nui, bún khô', 'LS005'),
('CS033', N'Sữa chua uống liền', 'LS008'),
('CS034', N'Sữa hạt, sữa đậu', 'LS008'),
('CS035', N'Sữa ca cao, lúa mạch', 'LS008'),
('CS036', N'Sữa đặc', 'LS008'),
('CS037', N'Ngũ cốc', 'LS008'),
('CS038', N'Sữa bột', 'LS008'),
('CS039', N'Sữa chua ăn', 'LS008'),
('CS040', N'Bơ sữa, phô mai', 'LS008')

--------------------- BẢNG SẢN PHẨM
SET DATEFORMAT DMY
INSERT INTO SANPHAM(MASP, BARCODE, TENSP, ANHSANPHAM, NGAYSX, HANSD, GIASP, MOTA, SLTON, MANXX, MANCC, MADVT, MACTLSP)
VALUES
('1067407', '8934988020045', N'Dầu đậu nành 100% nguyên chất Tường An can 5 lít', 'dau-dau-nanh-nguyen-chat-simply-can-5-lit.jpg', '01/11/2023', '02/11/2023', 336000, N'', 250, 'XX001', 'CC003' , '13', 'CS014'),
('1268581', '8936064240255', N'Trứng gà so QLEgg hộp 10 tặng 2', 'trung_ga_so_qlegg_hop_10_tang_2.jpg', '01/11/2023', '30/10/2023', 38500, N'', 50, 'XX001', 'CC002' , '4', 'CS006'),
('1584557', '8934673581325', N'Sữa Tươi Tiệt Trùng Vinamilk 100% Ít Đường Lốc 4 Hộp 110ML', 'loc_4_hop_sua_tuoi_tiet_trung_it_duong_vinamilk_100_sua_tuoi_180ml.jpg', '01/11/2023', '16/04/2025', 21000, N'', 250, 'XX001', 'CC001' , '12', 'CS026'),
('1701673', '8934563034832', N'Mì Hảo Hảo Tôm Chua Cay Thùng 24 Ly 67G', 'thung-30-goi-mi-hao-hao-tom-chua-cay-75g-202211181144401243.jpg', '01/11/2023', '02/11/2023', 216000 , N'', 90, 'XX001', 'CC004' , '11', 'CS027'),
('1721720', '8936017368395', N'Nước Mắm Nam Ngư 3 Trong 1 750ML', 'nuoc-mam-nam-ngu-3-trong-1-750ml.jpg', '01/11/2023', '30/10/2023', 51100, N'', 50, 'XX001', 'CC005' , '9', 'CS015'),
('1732484', '8934563679101', N'Mì Mini Doremon Hàu Sữa Phô Mai Ly 48G', 'mi-mini-doraemon-hau-sua-pho-mai-ly-48g.jpg', '01/11/2023', '16/04/2025', 11300, N'', 250, 'XX001', 'CC004' , '4', 'CS027'),
('1953004', '8809061676337', N'Miến Khô Khoai Lang Nongshim Gói 1kg', 'mien-kho-khoai-lang-nongshim-goi-1kg.jpg', '01/11/2023', '02/11/2023', 79900, N'', 250, 'XX011', 'CC006' , '3', 'CS028'),
('2146970', '8934673701013', N'Sữa 9 Loại Hạt Vinamilk Super Nut Lốc 4 Hộp 180ml', 'sua-9-loai-hat-vinamilk-super-nut-loc-4-hop-180ml.jpg', '01/11/2023', '30/10/2023', 48200, N'', 50, 'XX001', 'CC001' , '12', 'CS034'),
('3465619', '3073781154351', N'Phô Mai Con Bò Cười Vị Truyền Thống 8 Miếng Hộp 112G', 'pho-mai-con-bo-cuoi-vi-truyen-thong-112g-hop-8-mieng-hop-122g.jpg', '01/11/2023', '16/04/2025', 36400, N'', 250, 'XX001', 'CC007' , '4', 'CS040')

--------------------- BẢNG KHUYẾN MÃI
SET DATEFORMAT DMY
INSERT INTO KHUYENMAI(MAKM, TENKM, NGAYBATDAU, NGAYKETTHUC, SOGIAM)
VALUES
('KM001', N'Giảm 15%', '17/11/2023', '17/12/2023', 15),
('KM002', N'Giảm 7%', '17/11/2023', '17/12/2023', 7)

--------------------- BẢNG CHI TIẾT KHUYẾN MÃI
INSERT INTO CHITIETKHUYENMAI(MAKM, MASP)
VALUES
('KM001', '1067407'),
('KM001', '1701673'),
('KM002', '2146970')


SELECT * from hoadon
SELECT * from chitiethoadon 
SELECT * from sanpham

delete chitiethoadon
delete hoadon
