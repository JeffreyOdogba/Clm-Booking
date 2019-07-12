using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clm_Booking.Models
{
    public class BookRepository : IBookingRepository, IDisposable
    {
        readonly ClmEntity db = new ClmEntity();

        public BookRepository(ClmEntity clm_bookingEntities)
        {
            db = clm_bookingEntities;
        }

        public void RegisterAdmin(AdminClm admin)
        {
            db.AdminClms.Add(admin);
        }

        public void AddBooking(ClientClm client)
        {
            db.ClientClms.Add(client);
        }

        public void DeleteBooking(int ClientId)
        {
            ClientClm client = db.ClientClms.Find(ClientId);
            db.ClientClms.Remove(client);
        }

        public IEnumerable<ClientClm> GetClients()
        {
            return db.ClientClms.ToList();
        }

        public IEnumerable<AdminClm> GetAdmins()
        {
            return db.AdminClms.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAdmin(AdminClm adminClm)
        {
            db.Entry(adminClm).State = EntityState.Modified;
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BookRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}