-- Tạo cơ sở dữ liệu
CREATE DATABASE quanlythuvien;
go
-- Sử dụng cơ sở dữ liệu mới tạo
USE quanlythuvien;
go
-- Tạo bảng Nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNhaXuatBan INT PRIMARY KEY,
    TenNhaXuatBan NVARCHAR(255)
);

-- Tạo bảng Tác giả
CREATE TABLE TacGia (
    MaTacGia INT PRIMARY KEY,
    TenTacGia NVARCHAR(255)
);

-- Tạo bảng Người dùng
CREATE TABLE NguoiDung (
    TenDangNhap NVARCHAR(255) PRIMARY KEY,
    MatKhau NVARCHAR(255),
    LoaiNguoiDung NVARCHAR(255)
);

-- Tạo bảng Độc giả
CREATE TABLE DocGia (
    MaDocGia INT  PRIMARY KEY,
    TenDocGia NVARCHAR(255),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(255),
    LopHoc NVARCHAR(255),
    NgayTaoThe DATE,
    MaNhanVienTaoThe INT,
    TenDangNhap NVarChar(255),
    FOREIGN KEY (MaNhanVienTaoThe) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (TenDangNhap) REFERENCES NguoiDung(TenDangNhap)
);

-- Tạo bảng Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    TenNhanVien NVARCHAR(255),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SoDienThoai NVARCHAR(20),
    TenDangNhap NVarChar(255),
    FOREIGN KEY (TenDangNhap) REFERENCES NguoiDung(TenDangNhap)
);

-- Tạo bảng Sách
CREATE TABLE Sach (
    MaSach INT PRIMARY KEY,
    TenSach NVARCHAR(255),
    LoaiSach NVARCHAR(255),
    MaTacGia INT,
    MaNhaXuatBan INT,
    NgayXuatBan DATE,
    SoLuong INT,
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia),
    FOREIGN KEY (MaNhaXuatBan) REFERENCES NhaXuatBan(MaNhaXuatBan)
);

-- Tạo bảng Phiếu mượn
CREATE TABLE PhieuMuon (
    MaPhieuMuon INT PRIMARY KEY,
    MaNhanVienLapPhieu INT,
    NgayLapPhieu DATE,
    MaDocGia INT,
    FOREIGN KEY (MaNhanVienLapPhieu) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia)
);


-- Tạo bảng Chi tiết phiếu mượn
CREATE TABLE ChiTietPhieuMuon (
    MaPhieuMuon INT,
    MaSach INT,
    TinhTrang BIT,
    NgayTraSach DATE,
    TienPhat INT,
    MaNhanVienNhanSachTra INT,
    FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach),
    FOREIGN KEY (MaNhanVienNhanSachTra) REFERENCES NhanVien(MaNhanVien)
);










-- Chèn dữ liệu vào bảng NhaXuatBan
INSERT INTO NhaXuatBan (MaNhaXuatBan, TenNhaXuatBan)
VALUES
(1, 'NXB Kim Đồng'),
(2, 'NXB Trẻ'),
(3, 'NXB Hồng Đức'),
(4, 'NXB Quân Đội'),
(5, 'NXB Thanh Niên'),
(6, 'NXB Thông Tấn'),
(7, 'NXB Y Học'),
(8, 'NXB Phụ Nữ'),
(9, 'NXB Văn Học'),
(10, 'NXB Giáo Dục');

-- Sửa kí tự unicode
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Kim Đồng' WHERE MaNhaXuatBan = 1;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Trẻ' WHERE MaNhaXuatBan = 2;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Hồng Đức' WHERE MaNhaXuatBan = 3;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Quân Đội' WHERE MaNhaXuatBan = 4;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Thanh Niên' WHERE MaNhaXuatBan = 5;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Thông Tấn' WHERE MaNhaXuatBan = 6;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Y Học' WHERE MaNhaXuatBan = 7;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Phụ Nữ' WHERE MaNhaXuatBan = 8;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Văn Học' WHERE MaNhaXuatBan = 9;
UPDATE NhaXuatBan
SET TenNhaXuatBan = N'NXB Giáo Dục' WHERE MaNhaXuatBan = 10;











-- Chèn dữ liệu vào bảng TacGia
INSERT INTO TacGia (MaTacGia, TenTacGia)
VALUES
(1, 'Ngô Xuân Tiến'),
(2, 'Lý Y Điền'),
(3, 'Cao Đình Thiều'),
(4, 'Đinh Văn Trác'),
(5, 'Vũ Quốc Cường'),
(6, 'Lê Bảo Uyên'),
(7, 'Trịnh Thanh Thảo'),
(8, 'Sùng A Bá'),
(9, 'Đỗ Thế Văn'),
(10, 'Ngỗ Tuyết Quỳnh');

