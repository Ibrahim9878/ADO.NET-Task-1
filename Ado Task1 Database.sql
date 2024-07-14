CREATE DATABASE DBUsers


USE DBUsers


CREATE TABLE Users

(

Id int NOT NULL PRIMARY KEY IDENTITY(1,1),

[Name] nvarchar(50) NOT NULL,

Surname nvarchar(50) NOT NULL,

Age int NOT NULL,

[Login] nvarchar(30) NOT NULL,

[Password] nvarchar(30) NOT NULL

)