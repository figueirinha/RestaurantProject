using Recodme.RD.Lennyouse.Data.UserInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.UserInfo
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public Guid LennyouseUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long VatNumber { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public Person ToPerson()
        {
            return new Person(VatNumber, PhoneNumber, FirstName, LastName, BirthDate, LennyouseUserId);
        }

        public static PersonViewModel Parse(Person person)
        {
            return new PersonViewModel()
            {
                Id = person.Id,
                VatNumber = person.VatNumber,
                PhoneNumber = person.PhoneNumber,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                LennyouseUserId =  person.LennyouseUserId
            };
        }
    }
}
