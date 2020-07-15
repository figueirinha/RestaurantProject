using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.Data.MenuInfo
{
    public class Course : NamedEntity
    {
        public virtual ICollection<Serving> Servings { get; set; }

        public Course(string name) : base(name) { } 
        public Course(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) :
            base(id, createdAt, updatedAt, isDeleted, name) { }

    }
}
