create database BookStoreDataBase

use BookStoreDataBase

-----create table for user----

create table UsersRegistration(
UserId int identity(1,1)not null primary key,
FullName varchar(max) not null,
Email varchar(max) not null,
Password varchar(max) not null,
MobileNumber varchar(20) not null
);


select * from UsersRegistration
-----creating store procedure for user table----

create or alter Proc spRegisterUser
(
    @FullName Varchar(Max),
    @Email varchar(Max),
    @Password varchar(Max),
    @MobileNumber varchar(30) 
)
as
begin
        Insert Into UsersRegistration (FullName, Email, Password, MobileNumber)
        Values (@FullName, @Email, @Password, @MobileNumber);
        
End;

------User Login Stored Procedure-------

