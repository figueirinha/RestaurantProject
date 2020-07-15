using Recodme.RD.Lennyouse.Data.UserInfo;
using System;
namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.UserInfo
{
    public class LennyouseUserViewModel
    {
        public Guid Id { get; set; }
      

        public LennyouseUser ToLennyouseUser()
        {
            return new LennyouseUser(Id);
        }
        public static LennyouseUserViewModel Parse(LennyouseUser LennyouseUser)
        {
            return new LennyouseUserViewModel()
            {
                Id = LennyouseUser.Id,
         
            };
        }
    }
}
