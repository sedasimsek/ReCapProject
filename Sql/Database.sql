CREATE TABLE Cars(
	CarId int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (BrandId) REFERENCES Colors(ColorId),
	FOREIGN KEY (ColorId) REFERENCES Brands(BrandId)
)

CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

CREATE TABLE Brands(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)


INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','2','2012','100','Manuel Benzin'),
	('1','3','2015','150','Otomatik Dizel'),
	('2','1','2017','200','Otomatik Hybrid'),
	('3','3','2014','125','Manuel Dizel');

INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Mavi');


INSERT INTO Brands(BrandName)
VALUES
	('Mercedes'),
	('BMW'),
	('Renault');