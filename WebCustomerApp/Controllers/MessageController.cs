using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.MessageViewModels;
using WebCustomerApp.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class MessageController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public MessageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult MessageCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MessageCreate(MessageViewModel model)
        {
           
            if (ModelState.IsValid)
            {
               
                Message mesagge = new Message();
                mesagge.ApplicationUserId = _unitOfWork.UserManagers.GetUserId(User);

                mesagge.TextMessage = model.TextMessage;
                _unitOfWork.Messages.Create(mesagge);
                //_unitOfWork.MessageRecipients.Add(mesagge);
                Phone curentPhone;
                //List<Phone> recepients = new List<Phone>();
                //List<Phone> newphones = new List<Phone>();
                foreach (var phone in model.PhoneRecepient)
                {
                    curentPhone = _unitOfWork.Phones.FindById(phone);

                    if (curentPhone == null)
                    {
                        curentPhone = new Phone();
                        curentPhone.PhoneRecepient = model.PhoneRecepient;
                        
                        _unitOfWork.Phones.Add(curentPhone);
                        _unitOfWork.Phones.Create(curentPhone);
                       //_unitOfWork.MessageRecipients.Create(mesagge);

                    }
                    

                }
                _unitOfWork.SaveChanges();
                return View("SuccessSend");
            }


            return View(model);

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MessageList()
        {
            string userID = _unitOfWork.UserManagers.GetUserId(User);
            
            List<MessageListViewModel> messageList = new List<MessageListViewModel>();
            ViewBag.MessageListViewModel = messageList;
            return View();
            //string userID = _unitOfWork.UserManagers.GetUserId(User);
            //var messages = _unitOfWork.Messages.GetAll(f => f.ApplicationUserId == userID);

            //List<MessageListViewModel> messageList = new List<MessageListViewModel>();

            //foreach (var mes in messages)
            //{
            //    List<string> phones = new List<string>();
            //    var recepientMessages = _unitOfWork.MessageRecipients.GetAll(m => m.IdMesRec == mes.MessageId);
            //    foreach (var recepientMes in recepientMessages)
            //    {
            //        phones.Add(_unitOfWork.Phones.GetByID(recepientMes.IdMesRec).PhoneRecepient);
            //    }
            //    messageList.Add(new MessageListViewModel(mes.TextMessage, phones));
            //}
            //ViewBag.MessageListViewModel = messageList;
            //return View();
        }

        //[HttpGet]
        //public ActionResult Messages()
        //{
        //    List<ModelForMessageForSendingToUI> messagesWithRecipients = new List<ModelForMessageForSendingToUI>();
        //    List<Message> messages = _unitOfWork.Messages.FindById(_unitOfWork.UserManagers.GetUserId(User));
        //    foreach (var mes in messages)
        //    {
        //        List<Phone> phones = new List<Phone>();
        //        List<MessageRecipient> recepientMessages = _unitOfWork.Messages.GetByID(mes.MessageId);
        //        foreach (var recepientMes in recepientMessages)
        //        {
        //            phones.Add(_unitOfWork.Phones.FindById(recepientMes.PhoneId));
        //        }
        //        messagesWithRecipients.Add(new ModelForMessageForSendingToUI(mes, phones));
        //    }
        //    ViewBag.MessagesWithRecipients = messagesWithRecipients;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Messages(MessageViewModel messageModel)
        //{
        //    Message message = new Message();
        //    message.ApplicationUserId = _unitOfWork.UserManagers.GetUserId(User);
        //    message.TextMessage = messageModel.TextMessage;
        //    _unitOfWork.Messages.Create(message);
        //    List<Phone> phones = _unitOfWork.Phones.FindById(_unitOfWork.UserManagers.GetUserId(User));
        //    List<Phone> recepients = new List<Phone>();
        //    List<Phone> newphones = new List<Phone>();
        //    foreach (var recepient in messageModel.PhoneRecepient)
        //    {
        //        Phone phone = phones.Find(item => item.PhoneRecepient == recepient);
        //        if (phone != null)
        //        {
        //            recepients.Add(phone);
        //        }
        //        else
        //        {
        //            phone = new Phone();
        //            phone.PhoneRecepient = recepient;
        //            phone.ApplicationUserId = _unitOfWork.UserManagers.GetUserId(User);
        //            newphones.Add(phone);
        //        }
        //    }
        //    foreach (var newphone in newphones)
        //    {
        //        _unitOfWork.Phones.Create(newphone);
        //        recepients.Add(newphone);
        //    }
        //    foreach (var recepient in recepients)
        //    {
        //        MessageRecipient recepientMessage = new MessageRecipient();
        //        recepientMessage.MessageId = message.MessageId;
        //        recepientMessage.PhoneId = recepient.PhoneId;
        //        _unitOfWork.MessageRecipients.Create(recepientMessage);
        //    }
        //    _unitOfWork.SaveChanges();

        //    return Json(new { message.MessageId });
        //}










    }
}
