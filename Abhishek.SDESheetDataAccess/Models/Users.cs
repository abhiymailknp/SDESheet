using System;
using System.Collections.Generic;

namespace Abhishek.SDESheetDataAccess.Models
{
    public partial class Users
    {
        public Users()
        {
            Progress = new HashSet<Progress>();
        }

        public string EmailId { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Progress> Progress { get; set; }
    }
}
