-- Create a new database called '[UserProjects]'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'[UserProjects]'
)

CREATE DATABASE [UserProjects]
GO

USE [UserProjects];
GO
-- Create a new table called '[User]' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL
DROP TABLE dbo.[User]
GO
-- Create the table in the specified schema
CREATE TABLE dbo.[User]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY  , -- primary key column
    FirstName [NVARCHAR](50) NOT NULL,
    LastName [NVARCHAR](50) NOT NULL
    
);
GO

-- Create a new table called 'Project' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Project', 'U') IS NOT NULL
DROP TABLE dbo.Project
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Project
(
    Id INT  IDENTITY(1,1) NOT NULL PRIMARY KEY, -- primary key column
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Credits INT NOT NULL
    
);
GO

-- Create a new table called 'UserProject' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.UserProject', 'U') IS NOT NULL
DROP TABLE dbo.UserProject
GO
-- Create the table in the specified schema
CREATE TABLE dbo.UserProject
(
    UserId       INT NOT NULL,
    ProjectId    INT NOT NULL,
    IsActive     BIT NOT NULL,
    AssignedDate DATETIME NOT NULL,
    CONSTRAINT FK_UserProject_User FOREIGN KEY (UserId) references [User] (Id),
    CONSTRAINT FK_UserProject_Project FOREIGN KEY (ProjectId) references [Project] (Id),
    PRIMARY KEY(UserId, ProjectId)
);
GO