SELECT OrderID, SUM(UnitPrice * Quantity) AS TotalPrice FROM [Order Details] GROUP BY OrderID;
