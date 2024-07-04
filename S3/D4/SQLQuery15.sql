SELECT i.* 
FROM Impiegati i
JOIN Impieghi p ON i.IdImpiegato = p.IdImpiegato
WHERE p.Assunzione BETWEEN '2007-01-01' AND '2008-01-01';
