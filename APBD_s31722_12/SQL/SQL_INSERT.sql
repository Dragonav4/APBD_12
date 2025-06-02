INSERT INTO Client (FirstName, LastName, Email, Telephone, Pesel)
VALUES
    ('John', 'Doe', 'john.doe@example.com', '123456789', '99010112345'),
    ('Jane', 'Smith', 'jane.smith@example.com', '987654321', '98020254321');

INSERT INTO Country (Name)
VALUES
    ('Poland'),
    ('Germany'),
    ('France');

INSERT INTO Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES
    ('European Tour', 'Visit several European countries', '2025-07-01', '2025-07-15', 20),
    ('Ski Trip Alps', 'Skiing in the Alps', '2025-12-10', '2025-12-20', 15);

INSERT INTO Country_Trip (IdCountry, IdTrip)
VALUES
    (1, 1), 
    (2, 1), 
    (3, 1), 
    (3, 2); 

INSERT INTO Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES
    (1, 1, GETDATE(), '2025-06-01'),
    (2, 2, GETDATE(), NULL);