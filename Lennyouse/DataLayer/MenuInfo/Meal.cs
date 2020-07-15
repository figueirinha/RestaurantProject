using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recodme.RD.Lennyouse.Data.MenuInfo
{
    public class Meal : NamedEntity
    {
        private string _startingHours;

        [Required]
        public string StartingHours
        {
            get
            {
                return _startingHours;
            }
            set
            {
                _startingHours = value;
                RegisterChange();
            }
        }
        private string _endingHours;

        [Required]
        public string EndingHours
        {
            get
            {
                return _endingHours;
            }
            set
            {
                _endingHours = value;
                RegisterChange();
            }
        }

        public virtual ICollection<Menu> Menus { get; set; }

        public Meal(string name, string startingHours, string endingHours) : base(name)
        {
            _startingHours = startingHours;
            _endingHours = endingHours;
        }

        public Meal(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, string startingHours, 
            string endingHours) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _startingHours = startingHours;
            _endingHours = endingHours;
        }
    }
}
