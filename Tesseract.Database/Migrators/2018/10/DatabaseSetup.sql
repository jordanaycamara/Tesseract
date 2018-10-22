CREATE TABLE Company.Employee
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_EmployeeId] PRIMARY KEY DEFAULT NEWID(),
    [FirstName] VARCHAR(100) NOT NULL,
    [LastName] VARCHAR(100) NOT NULL
)

CREATE TABLE Company.[Dependent]
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_DependentId] PRIMARY KEY DEFAULT NEWID(),
    [FirstName] VARCHAR(100) NOT NULL,
    [LastName] VARCHAR(100) NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER CONSTRAINT [FK_Dependent_EmployeeId] FOREIGN KEY REFERENCES Company.Employee(Id)
)

CREATE TABLE Finances.BenefitType
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
)

INSERT INTO Finances.BenefitType ([Name])

VALUES ('Employee Benefit'), ('Dependent Benefit'), ('Employee Compensation')

CREATE TABLE Finances.Benefit
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_BenefitId] PRIMARY KEY DEFAULT NEWID(),
    BenefitTypeId INT CONSTRAINT [FK_Benefit_BenefitTypeId] FOREIGN KEY REFERENCES Finances.BenefitType(Id),
    Amount MONEY NOT NULL
)

INSERT INTO Finances.Benefit (BenefitTypeId, Amount)
VALUES (1, 1000), (2, 500), (3, 2000);

CREATE TABLE Finances.DiscountType
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
)

INSERT INTO Finances.DiscountType ([Name])
VALUES ('A-Team')

CREATE TABLE Finances.Discount
(
    Id UNIQUEIDENTIFIER CONSTRAINT [PK_DiscountId] PRIMARY KEY DEFAULT NEWID(),
    DiscountTypeId INT CONSTRAINT [FK_Discount_DiscountTypeId] FOREIGN KEY REFERENCES Finances.DiscountType(Id),
    [Percentage] DECIMAL(9, 2) NULL,
    [Amount] MONEY NULL
)

INSERT INTO Finances.Discount (DiscountTypeId, [Percentage], Amount)
VALUES (1, 0.10, NULL)