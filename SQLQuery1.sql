-- Inserimento Clienti
INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) 
VALUES 
('RSSMRA85M01H501Z', 'Rossi', 'Mario', 'Roma', 'RM', 'mario.rossi@example.com', '065555555', '3395555555'),
('VRDLGI85M01H501Y', 'Verdi', 'Luigi', 'Milano', 'MI', 'luigi.verdi@example.com', '027555555', '3485555555'),
('BNCLRA85M01H501X', 'Bianchi', 'Laura', 'Torino', 'TO', 'laura.bianchi@example.com', '011555555', '3475555555'),
('FRNGNE85M01H501W', 'Ferrari', 'Ginevra', 'Firenze', 'FI', 'ginevra.ferrari@example.com', '055555555', '3405555555');

-- Inserimento Camere
INSERT INTO Camere (Numero, Descrizione, Tipologia) 
VALUES 
(101, 'Camera singola con vista mare', 'singola'),
(102, 'Camera doppia con vista giardino', 'doppia'),
(103, 'Camera singola con vista città', 'singola'),
(104, 'Camera doppia con vista mare', 'doppia');

-- Inserimento Prenotazioni
INSERT INTO Prenotazioni (CodiceFiscaleCliente, NumeroCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, PeriodoDal, PeriodoAl, CaparraConfirmatoria, Tariffa, Dettagli) 
VALUES 
('RSSMRA85M01H501Z', 101, '2024-07-22', 1, 2024, '2024-08-01', '2024-08-07', 50.00, 350.00, 'pernottamento con prima colazione'),
('VRDLGI85M01H501Y', 102, '2024-07-23', 2, 2024, '2024-08-05', '2024-08-10', 100.00, 500.00, 'pensione completa'),
('BNCLRA85M01H501X', 103, '2024-07-24', 3, 2024, '2024-08-10', '2024-08-15', 75.00, 375.00, 'mezza pensione'),
('FRNGNE85M01H501W', 104, '2024-07-25', 4, 2024, '2024-08-15', '2024-08-20', 150.00, 600.00, 'pernottamento con prima colazione');

-- Inserimento Servizi Aggiuntivi
INSERT INTO ServiziAggiuntivi (IDPrenotazione, DataServizio, Descrizione, Quantita, Prezzo) 
VALUES 
(1, '2024-08-02', 'Colazione in camera', 1, 15.00),
(2, '2024-08-06', 'Bevande dal minibar', 2, 10.00),
(3, '2024-08-11', 'Internet', 1, 5.00),
(4, '2024-08-16', 'Letto aggiuntivo', 1, 20.00);
