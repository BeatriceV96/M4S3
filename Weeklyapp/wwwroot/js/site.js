$(document).ready(function () {
    // Funzione di login
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

    // Controlla l'autenticazione e mostra/nasconde gli elementi della navbar
    function checkAuth() {
        var token = localStorage.getItem('token');
        if (token) {
            $('.auth-required').show();
            $('.guest-only').hide();
        } else {
            $('.auth-required').hide();
            $('.guest-only').show();
        }
    }

    // Funzione di logout
    function logout() {
        localStorage.removeItem('token');
        $.post('/Account/Logout', function () {
            window.location.href = '/';
        });
    }

    // Funzione per ottenere le prenotazioni per codice fiscale
    function searchPrenotazioni() {
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
    }

    // Funzione per ottenere il numero totale di prenotazioni per pensione completa
    function getTotalPensioneCompleta() {
        $.get("/api/PrenotazioniApi/TotalPensioneCompleta", function (data) {
            $("#totalPensioneCompleta").text(data);
        });
    }

    // Funzione per ottenere le ultime prenotazioni
    function getLatestPrenotazioni() {
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
    }

    // Funzione per aggiungere un servizio aggiuntivo
    function addServizioAggiuntivo() {
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
                console.log("Importo da saldare: " + response.importoDaSaldare);
            },
            error: function (error) {
                console.error("Errore nell'aggiunta del servizio aggiuntivo", error);
                alert("Errore nell'aggiunta del servizio aggiuntivo");
            }
        });
    }

    // Gestione degli eventi
    $('#loginForm').on('submit', function (e) {
        e.preventDefault();
        login();
    });

    $('#logoutForm').on('submit', function (e) {
        e.preventDefault();
        logout();
    });

    $("#searchPrenotazioni").click(function () {
        searchPrenotazioni();
    });

    $("#servizio-aggiuntivo-form").submit(function (e) {
        e.preventDefault();
        addServizioAggiuntivo();
    });

    // Esegui queste funzioni al caricamento della pagina
    checkAuth();
    getTotalPensioneCompleta();
    getLatestPrenotazioni();
});
