
Create Database [SWD_392_Project1]
GO

USE [SWD_392_Project1]
GO

GO
-- Tạo bảng Roles
CREATE TABLE Roles (
    role_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) UNIQUE NOT NULL
);

GO
-- Tạo bảng Categories
CREATE TABLE Categories (
    category_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(250) UNIQUE NOT NULL
);
GO
-- Tạo bảng States 
CREATE TABLE States (
    state_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(250) UNIQUE NOT NULL
);
GO
-- Tạo bảng Accounts
CREATE TABLE Accounts (
    account_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    user_name NVARCHAR(250) UNIQUE NOT NULL,
    password NVARCHAR(250) NOT NULL,
    email NVARCHAR(250) UNIQUE NOT NULL,
    full_name NVARCHAR(250) NULL,
    phone NVARCHAR(11) NULL,
    address NVARCHAR(50) NULL,
    role_id BIGINT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES Roles(role_id)
);
GO
-- Tạo bảng Events
CREATE TABLE Events (
    event_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(250) NOT NULL,
    description NVARCHAR(250) NULL,
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
    location NVARCHAR(250) NULL,
    category_id BIGINT NOT NULL,
    account_id BIGINT NOT NULL,
    state_id BIGINT NULL,
    FOREIGN KEY (category_id) REFERENCES Categories(category_id),
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id),
    FOREIGN KEY (state_id) REFERENCES States(state_id)
);
GO
-- Tạo bảng Connections
CREATE TABLE Connections (
    account_id BIGINT NOT NULL,
    event_id BIGINT NOT NULL,
    join_or_care BIT NOT NULL,
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id),
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);
GO
-- Tạo bảng EventDetails
CREATE TABLE EventDetails (
    detail_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    event_id BIGINT NOT NULL,
    image NVARCHAR(250) NULL,
    agenda NVARCHAR(250) NULL,
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);
GO
-- Tạo bảng Comments
CREATE TABLE Comments (
    comment_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    content NVARCHAR(250) NOT NULL,
    account_id BIGINT NOT NULL,
    event_id BIGINT NOT NULL,
    created_at DATETIME NOT NULL,
    delete_or_update BIT NOT NULL,
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id),
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);
GO
-- Tạo bảng Sponsors
CREATE TABLE Sponsors (
    sponsor_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(250) NOT NULL,
    infor_sponsor NVARCHAR(250) NULL,
    unit_sponsor NVARCHAR(250) NULL,
    event_id BIGINT NOT NULL,
    amount DECIMAL NULL,
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);


INSERT INTO Roles (name)
VALUES ('Admin');
INSERT INTO Roles (name)
VALUES ('User');
GO
INSERT INTO Categories (name)
VALUES ('Sports');

INSERT INTO Categories (name)
VALUES ('Music');

INSERT INTO Categories (name)
VALUES ('Art');
GO

INSERT INTO Accounts (user_name, password, email, full_name, phone, address, role_id)
VALUES
    ('admin', '123', 'admin@example.com', 'Admin User', '1234567890', 'Admin Address', 1);

INSERT INTO Accounts (user_name, password, email, full_name, phone, address, role_id)
VALUES
    ('user1', '123', 'user1@example.com', 'User 1', '9876543210', 'User 1 Address', 2);

INSERT INTO Accounts (user_name, password, email, full_name, phone, address, role_id)
VALUES
    ('user2', '123', 'user2@example.com', 'User 2', '5678901234', 'User 2 Address', 2);
GO
INSERT INTO States (name)
VALUES
    ('Xác nhận');
INSERT INTO States (name)
VALUES
    ('Chờ xác nhận');
INSERT INTO States (name)
VALUES
    ('Huỷ');

INSERT INTO States (name)
VALUES
    ('Kết thúc');
INSERT INTO States (name)
VALUES
    ('Cấm');
GO
INSERT INTO Events (name, description, start_date, end_date, location, category_id, account_id, state_id)
VALUES
    ('Event 1', 'Description for Event 1', '2023-11-01 10:00:00', '2023-11-01 15:00:00', 'Location 1', 1, 1, 1);

INSERT INTO Events (name, description, start_date, end_date, location, category_id, account_id, state_id)
VALUES
    ('Event 2', 'Description for Event 2', '2023-11-02 11:00:00', '2023-11-02 16:00:00', 'Location 2', 2, 1, 2);

INSERT INTO Events (name, description, start_date, end_date, location, category_id, account_id, state_id)
VALUES
    ('Event 3', 'Description for Event 3', '2023-11-03 09:00:00', '2023-11-03 14:00:00', 'Location 3', 3, 2, 1);

GO
INSERT INTO Connections (account_id, event_id, join_or_care)
VALUES (2, 1, 1);
INSERT INTO Connections (account_id, event_id, join_or_care)
VALUES (3, 1, 0);
INSERT INTO Connections (account_id, event_id, join_or_care)
VALUES (2, 2, 1);


GO
INSERT INTO EventDetails (event_id, image, agenda)
VALUES
    (1, 'nhan-vien-to-chuc-su-kien', 'Agenda for Event 1');

INSERT INTO EventDetails (event_id, image, agenda)
VALUES
    (2, 'nhan-vien-to-chuc-su-kien', 'Agenda for Event 2');

INSERT INTO EventDetails (event_id, image, agenda)
VALUES
    (3, 'nhan-vien-to-chuc-su-kien', 'Agenda for Event 3');

GO
INSERT INTO Comments (content, account_id, event_id, created_at, delete_or_update)
VALUES
    ('Comment 1 for Event 1', 2, 1, '2023-11-01 12:00:00', 0);
INSERT INTO Comments (content, account_id, event_id, created_at, delete_or_update)
VALUES
    ('Comment 2 for Event 1', 3, 1, '2023-11-01 13:00:00', 0);
INSERT INTO Comments (content, account_id, event_id, created_at, delete_or_update)
VALUES
    ('Comment 1 for Event 2', 2, 2, '2023-11-02 12:00:00', 0);

GO
INSERT INTO Sponsors (name, infor_sponsor, unit_sponsor, event_id, amount)
VALUES
    ('Sponsor 1', 'Information for Sponsor 1', 'Unit 1', 1, 1000.00);

INSERT INTO Sponsors (name, infor_sponsor, unit_sponsor, event_id, amount)
VALUES
    ('Sponsor 2', 'Information for Sponsor 2', 'Unit 2', 2, 1500.00);

INSERT INTO Sponsors (name, infor_sponsor, unit_sponsor, event_id, amount)
VALUES
    ('Sponsor 3', 'Information for Sponsor 3', 'Unit 3', 3, 2000.00);

