using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bookish.Models;

namespace Bookish.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        //Overriding Conventions
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //Overriding label's using Display
        [Required(ErrorMessage = "Please select Membership Type.")]
        public byte MembershipTypeId { get; set; }

        //[Min18YrIfMember]
        public DateTime? BirthDate { get; set; }
    }
}