-- Sửa kí tự unicode
UPDATE TacGia
SET TenTacGia = N'Ngô Xuân Tiến' WHERE MaTacGia = 1;
UPDATE TacGia
SET TenTacGia = N'Lý Y Điền' WHERE MaTacGia = 2;
UPDATE TacGia
SET TenTacGia = N'Cao Đình Thiều' WHERE MaTacGia = 3;
UPDATE TacGia
SET TenTacGia = N'Đinh Văn Trác' WHERE MaTacGia = 4;
UPDATE TacGia
SET TenTacGia = N'Vũ Quốc Cường' WHERE MaTacGia = 5;
UPDATE TacGia
SET TenTacGia = N'Lê Bảo Uyên' WHERE MaTacGia = 6;
UPDATE TacGia
SET TenTacGia = N'Trịnh Thanh Thảo' WHERE MaTacGia = 7;
UPDATE TacGia
SET TenTacGia = N'Sùng A Bá' WHERE MaTacGia = 8;
UPDATE TacGia
SET TenTacGia = N'Đỗ Thế Văn' WHERE MaTacGia = 9;
UPDATE TacGia
SET TenTacGia = N'Ngỗ Tuyết Quỳnh' WHERE MaTacGia = 10;













-- Chèn dữ liệu vào bảng NguoiDung


-- xóa bảng NguoiDung
DELETE FROM NguoiDung;

INSERT INTO NguoiDung (TenDangNhap, MatKhau, LoaiNguoiDung)
VALUES
(N'phunghuy', N'Huy195', N'Quản Lý'),
(N'truongmyduyen', N'Duyen224', N'Quản Lý'),
(N'lananh', N'Lananh1610', N'Quản Lý'),
(N'truongthuan', N'Thuan236', N'Quản Lý'),
(N'anhminh', N'Minh123', N'Quản Lý'),



(N'thuyduong', N'Duong123', N'Độc Giả'),
(N'vanquyet', N'Quyet123', N'Độc Giả'),
(N'giathanh', N'Thanh123', N'Độc Giả'),
(N'thanhcong', N'Cong123', N'Độc Giả'),
(N'minhtam', N'Tam123', N'Độc Giả'),
(N'minhphat', N'Phat123', N'Độc Giả'),
(N'conghieu', N'Hieu123', N'Độc Giả'),
(N'baongoc', N'Ngoc123', N'Độc Giả'),
(N'tuanvinh', N'Vinh123', N'Độc Giả'),
(N'anhvan', N'Van123', N'Độc Giả'),



(N'quocbao', N'Bao123', N'Thủ Thư'),
(N'thegiang', N'Giang123', N'Thủ Thư'),
(N'anhtam', N'Tam123', N'Thủ Thư'),
(N'tuananh', N'Anh123', N'Thủ Thư'),
(N'lephuong', N'Phuong123', N'Thủ Thư'),
(N'minhduc', N'Duc123', N'Thủ Thư'),
(N'quoccuong', N'Cuong123', N'Thủ Thư'),
(N'haiduong', N'Duong123', N'Thủ Thư'),
(N'dinhgiang', N'Giang123', N'Thủ Thư'),
(N'thanhlong', N'Long123', N'Thủ Thư');













-- Chèn dữ liệu vào bảng DocGia


--Xóa bảng DocGia
DELETE FROM DocGia;

INSERT INTO DocGia (MaDocGia, TenDocGia, NgaySinh, GioiTinh, DiaChi, LopHoc, NgayTaoThe, MaNhanVienTaoThe, TenDangNhap)
VALUES
(1, N'Lê Thụy Dương', '2002-01-19', N'Nữ', N'Hải Dương', N'Tin14A11', '2021-10-01', 1, N'thuyduong'),
(2, N'Trịnh Văn Quyết', '2002-04-22', N'Nam', N'Thanh Hóa', N'Tin14A11', '2023-10-02', 2, N'vanquyet'),
(3, N'Vương Gia Thành', '2002-10-16', N'Nam', N'Bắc Giang', N'Tin14A11', '2022-10-03', 3, N'giathanh'),
(4, N'Nguyễn Thành Công', '2002-06-23', N'Nam', N'Bắc Giang', N'Tin14A11', '2023-10-04', 4, N'thanhcong'),
(5, N'Dương Minh Tâm', '2002-09-20', N'Nữ', N'Bắc Ninh', N'Tin14A11', '2023-10-05', 5, N'minhtam'),
(6, N'Lý Minh Phát', '2002-12-05', N'Nam', N'Quảng Ninh', N'Tin14A1', '2023-05-05', 6, N'minhphat'),
(7, N'Huỳnh Công Hiếu', '2002-07-25', N'Nam', N'Hà Nội', N'Tin14A12', '2023-07-18', 7, N'conghieu'),
(8, N'Trịnh Bảo Ngọc', '2002-04-18', N'Nữ', N'Nam Định', N'Tin14A2', '2023-02-28', 8, N'baongoc'),
(9, N'Nguyễn Tuấn Vinh', '2002-08-12', N'Nam', N'Hưng Yên', N'Tin14A2', '2022-10-05', 9, N'tuanvinh'),
(10, N'Lê Anh Vân', '2002-11-27', N'Nữ', N'Hải Phòng', N'Tin14A4', '2023-01-05', 10, N'anhvan');










