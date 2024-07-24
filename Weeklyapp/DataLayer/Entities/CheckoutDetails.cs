namespace Weeklyapp.DataLayer.Entities
{
    public class CheckoutDetails
    {
        public PrenotazioneEntity Prenotazione { get; set; }
        public IEnumerable<ServizioAggiuntivoEntity> ServiziAggiuntivi { get; set; }
        public decimal ImportoDaSaldare { get; set; }
    }
}
