INSERT INTO Clients (codice_fiscale, cognome, nome, citta, provincia, email, telefono, cellulare)
VALUES ('RSSMRA85M01H501Z', 'Rossi', 'Mario', 'Roma', 'RM', 'mario.rossi@example.com', '065555555', '3395555555');


INSERT INTO Rooms (numero, descrizione, tipologia)
VALUES (101, 'Camera singola con vista mare', 'singola');

INSERT INTO Bookings (client_id, room_id, data_prenotazione, numero_progressivo, anno, periodo_dal, periodo_al, caparra, tariffa, dettaglio_soggiorno)
VALUES (1, 1, '2024-07-22', 1, 2024, '2024-08-01', '2024-08-07', 50.00, 350.00, 'pernottamento con prima colazione');

INSERT INTO Additional_Services (booking_id, data, descrizione, quantita, prezzo)
VALUES (1, '2024-08-02', 'Colazione in camera', 1, 15.00);
