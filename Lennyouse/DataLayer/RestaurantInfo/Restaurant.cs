using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.RD.Lennyouse.Data.RestaurantInfo
{
    public class Restaurant : NamedEntity
    {
        public virtual ICollection<ClientRecord> ClientRecords{ get; set; }
        public virtual ICollection<StaffRecord> StaffRecords { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

        private string _address;
        [Required(ErrorMessage = "Input Address")]
        [Display(Name = "Address")]
        public string Address 
        { 
            get => _address;
            set
            {
                _address = value;
                RegisterChange();
            }
        }

        private string _openningHours;
        [Required(ErrorMessage = "Input Openning Hours")]
        [Display(Name = "Openning Hours")]
        public string OpenningHours
        {
            get => _openningHours;
            set
            {
                _openningHours = value;
                RegisterChange();
            }
        }

        private string _closingHours;
        [Required(ErrorMessage = "Input Closing Hours")]
        [Display(Name = "Closing Hours")]
        public string ClosingHours
        {
            get => _closingHours;
            set
            {
                _closingHours = value;
                RegisterChange();
            }
        }
        
        private string _closingDays;
        [Required(ErrorMessage = "Input Closing Days")]
        [Display(Name = "Closing Days")]
        public string ClosingDays
        {
            get => _closingDays;
            set
            {
                _closingDays = value;
                RegisterChange();

            }
        }

        private int _tableCount;       
        public int TableCount
        {
            get => _tableCount;
            set
            {
                _tableCount = value;
                RegisterChange();
            }
        }

        public Restaurant(string name, string address, string openningHours,string closingHours, string closingDays,
            int tableCount) : base(name)
        {
            _address = address;
            _openningHours = openningHours;
            _closingHours = closingHours;
            _closingDays = closingDays;
            _tableCount = tableCount;
        }

        public Restaurant(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, string address,
            string openningHours, string closingHours, string closingDays, int tableCount) :
            base(id, createdAt, updatedAt, isDeleted, name)
        {
            _address = address;
            _openningHours = openningHours;
            _closingHours = closingHours;
            _closingDays = closingDays;
            _tableCount = tableCount;
        }
    }
}
