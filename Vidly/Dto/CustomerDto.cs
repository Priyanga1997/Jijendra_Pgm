using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipTypeDto MembershipType{ get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}