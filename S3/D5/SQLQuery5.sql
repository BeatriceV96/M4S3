SELECT t.Descrizione, COUNT(*) AS ConteggioVerbali
FROM Verbale v
JOIN TipoViolazione t ON v.IdViolazione = t.IdViolazione
GROUP BY t.Descrizione;
