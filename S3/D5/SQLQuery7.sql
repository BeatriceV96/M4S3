SELECT a.Cognome, a.Nome, v.DataViolazione, v.IndirizzoViolazione, v.Importo, v.DecurtamentoPunti
FROM Verbale v
JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
WHERE a.Citta = 'Palermo';
