USE [UserProjects];
GO

-- exec sp_help '[User]';
-- exec sp_help '[Project]';
-- exec sp_help '[UserProject]';

-- Insert rows into table '[User]'
INSERT INTO [User]
( 
    -- columns to insert data into
    [FirstName], [LastName]
)
VALUES
(     
    'Goku', 'Kakaroto'
),
( 
    'Vegeta','Vegeta'
),
( 
    'Son','Gohan'
),
( 
    'Picoro','Daimaku'
),
( 
    'Ten Shin','Han'
),
( 
    'Kame','Sennin'
),
( 
    'Majin','Boo'
),
( 
    'Kid','Boo'
)

GO

-- Insert rows into table 'Project'
INSERT INTO Project
( -- columns to insert data into
 [StartDate], [EndDate], [Credits]
)
VALUES
( -- first row: values for the columns in the list above
 '1922-02-06 00:00:00.000', '1982-04-09 00:00:00.000', 1
),
( 
 '1982-04-09 00:00:00.000', '2028-08-28 00:00:00.000', 2
),
(
    '1944-09-28 00:00:00.000','1965-12-26 00:00:00.000',3
)

GO

-- Insert rows into table 'UserProject'
INSERT INTO UserProject
( -- columns to insert data into
 [UserId], [ProjectId], [IsActive],[AssignedDate]
)
VALUES
( 
    1, 1, 1, '2028-08-28 00:00:00.000'
),
( 
    2, 1, 1, '2028-08-28 00:00:00.000'
)
