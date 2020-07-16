using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.Data.UserInfo
{
    public class LennyouseUser : IdentityUser<Guid>
    {
        [Key]
        public override Guid Id  { get; set;} 
        public virtual Person Person { get; set; }

        [ForeignKey("Person")]
        public virtual Guid PersonId { get; set; }

        //public LennyouseUser(Guid id, Guid personId) : base()
        //{
        //    Id = id;
        //    PersonId = personId;
        //}

        //public LennyouseUser(string userName, Guid id, Guid personId) : base(userName)
        //{
        //    Id = id;
        //    PersonId = personId;
        //}

        //public LennyouseUser(Guid personId)
        //{
        //    Id = Guid.NewGuid();
        //    PersonId = personId;
        //}
    }
}
