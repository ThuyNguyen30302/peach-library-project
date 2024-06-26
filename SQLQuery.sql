-- Check for existing connections and terminate them
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PeachLibrary')
BEGIN
    DECLARE @DatabaseId INT = DB_ID('PeachLibrary');
    DECLARE @SQL NVARCHAR(MAX);

    -- Terminate all active connections to the database
    SET @SQL = N''
        + 'USE master; '
        + 'ALTER DATABASE PeachLibrary SET OFFLINE WITH ROLLBACK IMMEDIATE; '
        + 'ALTER DATABASE PeachLibrary SET ONLINE; '
        + 'DROP DATABASE PeachLibrary;';

    EXEC sp_executesql @SQL;
END
GO

-- Create PeachLibrary database
CREATE DATABASE PeachLibrary;
GO

use master
GO

USE PeachLibrary;
GO

-- Create Author table
CREATE TABLE Author (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Name NVARCHAR(255),
    NickName NVARCHAR(255),
    CreatedTime DATETIME DEFAULT GETDATE()
);
GO

-- Create Book table
CREATE TABLE Book (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Title NVARCHAR(128),
    Type NVARCHAR(255),
    Price DECIMAL(18, 2),
    CreatedTime DATETIME DEFAULT GETDATE()
);
GO

-- Create BookAuthorMapping table
CREATE TABLE BookAuthorMapping (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    AuthorId UNIQUEIDENTIFIER,
    BookId UNIQUEIDENTIFIER,
    FOREIGN KEY (AuthorId) REFERENCES Author(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookId) REFERENCES Book(Id) ON DELETE CASCADE
);
GO

-- Create Publisher table
CREATE TABLE Publisher (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Name NVARCHAR(255),
    Code NVARCHAR(255),
    CreatedTime DATETIME DEFAULT GETDATE()
);
GO

-- Create BookCopy table
CREATE TABLE BookCopy (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    YearPublisher DATETIME,
    BookId UNIQUEIDENTIFIER,
    PublisherId UNIQUEIDENTIFIER,
    FOREIGN KEY (BookId) REFERENCES Book(Id) ON DELETE CASCADE,
    FOREIGN KEY (PublisherId) REFERENCES Publisher(Id) ON DELETE CASCADE
);
GO

-- Create Member table
CREATE TABLE Member (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    CardNumber NVARCHAR(255),
    Name NVARCHAR(255),
    Email NVARCHAR(255),
    UserName NVARCHAR(255),
    Password NVARCHAR(255),
    Status NVARCHAR(255),
    Age INT,
    Address NVARCHAR(255),
    CreatedTime DATETIME DEFAULT GETDATE()
);
GO

-- Create CheckOut table
CREATE TABLE CheckOut (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    StartTime DATETIME,
    EndTime DATETIME,
    IsReturned BIT,
    MemberId UNIQUEIDENTIFIER,
    BookCopyId UNIQUEIDENTIFIER,
    CreatedTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MemberId) REFERENCES Member(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookCopyId) REFERENCES BookCopy(Id) ON DELETE CASCADE
);
GO

-- Create Hold table
CREATE TABLE Hold (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    StartTime DATETIME,
    EndTime DATETIME,
    MemberId UNIQUEIDENTIFIER,
    BookCopyId UNIQUEIDENTIFIER,
    CreatedTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MemberId) REFERENCES Member(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookCopyId) REFERENCES BookCopy(Id) ON DELETE CASCADE
);
GO

-- Create MetaCatalo table
CREATE TABLE MetaCatalo (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Name NVARCHAR(255),
    Code NVARCHAR(255),
    Description NVARCHAR(255),
    CreatedTime DATETIME DEFAULT GETDATE()
);
GO

-- Create Catalo table
CREATE TABLE Catalo (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Name NVARCHAR(255),
    Code NVARCHAR(255),
    DisplayIndex NVARCHAR(255),
    MetaCataloCode NVARCHAR(255),
    MetaCataloId UNIQUEIDENTIFIER,
    FOREIGN KEY (MetaCataloId) REFERENCES MetaCatalo(Id) ON DELETE CASCADE
);
GO

-- Create Notification table
CREATE TABLE Notification (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Type NVARCHAR(255),
    SendAt DATETIME,
    MemberId UNIQUEIDENTIFIER,
    FOREIGN KEY (MemberId) REFERENCES Member(Id)
);
GO

-- Create WaitingList table
CREATE TABLE WaitingList (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    MemberId UNIQUEIDENTIFIER,
    BookId UNIQUEIDENTIFIER,
    CreatedTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MemberId) REFERENCES Member(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookId) REFERENCES Book(Id) ON DELETE CASCADE
);
GO

-- Set up relationships
ALTER TABLE Book ADD CONSTRAINT FK_Book_BookAuthorMappings FOREIGN KEY (Id) REFERENCES BookAuthorMapping(BookId) ON DELETE CASCADE;
ALTER TABLE Book ADD CONSTRAINT FK_Book_BookCopys FOREIGN KEY (Id) REFERENCES BookCopy(BookId) ON DELETE CASCADE;
ALTER TABLE Book ADD CONSTRAINT FK_Book_WaitingLists FOREIGN KEY (Id) REFERENCES WaitingList(BookId) ON DELETE CASCADE;
ALTER TABLE Author ADD CONSTRAINT FK_Author_BookAuthorMappings FOREIGN KEY (Id) REFERENCES BookAuthorMapping(AuthorId) ON DELETE CASCADE;
ALTER TABLE Publisher ADD CONSTRAINT FK_Publisher_BookCopys FOREIGN KEY (Id) REFERENCES BookCopy(PublisherId) ON DELETE CASCADE;
ALTER TABLE Member ADD CONSTRAINT FK_Member_Holds FOREIGN KEY (Id) REFERENCES Hold(MemberId) ON DELETE CASCADE;
ALTER TABLE Member ADD CONSTRAINT FK_Member_CheckOuts FOREIGN KEY (Id) REFERENCES CheckOut(MemberId) ON DELETE CASCADE;
ALTER TABLE Member ADD CONSTRAINT FK_Member_WaitingLists FOREIGN KEY (Id) REFERENCES WaitingList(MemberId) ON DELETE CASCADE;
ALTER TABLE MetaCatalo ADD CONSTRAINT FK_MetaCatalo_Catalos FOREIGN KEY (Id) REFERENCES Catalo(MetaCataloId) ON DELETE CASCADE;

