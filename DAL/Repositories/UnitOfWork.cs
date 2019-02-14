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
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManagerRepository;
        private GenericRepository<Phone> phoneRepository;
        private GenericRepository<Message> messageRepository;
        private GenericRepository<MessageRecipient> recipientRepository;
        private GenericRepository<AdditInform> addInformRepository;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> _userMenagerRepository, GenericRepository<Phone> _phoneRepository, GenericRepository<Message> _messageRepository, GenericRepository<MessageRecipient> _recipientRepository, GenericRepository<AdditInform> _addInformRepository)
        {
            db = context;
            userManagerRepository = _userMenagerRepository;
            phoneRepository = _phoneRepository;
            messageRepository = _messageRepository;
            recipientRepository = _recipientRepository;
            addInformRepository = _addInformRepository;
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
        public GenericRepository<Phone> Phones
        {
            get
            {
                if (this.phoneRepository == null)
                {
                    this.phoneRepository = new GenericRepository<Phone>(db);
                }
                return phoneRepository;
            }
        }
        public GenericRepository<MessageRecipient> MessageRecipients
        {
            get
            {
                if (this.recipientRepository == null)
                {
                    this.recipientRepository = new GenericRepository<MessageRecipient>(db);
                }
                return recipientRepository;
            }
        }
        public GenericRepository<Message> Messages
        {
            get
            {
                if (this.messageRepository == null)
                {
                    this.messageRepository = new GenericRepository<Message>(db);
                }
                return messageRepository;
            }
        }
        public GenericRepository<AdditInform> AdditInforms
        {
            get
            {
                if (this.addInformRepository == null)
                {
                    this.addInformRepository = new GenericRepository<AdditInform>(db);
                }
                return addInformRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

