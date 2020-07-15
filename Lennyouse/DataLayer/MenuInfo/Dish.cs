using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.Data.MenuInfo
{
    public class Dish : NamedEntity
    {
        [ForeignKey("DietaryRestriction")]
        public Guid DietaryRestrictionId { get; set; }

        public virtual DietaryRestriction DietaryRestriction { get; set; }
        public virtual ICollection<Serving> Servings { get; set; }

        public Dish(string name, Guid dietaryRestrictionId) : base(name)
        {
            DietaryRestrictionId = dietaryRestrictionId;
        }

        public Dish(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, Guid dietaryRestrictionId)
            : base(id, createdAt, updatedAt, isDeleted, name) 
        {
            DietaryRestrictionId = dietaryRestrictionId;
        }
    }
}
