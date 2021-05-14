using System;
using System.Collections.Generic;
using System.Text;
using Abhishek.SDESheetDataAccess.Models;

namespace Abhishek.SDESheetDataAccess
{
    public class SdeDBRepository
    {
        SdeDBContext context;
        public SdeDBRepository()
        {
            context = new SdeDBContext();
        }
    }
}
