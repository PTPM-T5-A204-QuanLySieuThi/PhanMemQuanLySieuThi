CREATE DATABASE DB_VIECLAM
GO

USE DB_VIECLAM
GO

--------------------------------------------------- [ KHỞI TẠO CÁC BẢNG DỮ LIỆU ] ---------------------------------------------------
--------------------- QUYỀN TRUY CẬP
CREATE TABLE QUYENTRUYCAP
(
	MAQUYEN	INT NOT NULL IDENTITY(1, 1),	
	TENQUYEN	NVARCHAR(40),
	CONSTRAINT PK_QUYENTRUYCAP PRIMARY KEY(MAQUYEN)
);

--------------------- TÀI KHOẢN
CREATE TABLE TAIKHOAN
(
	MATK		INT NOT NULL IDENTITY(1, 1),	
	MAIL		VARCHAR(50),
	MATKHAU		VARCHAR(20),
	MAQUYEN		INT,
	CONSTRAINT PK_TAIKHOAN PRIMARY KEY(MATK)
);

--------------------- BẢNG CÔNG VIỆC
CREATE TABLE CONGVIEC
(
	MACV		INT NOT NULL IDENTITY(1, 1),
	TENCV		NVARCHAR(50),
	MOTA		NVARCHAR(100),	
	YEUCAU		NVARCHAR(50),
	MUCLUONG	DECIMAL(18,0),
	DIADIEM		NVARCHAR(50),
	THOIGIAN	DATE,
	CONSTRAINT PK_CONGVIEC PRIMARY KEY(MACV)
);

--------------------------------------------------------- HỒ SƠ CHI TIẾT ỨNG VIÊN
--------------------- BẢNG ỨNG VIÊN
CREATE TABLE UNGVIEN
(
	MAUV		INT NOT NULL IDENTITY(1, 1),
	HOTEN		NVARCHAR(50),
	ANHDAIDIEN	VARCHAR(100),
	EMAIL		VARCHAR(50),	
	NGAYSINH	DATE,
	TINH		NVARCHAR(20),
	DIACHI		NVARCHAR(100),
	GIOITINH	NVARCHAR(5),
	SDT			VARCHAR(10),
	CONSTRAINT PK_UNGVIEN PRIMARY KEY(MAUV)
);

--------------------- BẢNG THÔNG TIN CHUNG ỨNG VIÊN
CREATE TABLE THONGTINCHUNGUNGVIEN
(
	MAUV				INT NOT NULL,
	VITRIMONGMUON		NVARCHAR(100),
	NGHENGHIEP			NVARCHAR(50),
	CAPBACHIENTAI		NVARCHAR(50),
	CAPBACMONGMUON		NVARCHAR(50),
	MUCLUONGMONGMUON	DECIMAL(18, 0),
	HOCVAN				NVARCHAR(50),
	NAMKINHNGHIEP		NVARCHAR(50),
	DIADIEMLAMVIEC		NVARCHAR(100),
	HINHTHUCLAMVIEC		NVARCHAR(150),
	MUCTIEUNGHENGHIEP	NVARCHAR(150),
	CONSTRAINT PK_THONGTINCHUNGUNGVIEN PRIMARY KEY(MAUV)
);

--------------------- BẢNG KINH NGHIỆP LÀM VIỆC CỦA ỨNG VIÊN
CREATE TABLE KINHNGHIEPLAMVIEC
(
	MAUV			INT NOT NULL,
	CHUCDANH		NVARCHAR(50),
	TENCONGTY		NVARCHAR(50),
	TRANGTHAI		BIT,
	THANGBATDAU		INT,
	NAMBATDAU		INT,
	THANGKETTHUC	INT,
	NAMKETTHUC		INT,
	MOTA			NVARCHAR(100),
	CONSTRAINT PK_KINHNGHIEPLAMVIEC PRIMARY KEY(MAUV)
);

--------------------- BẢNG TRÌNH ĐỘ HỌC VẤN CỦA ỨNG VIÊN
CREATE TABLE THONGTINHOCVAN
(
	MAUV			INT NOT NULL,
	TENTRUONG		NVARCHAR(50),
	CHUYENNGANH		NVARCHAR(50),
	TENBANGCAP		NVARCHAR(150),
	THANGBATDAU		INT,
	NAMBATDAU		INT,
	THANGKETTHUC	INT,
	NAMKETTHUC		INT,
	CONSTRAINT PK_THONGTINHOCVAN PRIMARY KEY(MAUV)
);

--------------------- BẢNG NGOẠI NGỮ
CREATE TABLE NGOAINGU
(
	MANN				INT NOT NULL,
	TENNGOAINGU			NVARCHAR(50),
	MUCDOTHANHTHAO		NVARCHAR(50),
	CONSTRAINT PK_NGOAINGU PRIMARY KEY(MANN)
);

