using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.DataLayer.Services.Interfaces
{
    public interface IPrenotazioneService
    {
        void Create(Prenotazione prenotazione);
        void Delete(int id);
        Prenotazione Read(int id);
        void Update(Prenotazione prenotazione);
        List<Prenotazione> ReadAll();
    }
}
