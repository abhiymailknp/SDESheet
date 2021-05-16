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

    }
}
