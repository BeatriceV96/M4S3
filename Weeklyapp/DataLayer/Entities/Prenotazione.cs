namespace Weeklyapp.DataLayer.Entities
{
    public class Prenotazione
    {
        public int Id { get; set; }
        public string CodiceFiscaleCliente { get; set; }
        public int NumeroCamera { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int NumeroProgressivoAnno { get; set; }
        public int Anno { get; set; }
        public DateTime PeriodoDal { get; set; }
        public DateTime PeriodoAl { get; set; }
        public decimal CaparraConfirmatoria { get; set; }
        public decimal Tariffa { get; set; }
        public string Dettagli { get; set; } // mezza pensione, pensione completa, pernottamento con prima colazione
    }
}
