SELECT a.Cognome, a.Nome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Verbale v
JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
WHERE v.DecurtamentoPunti > 5;
