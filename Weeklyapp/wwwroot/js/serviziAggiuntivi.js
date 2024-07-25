$(document).ready(function () {
    $("#servizio-aggiuntivo-form").submit(function (e) {
        e.preventDefault();

        let formData = {
            IDPrenotazione: $("#IDPrenotazione").val(),
            Descrizione: $("#Descrizione").val(),
            Quantita: $("#Quantita").val(),
            Prezzo: $("#Prezzo").val()
        };

        $.ajax({
            url: '/api/ServiziAggiuntiviApi/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                alert("Servizio aggiuntivo aggiunto con successo!");
                // Aggiorna il totale del checkout se necessario
                console.log("Importo da saldare: " + response.importoDaSaldare);
            },
            error: function (error) {
                console.error("Errore nell'aggiunta del servizio aggiuntivo", error);
                alert("Errore nell'aggiunta del servizio aggiuntivo");
            }
        });
    });
});
