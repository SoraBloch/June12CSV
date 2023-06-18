using June12CSV.Data;
using June12CSV.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace June12CSV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly string _connectionString;

        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getpeople")]
        public List<Person> GetPeople()
        {
            var repo = new PersonRepository(_connectionString);
            return repo.GetPeople();
        }
        [HttpPost]
        [Route("deletepeople")]
        public void DeletePeople()
        {
            var repo = new PersonRepository(_connectionString);
            repo.DeletePeople();
        }
        [HttpPost]
        [Route("uploadpeople")]
        public void UploadPeople(UploadViewModel vm)
        {
            string base64 = vm.Base64.Substring(vm.Base64.IndexOf(",") + 1);
            byte[] bytes = Convert.FromBase64String(base64);
            var people = CSV.GetCsvFromBytes(bytes);
            var repo = new PersonRepository(_connectionString);
            repo.AddPeople(people);

        }
        [HttpGet]
        [Route("generatepeople")]
        public IActionResult GeneratePeople(int amount)
        {
            var repo = new PersonRepository(_connectionString);
            var people = repo.GeneratePeople(amount);
            var csv = CSV.BuildPeopleCsv(people);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "people.csv");
        }
    }
}
