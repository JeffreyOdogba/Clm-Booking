using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clm_Booking.Models
{
    interface IBookingRepository : IDisposable
    {
        IEnumerable<ClientClm> GetClients();
        IEnumerable<AdminClm> GetAdmins();
        void RegisterAdmin(AdminClm admin);
        void AddBooking(ClientClm client);
        void DeleteBooking(int ClientId);
        void Save();
        void UpdateAdmin(AdminClm adminClm);
    }
}
