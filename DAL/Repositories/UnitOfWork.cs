using BAL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Data;
using WebCustomerApp.Models;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserManager<ApplicationUser> userManagerRepository;
        public IGenericRepository<Phone> phoneRepository;
        public IGenericRepository<Message> messageRepository;
        public IGenericRepository<MessageRecipient> recipientRepository;

        public UnitOfWork(UserManager<ApplicationUser> _userManagerRepository, IGenericRepository<Phone> _phoneRepository, IGenericRepository<Message> _messageRepository, IGenericRepository<MessageRecipient> _recipientRepository)
        {
            userManagerRepository = _userManagerRepository;
            phoneRepository = _phoneRepository;
            messageRepository = _messageRepository;
            recipientRepository = _recipientRepository;
        }

        public UnitOfWork()
        {
        }


        //public void Commit()
        //{
        //    db.SaveChanges();
        //}
        public UserManager<ApplicationUser> UserManagers
        {
            get
            {
                return userManagerRepository;
            }
        }
        public IGenericRepository<Phone> Phones
        {
            get
            {
                return phoneRepository;
            }
        }
        public IGenericRepository<MessageRecipient> MessageRecipients
        {
            get
            {

                return recipientRepository;
            }
        }
        public IGenericRepository<Message> Messages
        {
            get
            {

                return messageRepository;
            }
        }



        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

       public void SaveChanges()
       {
            phoneRepository.SaveChanges();
            messageRepository.SaveChanges();
            recipientRepository.SaveChanges();
            
       }
    }
}

