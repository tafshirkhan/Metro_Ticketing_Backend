using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = MetroTicketing.System.Entities.Transaction;

namespace Metro.Ticketing.Infrastructure.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Booking> BookingRepository { get; }
        IGenericRepository<Passenger> PassengerRepository { get; }
        IGenericRepository<Ticket> TicketRepository { get; }
        IGenericRepository<BankCredential> BankCredentialRepository { get; }
        IGenericRepository<Seat> SeatRepository { get; }
        IGenericRepository<Train> TrainRepository { get; }
        IGenericRepository<Transaction> TransactionRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
