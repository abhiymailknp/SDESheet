using System;
using System.Collections.Generic;

namespace Abhishek.SDESheetDataAccess.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Progress = new HashSet<Progress>();
        }

        public int QuesId { get; set; }
        public string QuesLink { get; set; }
        public string VideoLink { get; set; }
        public string QuestionName { get; set; }

        public virtual ICollection<Progress> Progress { get; set; }
    }
}
