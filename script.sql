CREATE TABLE [dbo].State (
  [id]    INT IDENTITY(1,1) NOT NULL,
  [name]  VARCHAR(150) DEFAULT NULL,
  PRIMARY KEY (id)
);

--
-- Zrzut danych tabeli
--

INSERT INTO [dbo].State ([name]) VALUES
('Dolno�l�skie'),
('Kujawsko-Pomorskie'),
('Ma�opolskie'),
('Warmi�sko-Mazurskie'),
('Podlaskie'),
('Lubelskie'),
('�wi�tokrzyskie'),
('Mazowieckie'),
('�l�skie'),
('Podkarpackie'),
('Opolskie'),
('Wielkopolskie'),
('Lubuskie'),
('��dzkie'),
('Pomorskie'),
('Zachodniopomorskie');


