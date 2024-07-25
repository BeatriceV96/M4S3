$(document).ready(function () {
    // Funzione per ottenere le prenotazioni per codice fiscale
    $("#searchPrenotazioni").click(function () {
        var codiceFiscale = $("#codiceFiscale").val();
        $.get("/api/PrenotazioniApi/ByCodiceFiscale/" + codiceFiscale, function (data) {
            var rows = "";
            $.each(data, function (index, prenotazione) {
                rows += "<tr>" +
                    "<td>" + prenotazione.id + "</td>" +
                    "<td>" + prenotazione.codiceFiscaleCliente + "</td>" +
                    "<td>" + prenotazione.nomeCliente + "</td>" +
                    "<td>" + prenotazione.cognomeCliente + "</td>" +
                    "<td>" + prenotazione.numeroCamera + "</td>" +
                    "<td>" + new Date(prenotazione.dataPrenotazione).toLocaleDateString() + "</td>" +
                    "<td>" + prenotazione.numeroProgressivoAnno + "</td>" +
                    "<td>" + prenotazione.anno + "</td>" +
                    "<td>" + new Date(prenotazione.periodoDal).toLocaleDateString() + "</td>" +
                    "<td>" + new Date(prenotazione.periodoAl).toLocaleDateString() + "</td>" +
                    "<td>" + prenotazione.caparraConfirmatoria + "</td>" +
                    "<td>" + prenotazione.tariffa + "</td>" +
                    "<td>" + prenotazione.dettagli + "</td>" +
                    "</tr>";
            });
            $("#prenotazioniTable tbody").html(rows);
        });
    });

    // Funzione per ottenere il numero totale di prenotazioni per pensione completa
    $.get("/api/PrenotazioniApi/TotalPensioneCompleta", function (data) {
        $("#totalPensioneCompleta").text(data);
    });

    // Funzione per ottenere le ultime prenotazioni
    $.get("/api/PrenotazioniApi/LatestPrenotazioni?count=5", function (data) {
        var rows = "";
        $.each(data, function (index, prenotazione) {
            rows += "<tr>" +
                "<td>" + prenotazione.id + "</td>" +
                "<td>" + prenotazione.codiceFiscaleCliente + "</td>" +
                "<td>" + prenotazione.nomeCliente + "</td>" +
                "<td>" + prenotazione.cognomeCliente + "</td>" +
                "<td>" + prenotazione.numeroCamera + "</td>" +
                "<td>" + new Date(prenotazione.dataPrenotazione).toLocaleDateString() + "</td>" +
                "<td>" + prenotazione.numeroProgressivoAnno + "</td>" +
                "<td>" + prenotazione.anno + "</td>" +
                "<td>" + new Date(prenotazione.periodoDal).toLocaleDateString() + "</td>" +
                "<td>" + new Date(prenotazione.periodoAl).toLocaleDateString() + "</td>" +
                "<td>" + prenotazione.caparraConfirmatoria + "</td>" +
                "<td>" + prenotazione.tariffa + "</td>" +
                "<td>" + prenotazione.dettagli + "</td>" +
                "</tr>";
        });
        $("#latestPrenotazioniTable tbody").html(rows);
    });
});
