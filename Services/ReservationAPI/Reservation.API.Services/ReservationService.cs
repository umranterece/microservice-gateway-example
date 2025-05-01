using Reservation.API.Infrastructure;
using Reservation.API.Models;

namespace Reservation.API.Services;

public class ReservationService:IReservationService
{
    public ReservationDTO GetReservationById(int id)
    {
        return new ReservationDTO()
        {
            Id = id,
            BkgNumber = (new Random()).Next(0, 999999),
            CheckInDate = DateTime.Now.AddDays(+7),
            CheckOutDate = DateTime.Now.AddDays(+14),
            BkgDate = DateTime.Now,
            Amount = (new Random()).Next(0, 999999)
        };
    }
}