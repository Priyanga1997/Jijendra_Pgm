using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId{ get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        public bool IsSubscribedToNewsLetter{ get; set; }
        public MembershipType MembershipType { get; set; }
        [Required]

        [Display(Name ="MembershipType")]
        public byte MembershipTypeId { get; set; }
        [Required]
        [Display(Name="Date Of Birth")]
        public DateTime? BirthDate { get; set; }

    }
}