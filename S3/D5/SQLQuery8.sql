SELECT a.Cognome, a.Nome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Verbale v
JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
WHERE v.DataViolazione BETWEEN '2009-02-01' AND '2009-07-31';
