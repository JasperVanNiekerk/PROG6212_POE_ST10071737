-- Create the Student table with an auto-incrementing primary key
CREATE TABLE Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(255),
    StudentSurname NVARCHAR(255),
    StudentPassword NVARCHAR(255)
);

-- Create the Semester table with an auto-incrementing primary key
CREATE TABLE Semester (
    SemesterID INT IDENTITY(1,1) PRIMARY KEY,
    SemesterNum INT,
    SemesterStartDate DATE,
    SemesterWeeksAmount INT,
    StudentID INT,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID)
);

-- Create the Module table with an auto-incrementing primary key
CREATE TABLE Module (
    ModuleID INT IDENTITY(1,1) PRIMARY KEY,
    ModuleCode NVARCHAR(255),
    ModuleName NVARCHAR(255),
    ModuleCredits INT,
    ModuleClassHoursPerWeek DECIMAL(5, 2),
    ModuleStartDate DATE,
    ModuleTotalWeeks INT,
    ModuleTotalSSHours DECIMAL(8, 2),
    ModuleSSHoursDoneForWeek DECIMAL(8, 2),
    ModuleSSHoursForWeeks DECIMAL(8, 2),
    ModuleTotalSSHoursDone DECIMAL(8, 2),
    SemesterID INT,
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID)
);