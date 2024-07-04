DECLARE @TipoImpiego NVARCHAR(50) = 'Amministrativo'; 

SELECT i.* 
FROM Impiegati i
JOIN  Impieghi p ON i.IDImpiegato = p.IDImpiegato
WHERE p.TipoImpiego = @TipoImpiego;
