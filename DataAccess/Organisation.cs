using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Organisation
    {
        public Guid OrgId { get; set; }
        public string Name { get; set; }
        public string VATId { get; set; }
        public string BusinessRegistrationId { get; set; }
        public DateTime BusinessRegistrationDate { get; set; }
        public List<string> Owners { get; set; }
        public List<string> CEOs { get; set; }
        public Guid CountryOfOrigin { get; set; }
    }
}
