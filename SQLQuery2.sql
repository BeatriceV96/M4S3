SELECT p.* 
FROM Prenotazioni p 
JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale 
WHERE c.CodiceFiscale = 'RSSMRA85M01H501Z';

SELECT COUNT(*) AS TotalPrenotazioni 
FROM Prenotazioni 
WHERE Dettagli = 'pensione completa';

SELECT p.ID AS PrenotazioneID, c.Nome AS NomeCliente, c.Cognome AS CognomeCliente, ca.Numero AS NumeroCamera, 
       p.PeriodoDal, p.PeriodoAl, p.Tariffa, 
       ISNULL(SUM(sa.Prezzo * sa.Quantita), 0) AS TotaleServiziAggiuntivi, 
       (p.Tariffa - p.CaparraConfirmatoria + ISNULL(SUM(sa.Prezzo * sa.Quantita), 0)) AS ImportoDaSaldare 
FROM Prenotazioni p 
JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale 
JOIN Camere ca ON p.NumeroCamera = ca.Numero 
LEFT JOIN ServiziAggiuntivi sa ON p.ID = sa.IDPrenotazione 
WHERE p.ID = 1 
GROUP BY p.ID, c.Nome, c.Cognome, ca.Numero, p.PeriodoDal, p.PeriodoAl, p.Tariffa, p.CaparraConfirmatoria;

SELECT p.ID AS PrenotazioneID, c.Nome AS NomeCliente, c.Cognome AS CognomeCliente, ca.Numero AS NumeroCamera, 
       p.DataPrenotazione, p.PeriodoDal, p.PeriodoAl, p.Tariffa, p.Dettagli 
FROM Prenotazioni p 
JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale 
JOIN Camere ca ON p.NumeroCamera = ca.Numero;
