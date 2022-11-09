using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiTest.Data;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public readonly ApiDataContext _context;
        public HomeController(ApiDataContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public ActionResult GetStudent()
        {
            var Student = _context.Student.ToList();
            return Ok("OKok");
        }

        [HttpGet("{id}")]
 
        public ActionResult GetStudentById(int id)
        {
           // var student = _context.Student.;
            return Ok();
        }
        public IActionResult Index()
        {
            return Ok("asdasd");
        }
    }
}
