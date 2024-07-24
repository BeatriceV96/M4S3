namespace Weeklyapp.DataLayer.Entities
{
    public class ServizioAggiuntivoEntity
    {
        public int ID { get; set; }
        public int IDPrenotazione { get; set; }
        public DateTime DataServizio { get; set; }
        public string Descrizione { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
    }
}
