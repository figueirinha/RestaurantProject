using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.Data.UserInfo
{
    public class ClientRecord : Entity
    {
        [ForeignKey("Restaurant")]
        public virtual Guid RestaurantId { get; set; }

        [ForeignKey("Person")]
        public virtual Guid PersonId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Person Person { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public DateTime _registerDate { get; set; }
        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "Input an Register Date")]
        public DateTime RegisterDate
        {
            get => _registerDate;
            set
            {
                _registerDate = value;
                RegisterChange();
            }
        }

        public ClientRecord(DateTime registerDate, Guid personId, Guid restaurantId): base()
        {
            _registerDate = registerDate;
            PersonId = personId;
            RestaurantId = restaurantId;
        }

        public ClientRecord(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted,
            DateTime registerDate, Guid personId, Guid restaurantId) : 
            base(id, createdAt, updatedAt, isDeleted)
        {
            _registerDate = registerDate;
            PersonId = personId;
            RestaurantId = restaurantId;
        }
    }
}
