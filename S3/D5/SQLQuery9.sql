SELECT a.Cognome, a.Nome, SUM(v.Importo) AS TotaleImporto
FROM Verbale v
JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
GROUP BY a.Cognome, a.Nome;
