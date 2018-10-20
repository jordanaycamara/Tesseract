DROP DATABASE tesseract;

CREATE LOGIN TesseractUser WITH PASSWORD = 'Yolo$wag'

CREATE DATABASE tesseract;
GO
USE tesseract;

EXEC('CREATE SCHEMA Company');

CREATE TABLE Company.Employee
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_EmployeeId] PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    [FirstName] VARCHAR(100) NOT NULL,
    [LastName] VARCHAR(100) NOT NULL
)

CREATE TABLE Company.[Dependent]
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_DependentId] PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    [FirstName] VARCHAR(100) NOT NULL,
    [LastName] VARCHAR(100) NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER CONSTRAINT [FK_Dependent_EmployeeId] FOREIGN KEY REFERENCES Company.Employee(Id)
)

EXEC('CREATE SCHEMA Finances');

CREATE TABLE Finances.DeductionType
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
)

INSERT INTO Finances.DeductionType ([Name])

VALUES ('Employee Benefit'), ('Dependent Benefit')

CREATE TABLE Finances.Deduction
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_DeductionId] PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    DeductionTypeId INT CONSTRAINT [FK_Deduction_DeductionTypeId] FOREIGN KEY REFERENCES Finances.DeductionType(Id),
    Amount MONEY NOT NULL
)

INSERT INTO Finances.Deduction (DeductionTypeId, Amount)
VALUES (1, 1000), (2, 500);

CREATE TABLE Finances.DiscountType
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
)

INSERT INTO Finances.DiscountType ([Name])
VALUES ('A-Team')

CREATE TABLE Finances.Discount
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_DiscountId] PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    DiscountTypeId INT CONSTRAINT [FK_Discount_DiscountTypeId] FOREIGN KEY REFERENCES Finances.DiscountType(Id),
    [Percentage] DECIMAL(9, 2) NULL,
    [Amount] MONEY NULL
)

INSERT INTO Finances.Discount (DiscountTypeId, [Percentage], Amount)
VALUES (1, 0.10, NULL)