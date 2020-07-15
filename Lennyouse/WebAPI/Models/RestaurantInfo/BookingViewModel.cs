using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.RestaurantInfo
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid ClientRecordId { get; set; }

        public Booking ToDietaryRestrinction()
        {
            return new Booking(ClientRecordId, Date);
        }
        public static BookingViewModel Parse(Booking booking)
        {
            return new BookingViewModel()
            {
                Id = booking.Id,
                Date = booking.Date,
                ClientRecordId = booking.ClientRecordId
            };
        }
    }
}
