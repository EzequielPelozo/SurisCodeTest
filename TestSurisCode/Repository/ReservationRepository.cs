using Microsoft.EntityFrameworkCore;
using TestSurisCode.Data;
using TestSurisCode.Models;
using TestSurisCode.Repository.IRepository;

namespace TestSurisCode.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _db;

        public ReservationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateReservation(Reservation reservation)
        {
            reservation.CreationDate = DateTime.Now;
            _db.Reservations.Add(reservation);
            return Save(); ;
        }

        public bool ExistReservation(int id)
        {
            return _db.Reservations.Any(c => c.Id == id);
        }

        public bool ExistReservation(DateTime date)
        {
            return _db.Reservations.Any(c => c.Date.Year == date.Year &&
                                             c.Date.Month == date.Month &&
                                             c.Date.Day == date.Day &&
                                             c.Date.Hour == date.Hour);
        }

        public Reservation GetReservation(int id)
        {
            return _db.Reservations.Include(r => r.Category).FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Reservation> GetReservations()
        {
            return _db.Reservations.Include(r => r.Category).OrderBy(c => c.ClientName).ToList();
        }

        public bool sameClientExists(string name, DateTime date)
        {
            return _db.Reservations.Any(r => r.ClientName.ToLower() == name.ToLower() && r.Date.Day == date.Day);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;  
        }

        
    }
}
