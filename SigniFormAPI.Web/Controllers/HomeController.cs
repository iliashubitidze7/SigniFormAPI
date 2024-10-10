using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reader.DataAccess.Repository;
using SigniFormAPI.DataAccess.Repository.IRepository;
using SigniFormAPI.Models;
using SigniFormAPI.Utility;
using System.Diagnostics;

namespace SigniFormAPI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork unitOfWork;
        private SignifyApiServices signifyApiServices;
        private readonly SD sD;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork, SignifyApiServices signifyApiServices, SD sD)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.signifyApiServices = signifyApiServices;
            this.sD = sD;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(ContractSummaryForm contractSummaryForm)
        {
            if (contractSummaryForm != null) { 
                unitOfWork.ContractSummary.Add(contractSummaryForm);
            }

            unitOfWork.Save();

            return View("Confirmation");
        }

        [HttpPost]
        public IActionResult Send()
        {
            ContractSummaryForm form = unitOfWork.ContractSummary.Get(u=> u.Id == 2);

            string token = signifyApiServices.Authentication();
            int documentId = signifyApiServices.CreateDocument(token, sD.filePath);
            signifyApiServices.SetDocumentDetails(token, documentId, form.Email, form.ContractorName);
            signifyApiServices.SendDocument(token, documentId);

            return View("Confirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
