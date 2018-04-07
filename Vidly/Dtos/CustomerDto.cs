using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
      
        [Min18YrOlder]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedtoNewsletter { get; set; }

       

       
        public byte MembershipTypeId { get; set; }
    }
}