using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Users> GetAllUsers()
        {
            var usersList = context.Users.ToList();


            return usersList;
        }

    }
}
