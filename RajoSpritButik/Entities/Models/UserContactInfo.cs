using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class UserContactInfo
    {
        public int Id { get; set; }
        public int ContactInfoId { get; set; }
        public int UserId { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public User User { get; set; }
    }
}