-- Chèn dữ liệu vào bảng NhanVien



--xóa bảng NhanVien
DELETE FROM NhanVien;

INSERT INTO NhanVien (MaNhanVien, TenNhanVien, NgaySinh, GioiTinh, SoDienThoai, TenDangNhap)
VALUES
(1, N'Châu Quốc Bảo', '1990-05-15', N'Nam', '1234567890', 'quocbao'),
(2, N'Thế Giang', '1995-08-25', N'Nam', '9876543210', 'thegiang'),
(3, N'Nguyễn Anh Tâm', '1988-11-05', N'Nam', '1231231234', 'anhtam'),
(4, N'Nguyễn Tuấn Anh', '1992-02-10', N'Nam', '4567891230', 'tuananh'),
(5, N'Lê Phương', '1997-03-20', N'Nữ', '7890123456', 'lephuong'),
(6, N'Minh Đức', '1985-06-05', N'Nữ', '3456789012', 'minhduc'),
(7, N'Quốc Cường', '1998-09-25', N'Nam', '2345678901', 'quoccuong'),
(8, N'Lê Hải Dương', '1994-12-18', N'Nữ', '9012345678', 'haiduong'),
(9, N'Vũ Đình Giang', '1993-03-12', N'Nam', '6789012345', 'dinhgiang'),
(10, N'Nguyễn Thành Long', '1996-06-27', N'Nam', '1234567890', 'thanhlong');















-- Chèn dữ liệu vào bảng Sach

--Xoa bang Sach
DELETE FROM Sach;
INSERT INTO Sach (MaSach, TenSach, LoaiSach, MaTacGia, MaNhaXuatBan, NgayXuatBan, SoLuong)
VALUES
(1, N'Núi và Rừng', N'Hồi Kí và Tự Truyện', 1, 1, '2022-01-15', 100),
(2, N'Thơ Ấu', N'Hồi Kí và Tự Truyện', 2, 2, '2021-05-20', 150),
(3, N'Nam Châm', N'Truyền Cảm Hứng', 3, 3, '2023-03-10', 120),
(4, N'Hạnh Phúc', N'Tình Cảm', 4, 4, '2020-11-28', 80),
(5, N'Chuyến Tàu', N'Truyền Cảm Hứng', 5, 5, '2022-09-14', 90),
(6, N'Biển Cả', N'Truyện Ngắn', 6, 6, '2022-04-30', 110),
(7, N'Đôi Chân', N'Hồi Kí và Tự Truyện', 7, 7, '2023-08-02', 70),
(8, N'Tìm Lại Khát Vọng', N'Truyền Cảm Hứng', 8, 8, '2021-12-05', 130),
(9, N'Tình', N'Tình Cảm', 9, 9, '2023-02-19', 105),
(10, N'10 Năm Một Hành Trình', N'Truyền Cảm Hứng', 10, 10, '2022-07-11', 95);















-- Chèn dữ liệu vào bảng PhieuMuon
INSERT INTO PhieuMuon (MaPhieuMuon, MaNhanVienLapPhieu, NgayLapPhieu, MaDocGia)
VALUES
(1, 1, '2023-09-20', 1),
(2, 2, '2023-05-21', 2),
(3, 3, '2023-05-28', 3),
(4, 4, '2023-04-22', 4),
(5, 5, '2023-02-24', 5),
(6, 6, '2023-09-08', 6),
(7, 7, '2023-07-26', 7),
(8, 8, '2023-09-27', 8),
(9, 9, '2023-10-28', 9),
(10, 10, '2023-10-29', 10);


--Xóa bảng PhieuMuon
DELETE FROM PhieuMuon;









-- Chèn dữ liệu vào bảng ChiTietPhieuMuon

INSERT INTO ChiTietPhieuMuon (MaPhieuMuon, MaSach, TinhTrang, NgayTraSach, TienPhat, MaNhanVienNhanSachTra)
VALUES
(1, 1, 1, '2023-10-09', 0, 1),
(2, 2, 1, '2023-06-06', 0, 1),
(3, 3, 1, '2023-06-07', 0, 2),
(4, 4, 1, '2023-05-08', 0, 2),
(5, 4, 0, '2023-01-01', 0, 1), 
(6, 2, 0, '2023-01-01', 0, 1),
(7, 7, 1, '2023-08-09', 0, 3),
(8, 8, 0, '2023-01-01', 0, 2),
(9, 9, 1, '2023-11-10', 0, 4), 
(10, 10, 0, '2023-01-01', 0, 3);

--Xóa bảng ChiTietPhieuMuon
DELETE FROM ChiTietPhieuMuon;

