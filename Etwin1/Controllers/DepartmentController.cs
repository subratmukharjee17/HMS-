using Etwin.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Etwin.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepositoryService _genericRepository;
        public DepartmentController(DepartmentRepositoryService genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DepartmentView()
        {
            var result = _genericRepository.GetAll();
            return Json(result, new JsonSerializerOptions());
        }
        public IActionResult GetDepatment()
        {
            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();

        }

    }
}
