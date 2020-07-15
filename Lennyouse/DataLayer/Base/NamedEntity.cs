using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.RD.Lennyouse.DataLayer.Base
{
    public abstract class NamedEntity : Entity
    {

        private string _name;

        [Required]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RegisterChange();
            }
        }

        public NamedEntity(string name) : base()
        {
            _name = name;
        }

        protected NamedEntity(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) 
            : base(id, createdAt, updatedAt, isDeleted)
        {
            _name = name;
        }

    }

}


