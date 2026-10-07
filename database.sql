CREATE DATABASE BookManagementDB;
GO
USE BookManagementDB;
GO

CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(150) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    PublishedYear INT NOT NULL,
    ImagePath NVARCHAR(300) NULL
);
GO

INSERT INTO Books (Title, Author, Category, Price, PublishedYear) VALUES
(N'Đắc Nhân Tâm', N'Dale Carnegie', N'Kỹ năng sống', 89000, 1936),
(N'Tuổi Trẻ Đáng Giá Bao Nhiêu', N'Rosie Nguyễn', N'Phát triển bản thân', 85000, 2016),
(N'Lập Trình C# Cơ Bản', N'Nguyễn Văn A', N'Công nghệ thông tin', 120000, 2024),
(N'Clean Code', N'Robert C. Martin', N'Lập trình', 250000, 2008),
(N'Nhà Giả Kim', N'Paulo Coelho', N'Tiểu thuyết', 79000, 1988);
GO
