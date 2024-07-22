-- Cliente 1
INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare)
VALUES ('RSSMRA85M01H501Z', 'Rossi', 'Mario', 'Roma', 'RM', 'mario.rossi@example.com', '065555555', '3395555555');

-- Cliente 2
INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare)
VALUES ('VRDLGI85M01H501Y', 'Verdi', 'Luigi', 'Milano', 'MI', 'luigi.verdi@example.com', '027555555', '3485555555');

-- Cliente 3
INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare)
VALUES ('BNCLRA85M01H501X', 'Bianchi', 'Laura', 'Torino', 'TO', 'laura.bianchi@example.com', '011555555', '3475555555');

-- Cliente 4
INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare)
VALUES ('FRNGNE85M01H501W', 'Ferrari', 'Ginevra', 'Firenze', 'FI', 'ginevra.ferrari@example.com', '055555555', '3405555555');

INSERT INTO Camere (Numero, Descrizione, Tipologia)
VALUES (101, 'Camera singola con vista mare', 'singola');

INSERT INTO Prenotazioni (CodiceFiscaleCliente, NumeroCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, PeriodoDal, PeriodoAl, CaparraConfirmatoria, Tariffa, Dettagli)
VALUES ('RSSMRA85M01H501Z', 101, '2024-07-22', 1, 2024, '2024-08-01', '2024-08-07', 50.00, 350.00, 'pernottamento con prima colazione');

INSERT INTO ServiziAggiuntivi (IDPrenotazione, DataServizio, Descrizione, Quantita, Prezzo)
VALUES (1, '2024-08-02', 'Colazione in camera', 1, 15.00);

SELECT p.*
FROM Prenotazioni p
JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale
WHERE c.CodiceFiscale = 'RSSMRA85M01H501Z';

SELECT COUNT(*) AS TotalPrenotazioni
FROM Prenotazioni
WHERE Dettagli = 'pensione completa';

SELECT 
    p.ID AS PrenotazioneID,
    c.Nome AS NomeCliente,
    c.Cognome AS CognomeCliente,
    ca.Numero AS NumeroCamera,
    p.PeriodoDal,
    p.PeriodoAl,
    p.Tariffa,
    SUM(sa.Prezzo * sa.Quantita) AS TotaleServiziAggiuntivi,
    (p.Tariffa - p.CaparraConfirmatoria + SUM(sa.Prezzo * sa.Quantita)) AS ImportoDaSaldare
FROM Prenotazioni p
JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale
JOIN Camere ca ON p.NumeroCamera = ca.Numero
LEFT JOIN ServiziAggiuntivi sa ON p.ID = sa.IDPrenotazione
WHERE p.ID = 1
GROUP BY 
    p.ID, c.Nome, c.Cognome, ca.Numero, p.PeriodoDal, p.PeriodoAl, p.Tariffa, p.CaparraConfirmatoria;



SELECT 
    p.ID AS PrenotazioneID,
    c.Nome AS NomeCliente,
    c.Cognome AS CognomeCliente,
    ca.Numero AS NumeroCamera,
    p.DataPrenotazione,
    p.PeriodoDal,
    p.PeriodoAl,
    p.Tariffa,
    p.Dettagli
FROM Prenotazioni p
JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale
JOIN Camere ca ON p.NumeroCamera = ca.Numero;
