using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    public class StateController : Controller
    {
        //State/SetSession?name=Ahmed & age = 20
        public IActionResult SetSession(string name,int age)
        {
            HttpContext.Session.SetString("Name",name);
            HttpContext.Session.SetInt32("Age", age);

            return Content("Session Save Succe");
        }
        //State/GetSession
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");

            return Content($"Name is {name} , Age is {age}");
        }
    }
}
