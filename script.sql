CREATE TABLE [dbo].State (
  [id]    INT IDENTITY(1,1) NOT NULL,
  [name]  VARCHAR(150) DEFAULT NULL,
  PRIMARY KEY (id)
);

--
-- Zrzut danych tabeli
--

INSERT INTO [dbo].State ([name]) VALUES
('Dolnoœl¹skie'),
('Kujawsko-Pomorskie'),
('Ma³opolskie'),
('Warmiñsko-Mazurskie'),
('Podlaskie'),
('Lubelskie'),
('Œwiêtokrzyskie'),
('Mazowieckie'),
('Œl¹skie'),
('Podkarpackie'),
('Opolskie'),
('Wielkopolskie'),
('Lubuskie'),
('£ódzkie'),
('Pomorskie'),
('Zachodniopomorskie');


