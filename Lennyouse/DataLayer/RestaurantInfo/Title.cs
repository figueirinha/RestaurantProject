using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.RD.Lennyouse.Data.RestaurantInfo
{
    public class Title : NamedEntity
    {
        public virtual ICollection<StaffTitle> TitleStaff { get; set; }  

        private string _position;
        [Required(ErrorMessage = "Input Position")]
        [Display(Name = "Position")]
        public string Position
        {
            get => _position;
            set
            {
                _position = value;
                RegisterChange();
            }
        }

        private string _description;
        [Required(ErrorMessage = "Input Description")]
        [Display(Name = "Description")]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RegisterChange();
            }
        }

        public Title(string position, string description, string name) : base(name)
        {
            _position = position;
            _description = description;
        }

        public Title(string position, string description, Guid id, DateTime createdAt, DateTime updatedAt, 
            bool isDeleted,string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _position = position;
            _description = description;
        }
    }
}
