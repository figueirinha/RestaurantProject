using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.Data.UserInfo
{
    public class Person : Entity
    {       
        public virtual ICollection<StaffRecord> StaffRecords { get; set; }
        public virtual ICollection<ClientRecord> ClientRecords { get; set; }


        private long _vatNumber;
        [Display(Name = "VAT Number")]
        [Required]
        public long VatNumber
        {
            get => _vatNumber;
            set
            {
                _vatNumber = value;
                RegisterChange();
            }
        }

        private long _phoneNumber;
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Input phone number, please!")]
        public long PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                RegisterChange();
            }
        }

        private string _firstName;
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Input your firstname, please!")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                RegisterChange();
            }
        }

        private string _lastName;
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Input your lastname, please!")]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                RegisterChange();
            }
        }

        private DateTime _birthDate;
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Input your birth date, please!")]
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                RegisterChange();
            }
        }

        public Person(long vatNumber, long phoneNumber, string firstName, string lastName, DateTime birthDate) : base()
        {
            _vatNumber = vatNumber;
            _phoneNumber = phoneNumber;
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
        }

        public Person(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, long vatNumber, long phoneNumber, 
            string firstName, string lastName, DateTime birthDate) : base(id, createdAt, updatedAt, isDeleted)
        {
            _vatNumber = vatNumber;
            _phoneNumber = phoneNumber;
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
        }
    }
}
