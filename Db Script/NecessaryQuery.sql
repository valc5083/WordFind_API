-- Create the database
CREATE DATABASE Data;

-- Use the created database
USE Data;

-- Create the Users table
CREATE TABLE Users (
    UserId NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(100) NOT NULL
);

-- Create the AuthTokens table
CREATE TABLE AuthTokenss (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Token NVARCHAR(100) NOT NULL,
    UserId NVARCHAR(50) FOREIGN KEY REFERENCES Users(UserId)
)

-- Commit changes
COMMIT;