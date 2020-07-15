using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.Data.RestaurantInfo
{
    public class Booking : Entity
    { 
        public virtual ClientRecord ClientRecord { get; set; }
        [ForeignKey("ClientRecord")]
        public Guid ClientRecordId { get; set; }
        
        private DateTime _date;
        [Required(ErrorMessage = "Input Date")]
        [Display(Name = "Date")]
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                RegisterChange();
            }
        }

        public Booking(Guid clientRecordId,DateTime date) : base() 
        {
            _date = date;
            ClientRecordId = clientRecordId;
        }

        public Booking(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted,
           Guid clientRecordId, DateTime date) : base(id, createdAt, updatedAt, isDeleted)
        {
            _date = date;
            ClientRecordId = clientRecordId;
        }

    }
}
