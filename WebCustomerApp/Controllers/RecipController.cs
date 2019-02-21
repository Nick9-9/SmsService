using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.MessageViewModels;
using WebCustomerApp.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class RecipController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public RecipController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<RecipViewModel> models = new List<RecipViewModel>();
            var phones = _unitOfWork.Phones.Get();

            foreach (var phone in phones)
            {
                RecipViewModel model = new RecipViewModel();
                model.PhoneRecepient = phone.PhoneRecepient;
                models.Add(model);

            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public   IActionResult Create(RecipViewModel recipViewModel)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Phone phone = new Phone() { PhoneRecepient = recipViewModel.PhoneRecepient};
            _unitOfWork.Phones.Add(phone);
            _unitOfWork.SaveChanges();

            return View();
        }

    }
}
