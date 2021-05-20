using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abhishek.SDESheet.Services.Models
{
    public class Progress
    {
        public int QuesId { get; set; }
        public string EmailId { get; set; }
        public byte Status { get; set; }
        public DateTime DateOfCompletion { get; set; }
    }
}
