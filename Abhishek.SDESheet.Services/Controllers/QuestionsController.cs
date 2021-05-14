using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abhishek.SDESheetDataAccess;

namespace Abhishek.SDESheet.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        SdeDBRepository repository;
        public QuestionsController()
        {
            repository = new SdeDBRepository();
        }
    }
}
