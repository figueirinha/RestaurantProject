using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.Data.UserInfo
{
    public class StaffRecord : Entity
    {
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }

        private DateTime _beginDate;
        [Display(Name = "Begin Date")]
        [Required]
        public DateTime BeginDate
        {
            get => _beginDate;
            set
            {
                _beginDate = value;
                RegisterChange();
            }
        }

        private DateTime _endDate;
        [Required]
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                RegisterChange();
            }
        }

        public virtual ICollection<StaffTitle> StaffTitles { get; set; }
        public virtual Person Person { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public StaffRecord(DateTime beginDate, DateTime endDate, Guid personId, Guid restaurantId) : base()
        {
            _beginDate = beginDate;
            _endDate = endDate;
            PersonId = personId;
            RestaurantId = restaurantId;
        }

        public StaffRecord(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime beginDate, DateTime endDate, Guid personId, Guid restaurantId) : base(id, createdAt, updatedAt, isDeleted)
        {
            _beginDate = beginDate;
            _endDate = endDate;
            PersonId = personId;
            RestaurantId = restaurantId;
        }
    }
}
