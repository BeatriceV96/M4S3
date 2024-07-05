SELECT Nominativo_Agente, COUNT(*) AS ConteggioViolazioni
FROM Verbale
GROUP BY Nominativo_Agente;
