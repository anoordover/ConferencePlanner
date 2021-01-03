IF NOT EXISTS(SELECT *
              FROM sys.databases
              WHERE name = 'BackEnd')
    BEGIN
        CREATE DATABASE BackEnd;
    END;
GO

use BackEnd
GO

IF NOT EXISTS(SELECT principal_id
              FROM sys.server_principals
              WHERE name = 'myUsername')
    BEGIN
        /* Syntax for SQL server login.  See BOL for domain logins, etc. */
        CREATE LOGIN myUsername
            WITH PASSWORD = 'zWPYAjHbH3W7k#'
    END

if not exists(select *
              from sys.database_principals
              where name = 'myUsername')
    begin
        CREATE USER myUsername FOR LOGIN myUsername;
        GRANT ALTER ON SCHEMA::dbo TO myUsername;
        GRANT SELECT, UPDATE, DELETE, INSERT ON SCHEMA::dbo TO myUsername;
        GRANT CREATE TABLE TO myUsername as dbo;
    end;
GO

GRANT SELECT, UPDATE, DELETE, INSERT, REFERENCES ON SCHEMA::dbo TO myUsername;
