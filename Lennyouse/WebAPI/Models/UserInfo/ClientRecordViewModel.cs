using Recodme.RD.Lennyouse.Data.UserInfo;
using System;
namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.UserInfo
{
    public class ClientRecordViewModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime RegisterDate { get; set; }

        public ClientRecord ToClientRecord()
        {
            return new ClientRecord(RegisterDate, PersonId, RestaurantId);
        }
        public static ClientRecordViewModel Parse(ClientRecord clientRecord)
        {
            return new ClientRecordViewModel()
            {
                Id = clientRecord.Id,
                RegisterDate = clientRecord.RegisterDate,
                PersonId = clientRecord.PersonId,
                RestaurantId = clientRecord.RestaurantId
            };
        }
    }
}
