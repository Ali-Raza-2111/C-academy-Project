create database Student
-- Create the table
use Student

-------------------------------StudentInfo table----------------------------
CREATE TABLE StudentInfo (
    StudentID VARCHAR(20) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    Class VARCHAR(50) NOT NULL,
    StudentGroup VARCHAR(50)  -- Added column (e.g., "Science", "Arts", etc.)
);
	
drop table StudentInfo
---------------------------DUMMY Data---------------------
INSERT INTO StudentInfo (StudentID, FullName, FatherName, Class, StudentGroup)
VALUES
('S-1002', 'Usman Rafiq', 'Rafiq Ahmed', '9th', 'Bio'),
('S-1006', 'Bilal Javed', 'Javed Iqbal', '9th', 'Comp'),
('S-1010', 'Hamza Farooq', 'Farooq Ahmed', '9th', 'Bio'),
('S-1001', 'Ali Baryar', 'Ahmed Baryar', '10th', 'Comp'),
('S-1005', 'Zain Abbas', 'Abbas Ali', '10th', 'Bio'),
('S-1009', 'Daniyal Rehman', 'Rehman Ali', '10th', 'Comp'),
('S-1003', 'Hassan Shah', 'Abdul Shah', '11th', 'Medical'),
('S-1007', 'Mubashir Hussain', 'Hussain Shah', '11th', 'Non-Medical'),
('S-1004', 'Saad Khan', 'Imran Khan', '12th', 'ICS'),
('S-1008', 'Faizan Tariq', 'Tariq Mehmood', '12th', 'Medical');

----------------------------Fee Structure Table---------------------
CREATE TABLE FeeStructure (
    FeeID INT IDENTITY(1,1) PRIMARY KEY,
    Amount DECIMAL(10, 2)
);

drop table FeeStructure
-------------------------Transction History Table------------------------------
CREATE TABLE TransactionHistory (
    TransactionID       INT       IDENTITY(1,1) PRIMARY KEY,
    StudentID           VARCHAR(20) NOT NULL,
    FeeID               INT         NOT NULL,
    AmountPaid          DECIMAL(10,2) NOT NULL,
    MonthName           VARCHAR(20)  NOT NULL,
    IsPaid              BIT          NOT NULL,
    ConcessionPercent   DECIMAL(5,2) NOT NULL,
    PaymentDate         DATE        NOT NULL
        CONSTRAINT DF_TransactionHistory_PaymentDate 
        DEFAULT CAST(GETDATE() AS DATE),
    FOREIGN KEY (StudentID) REFERENCES StudentInfo(StudentID),
    FOREIGN KEY (FeeID)     REFERENCES FeeStructure(FeeID)
);



CREATE TABLE MonthlyFeeSummary (
    SummaryID INT IDENTITY(1,1) PRIMARY KEY,
    MonthName VARCHAR(20) NOT NULL,
    AcademyShareTotal DECIMAL(18,2) NOT NULL,
    TeacherShareTotal DECIMAL(18,2) NOT NULL,
    BiologyTotal DECIMAL(18,2) NOT NULL,
    CompTotal DECIMAL(18,2) NOT NULL,
    MathTotal DECIMAL(18,2) NOT NULL,
    ChemistryTotal DECIMAL(18,2) NOT NULL,
    PhysicsTotal DECIMAL(18,2) NOT NULL,
    EnglishTotal DECIMAL(18,2) NOT NULL,
    IS_PSTotal DECIMAL(18,2) NOT NULL,
    TQTotal DECIMAL(18,2) NOT NULL
);
select * from MonthlyFeeSummary
