using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class CheckoutService
    {
        private readonly PrenotazioneDao prenotazioneDao;

        public CheckoutService(PrenotazioneDao prenotazioneDao)
        {
            this.prenotazioneDao = prenotazioneDao;
        }

        public CheckoutDetails GetCheckoutDetails(int prenotazioneId)
        {
            return prenotazioneDao.GetCheckoutDetails(prenotazioneId);
        }
    }
}
