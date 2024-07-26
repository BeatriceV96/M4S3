$(document).ready(function () {
    function login() {
        var model = {
            Username: $('#Username').val(),
            Password: $('#Password').val()
        };

        $.ajax({
            url: '/Account/Login',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (response) {
                localStorage.setItem('token', response.token);
                window.location.href = '/';
            },
            error: function (xhr, status, error) {
                alert('Login non valido');
            }
        });
    }

    function checkAuth() {
        var token = localStorage.getItem('token');
        if (token) {
            // Logica per verificare il token e mostrare le opzioni di menu corrette
            $('.auth-required').show();
            $('.guest-only').hide();
        } else {
            $('.auth-required').hide();
            $('.guest-only').show();
        }
    }

    $('#loginForm').on('submit', function (e) {
        e.preventDefault();
        login();
    });

    $('#logoutForm').on('submit', function (e) {
        e.preventDefault();
        localStorage.removeItem('token');
        $.post('/Account/Logout', function () {
            window.location.href = '/';
        });
    });

    checkAuth();
});

// Codice per la ricerca delle prenotazioni
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
