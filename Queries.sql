IF (DB_ID('Sandbox') IS NULL)
	CREATE DATABASE Sandbox;

GO
USE Sandbox;

DROP TABLE IF EXISTS ProductsCategories;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Categories;

CREATE TABLE Categories (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	CategoryName NVARCHAR(30) NOT NULL
);

CREATE TABLE Products (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	ProductName NVARCHAR(100) NOT NULL
);

CREATE TABLE ProductsCategories (
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO Categories
VALUES
('Мясо'),
('Рыба'),
('Молочные продукты'),
('Овощи и фрукты'),
('Бакалея');

INSERT INTO Products
VALUES
('Куриное филе'),
('Чипсы'),
('Сливки'),
('Жареный арахис'),
('Капуста'),
('Окунь'),
('Шницель'),
('Помидор'),
('Сухарики'),
('Камбала'),
('Свинина'),
('Мороженое'),
('Рёбрышки'),
('Сметана'),
('Компьютер');

INSERT INTO ProductsCategories
VALUES
(1, 1),
(2, 5),
(3, 3),
(4, 5),
(5, 4),
(6, 2),
(7, 1),
(8, 4),
(9, 5),
(10, 2),
(11, 1),
(12, 3),
(13, 1),
(14, 3);

SELECT Products.ProductName AS ProductName, ISNULL(Categories.CategoryName, '') AS CategoryName FROM Products
LEFT JOIN ProductsCategories ON Products.Id = ProductsCategories.ProductId
LEFT JOIN Categories ON Categories.Id = ProductsCategories.CategoryId
ORDER BY Products.ProductName;