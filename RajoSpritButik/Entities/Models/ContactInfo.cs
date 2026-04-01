using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }

        public UserContactInfo UserContactInfos { get; set; } 
    }
}
