create database Student
-- Create the table
use Student

-------------------------------StudentInfo table----------------------------
CREATE TABLE StudentInfo (
    StudentID VARCHAR(20) PRIMARY KEY,
    FullName VARCHAR(100),
    FatherName VARCHAR(100),
    Class VARCHAR(50)
);
	
drop table StudentInfo
---------------------------DUMMY Data---------------------
INSERT INTO StudentInfo (StudentID, FullName, FatherName, Class)
VALUES
('S-1001', 'Ali Baryar', 'Ahmed Baryar', '10th'),
('S-1002', 'Usman Rafiq', 'Rafiq Ahmed', '9th'),
('S-1003', 'Hassan Shah', 'Abdul Shah', '11th'),
('S-1004', 'Saad Khan', 'Imran Khan', '12th'),
('S-1005', 'Zain Abbas', 'Abbas Ali', '10th'),
('S-1006', 'Bilal Javed', 'Javed Iqbal', '9th'),
('S-1007', 'Mubashir Hussain', 'Hussain Shah', '11th'),
('S-1008', 'Faizan Tariq', 'Tariq Mehmood', '12th'),
('S-1009', 'Daniyal Rehman', 'Rehman Ali', '10th'),
('S-1010', 'Hamza Farooq', 'Farooq Ahmed', '9th');

----------------------------Fee Structure Table---------------------
CREATE TABLE FeeStructure (
    FeeID INT IDENTITY(1,1) PRIMARY KEY,
    Amount DECIMAL(10, 2)
);
drop table FeeStructure
-------------------------Transction History Table------------------------------
CREATE TABLE TransactionHistory (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID VARCHAR(20),
    FeeID INT,
    AmountPaid DECIMAL(10, 2),
    MonthName VARCHAR(20),
    IsPaid BIT,
    FOREIGN KEY (StudentID) REFERENCES StudentInfo(StudentID),
    FOREIGN KEY (FeeID) REFERENCES FeeStructure(FeeID)
);

drop table TransactionHistory

select * from TransactionHistory;

