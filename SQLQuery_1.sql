use Teatru
-- Tabela Spectacol
CREATE TABLE Spectacol (
    spectacolId INT PRIMARY KEY,
    nume VARCHAR(50),
    data DATE,
    ora TIME,
    numarLocuri INT
);

CREATE TABLE TipLoc (
    tipLocId INT PRIMARY KEY,
    nume VARCHAR(50),
    pret DECIMAL(10, 2)
);

-- Tabela Loc
CREATE TABLE Loc (
    locId INT PRIMARY KEY,
    tipLocId INT,
    stare VARCHAR(10),
    spectacolId INT,
    FOREIGN KEY (spectacolId) REFERENCES Spectacol(spectacolId),
    FOREIGN KEY (tipLocId) REFERENCES TipLoc(tipLocId)
);

-- Tabela Utilizator
CREATE TABLE Utilizator (
    userId INT PRIMARY KEY,
    nume VARCHAR(100),
    prenume VARCHAR(100),
    email VARCHAR(100),
    parola VARCHAR(100)
);

-- Tabela Rezervare
CREATE TABLE Rezervare (
    rezervareId INT PRIMARY KEY,
    userId INT,
    spectacolId INT,
    FOREIGN KEY (userId) REFERENCES Utilizator(userId),
    FOREIGN KEY (spectacolId) REFERENCES Spectacol(spectacolId)
);

-- Tabela RezervareLoc
CREATE TABLE RezervareLoc (
    rezervareId INT,
    locId INT,
    FOREIGN KEY (rezervareId) REFERENCES Rezervare(rezervareId),
    FOREIGN KEY (locId) REFERENCES Loc(locId),
    PRIMARY KEY (rezervareId, locId)
);

CREATE TABLE Sala (
    salaId INT PRIMARY KEY,
    nume VARCHAR(50),
    numarLocuri INT
);

INSERT INTO Spectacol (spectacolId, nume, data, ora, numarLocuri) 
VALUES 
(1, 'Spectacol1', '2024-04-15', '19:00', 100),
(2, 'Spectacol2', '2024-04-20', '18:30', 80),
(3, 'Spectacol3', '2024-05-10', '20:00', 120),
(4, 'Spectacol4', '2024-05-15', '17:00', 150),
(5, 'Spectacol5', '2024-05-25', '21:00', 90);

INSERT INTO Loc (locId, tipLocId, stare) 
VALUES 
(1, 1, 'liber'),
(2, 2, 'liber'),
(3, 3, 'liber'),
(4, 1, 'liber'),
(5, 2, 'liber'),
(6, 3, 'liber'),
(7, 1, 'ocupat'),
(8, 2, 'ocupat'),
(9, 3, 'liber'),
(10, 1, 'liber');


INSERT INTO TipLoc (tipLocId, nume, pret) 
VALUES 
(1, 'Normal', 50),
(2, 'VIP', 100),
(3, 'Premium', 150),
(4, 'Balcony', 60),
(5, 'Front row', 110),
(6, 'Back row', 160),
(7, 'Box seating', 50),
(8, 'Loge seating', 100),
(9, 'Upper circle', 150),
(10, 'Lower circle', 70);

INSERT INTO Utilizator (userId, nume, email) 
VALUES 
(1, 'John Doe', 'john.doe@example.com'),
(2, 'Jane Smith', 'jane.smith@example.com'),
(3, 'Alice Johnson', 'alice.johnson@example.com'),
(4, 'Bob Brown', 'bob.brown@example.com'),
(5, 'Emma Davis', 'emma.davis@example.com'),
(6, 'Michael Wilson', 'michael.wilson@example.com'),
(7, 'Olivia Martinez', 'olivia.martinez@example.com'),
(8, 'William Taylor', 'william.taylor@example.com'),
(9, 'Sophia Anderson', 'sophia.anderson@example.com'),
(10, 'James Thomas', 'james.thomas@example.com');

INSERT INTO Rezervare (rezervareId, userId, spectacolId) 
VALUES 
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5)

INSERT INTO RezervareLoc (rezervareId, locId)
VALUES
    (1, 1), (1, 2),
    (2, 3), (2, 4), 
    (3, 5), (3, 6),
    (4, 7), (4, 8),
    (5, 9), (5, 10);

SELECT
    Utilizator.userId,
    Utilizator.prenume,
    Utilizator.nume,
    Utilizator.email,
    Spectacol.spectacolId,
    Spectacol.nume AS spectacolNume,
    Rezervare.rezervareId,
    RezervareLoc.locId
FROM
    Utilizator
JOIN Rezervare ON Utilizator.userId = Rezervare.userId
JOIN Spectacol ON Rezervare.spectacolId = Spectacol.spectacolId
JOIN RezervareLoc ON Rezervare.rezervareId = RezervareLoc.rezervareId
WHERE
    Utilizator.userId = 2;