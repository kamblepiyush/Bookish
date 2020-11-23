using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookish.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //Overriding Conventions
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        //Overriding label's using Display
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please select Membership Type.")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YrIfMember]
        public DateTime? BirthDate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}