--------------------- BẢNG CHI TIẾT NGOẠI NGỮ
CREATE TABLE CHITIETNGOAINGU
(
	MAUV			INT NOT NULL,
	MANN			INT,
	CONSTRAINT PK_CHITIETNGOAINGU PRIMARY KEY(MAUV)
);

--------------------------------------------------------- HỒ SƠ CHI TIẾT NHÀ TUYỂN DỤNG
--------------------- BẢNG NHÀ TUYỂN DỤNG
CREATE TABLE NHATUYENDUNG
(
	MATD			INT NOT NULL IDENTITY(1, 1),
	ANHDAIDIEN		VARCHAR(100),
	HOTEN			NVARCHAR(50),
	EMAIL			VARCHAR(50),	
	SDT				VARCHAR(10),
	DIACHILIENHE	NVARCHAR(50),
	CONSTRAINT PK_NHATUYENDUNG PRIMARY KEY(MATD)
);

--------------------- BẢNG THÔNG TIN CÔNG TY
CREATE TABLE THONGTINCONGTY
(
	MATD		INT NOT NULL,
	MATHUE		VARCHAR(15),
	TENCONGTY	NVARCHAR(50),
	QUYMONHANSU	NVARCHAR(30),
	DIADIEM		NVARCHAR(15),
	DIACHI		NVARCHAR(50),
	SDTCODINH	VARCHAR(10),
	LINHVUC		NVARCHAR(50),
	CONSTRAINT PK_THONGTINCONGTY PRIMARY KEY(MATD)
);

--------------------- BẢNG HỒ SƠ TUYỂN DỤNG
CREATE TABLE HOSOTUYENDUNG
(
	MAHSTD		INT NOT NULL IDENTITY(1, 1),
	MACV		INT,
	TENHS		NVARCHAR(50),	
	MOTA		NVARCHAR(50),
	CONSTRAINT PK_HOSOTUYENDUNG PRIMARY KEY(MAHSTD)
);

--------------------------------------------------- [ RÀNG BUỘC ] ---------------------------------------------------

--------------------------------------------------------- KHÓA NGOẠI

--------------------- BẢNG TÀI KHOẢN
ALTER TABLE TAIKHOAN 
ADD CONSTRAINT FK_TAIKHOAN_QUYENTRUYCAP FOREIGN KEY(MAQUYEN) REFERENCES QUYENTRUYCAP(MAQUYEN)

--------------------- BẢNG THÔNG TIN CHUNG ỨNG VIÊN
ALTER TABLE THONGTINCHUNGUNGVIEN 
ADD CONSTRAINT FK_THONGTINCHUNGUNGVIEN_UNGVIEN FOREIGN KEY(MAUV) REFERENCES UNGVIEN(MAUV)

--------------------- BẢNG KINH NGHIỆP LÀM VIỆC CỦA ỨNG VIÊN
ALTER TABLE KINHNGHIEPLAMVIEC 
ADD CONSTRAINT FK_KINHNGHIEPLAMVIEC_UNGVIEN FOREIGN KEY(MAUV) REFERENCES UNGVIEN(MAUV)

--------------------- BẢNG TRÌNH ĐỘ HỌC VẤN CỦA ỨNG VIÊN
ALTER TABLE THONGTINHOCVAN 
ADD CONSTRAINT FK_THONGTINHOCVAN_UNGVIEN FOREIGN KEY(MAUV) REFERENCES UNGVIEN(MAUV)

--------------------- BẢNG CHI TIẾT NGOẠI NGỮ
ALTER TABLE CHITIETNGOAINGU 
ADD CONSTRAINT FK_CHITIETNGOAINGU_UNGVIEN FOREIGN KEY(MAUV) REFERENCES UNGVIEN(MAUV),
	CONSTRAINT FK_CHITIETNGOAINGU_NGOAINGU FOREIGN KEY(MANN) REFERENCES NGOAINGU(MANN)

--------------------- BẢNG THÔNG TIN CÔNG TY
ALTER TABLE THONGTINCONGTY 
ADD CONSTRAINT FK_THONGTINCONGTY_NHATUYENDUNG FOREIGN KEY(MATD) REFERENCES NHATUYENDUNG(MATD)

--------------------- BẢNG HỒ SƠ TUYỂN DỤNG
ALTER TABLE HOSOTUYENDUNG 
ADD CONSTRAINT FK_HOSOTUYENDUNG_CONGVIEC FOREIGN KEY(MACV) REFERENCES CONGVIEC(MACV)