SELECT COUNT(*) AS ConteggioVerbali FROM Verbale;

SELECT a.Cognome, a.Nome, COUNT(*) AS ConteggioVerbali
FROM Verbale v
JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
GROUP BY a.Cognome, a.Nome;

