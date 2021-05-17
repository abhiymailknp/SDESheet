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

        public List<Questions> GetAllQuestions()
        {
            var quesList = context.Questions.ToList();

            return quesList;
        }

        public bool ValidateLogin(string emailId, string password)
        {
            bool status = false;
            try
            {
                var objUser = (from usr in context.Users
                               where usr.EmailId == emailId && usr.UserPassword == password
                               select usr.EmailId).SingleOrDefault();

                if (objUser != null)
                {
                    status=true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

    }
}
