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
        private bool CheckEntry(int qid, string emailid)
        {
            bool entry = false;
            try
            {
                var progressOfUser = (from progress in context.Progress
                               where progress.EmailId == emailid && progress.QuesId == qid
                               select progress.EmailId).SingleOrDefault();
                if (progressOfUser != null)
                {
                    entry = true;
                }
            }
            catch (Exception)
            {
                entry = false;
            }

            return entry;
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

        public bool UpdateProgress(int qId,string emailId,byte quesStatus,DateTime dateOfCompletion)
        {
            bool status = false;
            bool entry = CheckEntry(qId,emailId);
            try
            {
                if (!entry)
                {
                    Progress progress = new Progress();
                    progress.QuesId = qId;
                    progress.EmailId = emailId;
                    progress.Status = quesStatus;
                    progress.DateOfCompletion = dateOfCompletion;
                    context.Progress.Add(progress);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    Progress progress = context.Progress
                                               .Where(p => p.EmailId == emailId && p.QuesId == qId)
                                               .FirstOrDefault();
                    if(progress != null)
                    {
                        progress.Status = quesStatus;
                        context.SaveChanges();
                        status = true;
                    }
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
