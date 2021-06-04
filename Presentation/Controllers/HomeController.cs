using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Controllers.Models;
using Business;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMteller _mteller;

        public HomeController(ILogger<HomeController> logger, IMteller mTeller)
        {
            _logger = logger;
            _mteller = mTeller;
        }

        public IActionResult Index()
        {
            OrganisationProcessor organisationProcessor = new OrganisationProcessor(_mteller);
            organisationProcessor.Create(new Model.Organisation { });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
