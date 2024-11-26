-- Insert dummy data for the Company table.
INSERT INTO "Company" ("CompanyName", "CompanyInfo")
VALUES ('Tech Innovators Inc.', 'A leading technology company specializing in software development.');

-- Insert dummy data for the Department table.
INSERT INTO "Department" ("DepartmentName")
VALUES ('Engineering'),
       ('Human Resources'),
       ('Sales'),
       ('Marketing'),
       ('Customer Support');

-- Insert dummy data for the Position table.
INSERT INTO "Position" ("PositionName", "Salary")
VALUES ('Software Engineer', 70000.00),
       ('HR Manager', 60000.00),
       ('Sales Representative', 50000.00),
       ('Marketing Specialist', 55000.00),
       ('Customer Support Agent', 40000.00),
       ('Team Lead', 80000.00);

-- Insert dummy data for the Address table.
INSERT INTO "Address" ("Country", "City", "Street", "PostalCode")
VALUES ('USA', 'New York', '123 Tech Street', '10001'),
       ('USA', 'Los Angeles', '456 Innovation Drive', '90001'),
       ('USA', 'San Francisco', '789 Startup Lane', '94101'),
       ('USA', 'Austin', '101 Silicon Valley', '73301'),
       ('USA', 'Seattle', '202 Cloud Ave', '98101');

-- Insert dummy data for the Employee table.
INSERT INTO "Employee" ("FirstName", "LastName", "Patronymic", "BirthDate", "HireDate", "PhoneNumber", "Bonuses",
                        "PositionId",
                        "DepartmentId", "AddressId", "CompanyId")
VALUES
-- Software Engineers
('John', 'Doe', 'Alex', '1985-01-01', '2010-02-15', '555-0100', 5000.00, 1, 1, 1, 1),
('Jane', 'Smith', 'Marie', '1987-03-12', '2012-06-30', '555-0101', 5500.00, 1, 1, 2, 1),
('Richard', 'Roe', 'Edward', '1990-08-22', '2014-09-01', '555-0102', 5200.00, 1, 1, 3, 1),
('Emily', 'Clark', 'Anne', '1992-11-05', '2016-11-21', '555-0103', 5300.00, 1, 1, 4, 1),
('Michael', 'Johnson', 'James', '1995-04-18', '2018-02-14', '555-0104', 5400.00, 1, 1, 5, 1),

-- HR Managers
('Alice', 'Brown', 'Nicole', '1983-07-19', '2008-03-10', '555-0200', 4000.00, 2, 2, 1, 1),
('Robert', 'Williams', 'David', '1986-10-24', '2011-05-22', '555-0201', 4100.00, 2, 2, 2, 1),

-- Sales Representatives
('James', 'Miller', 'Chris', '1984-02-14', '2009-08-15', '555-0300', 3000.00, 3, 3, 3, 1),
('Linda', 'Davis', 'Sarah', '1993-12-01', '2015-01-30', '555-0301', 3200.00, 3, 3, 4, 1),
('Kevin', 'Martinez', 'Peter', '1988-06-23', '2010-07-05', '555-0302', 3100.00, 3, 3, 5, 1),

-- Marketing Specialists
('Barbara', 'Garcia', 'Caren', '1990-05-19', '2013-02-25', '555-0400', 3500.00, 4, 4, 1, 1),
('Thomas', 'Hernandez', 'Albert', '1994-09-07', '2017-04-17', '555-0401', 3600.00, 4, 4, 2, 1),
('Anna', 'Lopez', 'Mary', '1996-12-31', '2018-09-22', '555-0402', 3700.00, 4, 4, 3, 1),
('Brian', 'Wilson', 'John', '1982-03-11', '2007-06-13', '555-0403', 3800.00, 4, 4, 4, 1),

-- Customer Support Agents
('David', 'Gonzalez', 'Michael', '1991-08-15', '2014-11-11', '555-0500', 2000.00, 5, 5, 5, 1),
('Susan', 'Perez', 'Emma', '1995-10-21', '2018-03-08', '555-0501', 2100.00, 5, 5, 1, 1),
('Nancy', 'Hill', 'Rebecca', '1992-11-30', '2015-06-29', '555-0502', 2200.00, 5, 5, 2, 1),
('Steven', 'Moore', 'George', '1989-04-05', '2012-08-04', '555-0503', 2300.00, 5, 5, 3, 1),
('Deborah', 'Taylor', 'Jennifer', '1997-01-17', '2019-12-15', '555-0504', 2400.00, 5, 5, 4, 1),

-- Team Leads
('Catherine', 'White', 'Diana', '1978-07-22', '2005-04-15', '555-0600', 6000.00, 6, 1, 1, 1),
('Paul', 'Harris', 'Joseph', '1982-12-25', '2008-09-30', '555-0601', 6100.00, 6, 2, 2, 1),
('Laura', 'Martin', 'Gary', '1985-05-10', '2010-06-11', '555-0602', 6200.00, 6, 3, 3, 1),
('Daniel', 'Thompson', 'Edward', '1986-01-25', '2011-08-13', '555-0603', 6300.00, 6, 4, 4, 1),
('Carol', 'Martinez', 'Sophia', '1989-09-07', '2014-10-14', '555-0604', 6400.00, 6, 5, 5, 1);