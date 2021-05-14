using System;
using System.Collections.Generic;

namespace Abhishek.SDESheetDataAccess.Models
{
    public partial class Progress
    {
        public int? QuesId { get; set; }
        public string EmailId { get; set; }
        public byte? Status { get; set; }
        public DateTime? DateOfCompletion { get; set; }

        public virtual Users Email { get; set; }
        public virtual Questions Ques { get; set; }
    }
}
