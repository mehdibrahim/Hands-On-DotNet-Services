using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Controllers;
using SchoolAPI.Models;
using SchoolWebAppClient.Models;

namespace SchoolWebAppClient.Controllers
{
    public class SchoolClientController : Controller
    {
        private readonly ILogger<SchoolsController> _logger;
        HttpClient client;
        public SchoolClientController(ILogger<SchoolsController> logger)
        {
            _logger = logger;
            client = new ()
            {
                BaseAddress = new Uri("https://localhost:7069/")
            };
        }
     

       
        public async Task<ActionResult<IEnumerable<School>>> GetAllSchools()
        {
            HttpResponseMessage response = await client.GetAsync("api/Schools/get-all-schools");
            if (response.IsSuccessStatusCode)
            {
                    var schools = await response.Content.ReadFromJsonAsync<IEnumerable<SchoolClient>>();
                return View(schools);
            }
            else return View();
        }
       //[HttpPost("api/Schools/get-all-schools")]
        public async Task<ActionResult<IEnumerable<School>>> CreateSchools(SchoolClient school)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Schools/create-school",school);
            if (response.IsSuccessStatusCode)
            {
        
                return RedirectToAction("GetAllSchools");
            }
            else return View();
        }



    }
}
