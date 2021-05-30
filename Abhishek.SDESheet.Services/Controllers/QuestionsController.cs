using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abhishek.SDESheetDataAccess;
using Abhishek.SDESheetDataAccess.Models;
using Abhishek.SDESheet.Services.Models;

namespace Abhishek.SDESheet.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        SdeDBRepository repository;
        public QuestionsController()
        {
            repository = new SdeDBRepository();
        }

        [HttpGet]
        public JsonResult GetAllQuestions()
        {

            List<Questions> questions = new List<Questions>();
            try
            {
                questions = repository.GetAllQuestions();
            }
            catch (Exception)
            {
                questions = null;
            }
            return Json(questions);
        }



        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<Users> users = 
                new List<Users>();
            try
            {
                users = repository.GetAllUsers();
            }
            catch (Exception ex)
            {
                users = null;
            }
            return Json(users);
        }


        [HttpPost]
        public JsonResult AddUser(Abhishek.SDESheetDataAccess.Models.Users user)
        {
            bool check;
            string message;
            try
            {
                check = repository.CheckUser(user.EmailId);
                if (check)
                {
                    message = "User Exists";
                }
                else
                {
                    repository.registerUser(user);
                    message = "User Registered Succesfully";
                }

            }
            catch (Exception)
            {
                message = "Some Error Occured";
            }
            return Json(message);
        }

        [HttpPost]
        public JsonResult ValidateUserCredentials(Models.User userObj)
        {
            bool status = false;
            try
            {
                status = repository.ValidateLogin(userObj.EmailId, userObj.UserPassword);
                
            }
            catch (Exception)
            {
                status=false;
            }
            return Json(status);
        }

        [HttpPost]
        public JsonResult UpdateQuestionProgress(Models.Progress progressObj)
        {
            bool status = false;
            try
            {
                status = repository.UpdateProgress(progressObj.QuesId, progressObj.EmailId, progressObj.Status, progressObj.DateOfCompletion);
            }
            catch (Exception)
            {

                status = false;
            }

            return Json(status);
        }

        [HttpGet]
        public JsonResult GetUserProgress(string emailId)
        {
            List<SDESheetDataAccess.Models.Progress> progress = new List<SDESheetDataAccess.Models.Progress>();
            try
            {
                progress = repository.getUserProgress(emailId);
            }
            catch (Exception)
            {
                progress = null;
            }
            return Json(progress);
        }


    }
}
