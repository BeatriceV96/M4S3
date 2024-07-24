namespace Weeklyapp.DataLayer.Entities
{
    public class ServizioAggiuntivo
    {
        public int Id { get; set; }
        public int IdPrenotazione { get; set; }
        public DateTime DataServizio { get; set; }
        public string Descrizione { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
    }
}
