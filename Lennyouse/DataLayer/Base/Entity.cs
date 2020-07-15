using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.RD.Lennyouse.DataLayer.Base
{ 
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; private set; }
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; protected set; }

        private bool _isDeleted;
        [Display(Name = "Deleted")]
        public bool IsDeleted
        {
            get => _isDeleted;
            set
            {
                _isDeleted = value;
                RegisterChange();
            }
        }

        protected virtual void RegisterChange()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
            _isDeleted = false;
        }

        protected Entity(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            _isDeleted = isDeleted;
        }
    }   
}
