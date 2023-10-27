CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    StudentName NVARCHAR(255),
    StudentSurname NVARCHAR(255),
    StudentPassword NVARCHAR(255)
);

-- Create the Semester table
CREATE TABLE Semester (
    SemesterID INT PRIMARY KEY,
    SemesterNum INT,
    SemesterStartDate DATE,
    SemesterWeeksAmount INT,
    StudentID INT,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID)
);

-- Create the Module table
CREATE TABLE Module (
    ModuleID INT PRIMARY KEY,
    ModuleCode NVARCHAR(255),
    ModuleName NVARCHAR(255),
    ModuleCredits INT,
    ModuleClassHoursPerWeek DECIMAL(5, 2),
    ModuleStartDate DATE,
    ModuleTotalWeeks INT,
    SemesterID INT,
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID)
);