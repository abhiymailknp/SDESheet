using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abhishek.SDESheetDataAccess;
using Abhishek.SDESheetDataAccess.Models;

namespace Abhishek.SDESheet.Services.Controllers
{
    [Route("api/[controller]")]
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

    }
}
