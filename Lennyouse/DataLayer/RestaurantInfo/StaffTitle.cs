using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.Data.RestaurantInfo
{
    public class StaffTitle : Entity
    {
        public virtual Title Title { get; set; }

        [ForeignKey("Title")]
        public Guid TitleId { get; set; }
      

        public virtual StaffRecord StaffRecord { get; set; }
        [ForeignKey("StaffRecord")]
        public Guid StaffRecordId { get; set; }
        

        private DateTime _startDate;
        [Required(ErrorMessage = "Input Start Date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                RegisterChange();
            }
        }

        private DateTime _endDate;
        [Required(ErrorMessage = "Input End Date")]
        [Display(Name = "End Date")]
        public DateTime EndDate 
        {
           get => _endDate;
            set
            {
                _endDate = value;
                RegisterChange();
            }
        }

        public StaffTitle(Guid staffRecordId, Guid titleId, DateTime startDate, DateTime endDate) : base()
        {
            _startDate = startDate;            
            _endDate = endDate;
            TitleId = titleId;
            StaffRecordId = staffRecordId;
        }
        
        public StaffTitle(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime startDate, DateTime endDate,  
             Guid staffRecordId, Guid titleId) :
            base(id, createdAt, updatedAt, isDeleted)
        {
            _startDate = startDate;
            _endDate = endDate;
            TitleId = titleId;
            StaffRecordId = staffRecordId;
        }
    }
}
