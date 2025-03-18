using TestSurisCode.Models;

namespace TestSurisCode.Repository.IRepository
{
    public interface IReservationRepository
    {
        ICollection<Reservation> GetReservations();
        bool CreateReservation(Reservation reservation);
        Reservation GetReservation(int id);
        bool ExistReservation(int id);
        bool ExistReservation(DateTime date);
        bool sameClientExists(string name, DateTime date);
        bool Save();
    }
}
