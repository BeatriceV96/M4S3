using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.DataLayer.Services.Interfaces
{
    public interface IServizioAggiuntivoService
    {

        void Create(ServizioAggiuntivo servizioAggiuntivo);
        ServizioAggiuntivo Read(int id);
        List<ServizioAggiuntivo> ReadAll();
        void Update(ServizioAggiuntivo servizioAggiuntivo);
        void Delete(int id);
    }
}
