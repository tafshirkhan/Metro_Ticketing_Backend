using Metro.Ticketing.DAL.DatabaseContext;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MetroTicketingDbContext _context;

        private IGenericRepository<User> _UserRepository;
        private IGenericRepository<Booking> _BookingRepository;
        private IGenericRepository<Passenger> _PassengerRepository;
        private IGenericRepository<Ticket> _TicketRepository;
        private IGenericRepository<BankCredential> _BankCredentialRepository;
        private IGenericRepository<Seat> _SeatRepository;
        private IGenericRepository<Train> _TrainRepository;
        private IGenericRepository<Transaction> _TransactionRepository;

        public UnitOfWork(MetroTicketingDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> UserRepository => _UserRepository ??= new GenericRepository<User>(_context);

        public IGenericRepository<Booking> BookingRepository => _BookingRepository ??= new GenericRepository<Booking>(_context);

        public IGenericRepository<Passenger> PassengerRepository => _PassengerRepository ??= new GenericRepository<Passenger>(_context);

        public IGenericRepository<Ticket> TicketRepository => _TicketRepository ??= new GenericRepository<Ticket>(_context);

        public IGenericRepository<BankCredential> BankCredentialRepository => _BankCredentialRepository ??= new GenericRepository<BankCredential>(_context);

        public IGenericRepository<Seat> SeatRepository => _SeatRepository ??= new GenericRepository<Seat>(_context);

        public IGenericRepository<Train> TrainRepository => _TrainRepository ??= new GenericRepository<Train>(_context);

        public IGenericRepository<Transaction> TransactionRepository => _TransactionRepository ??= new GenericRepository<Transaction>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
