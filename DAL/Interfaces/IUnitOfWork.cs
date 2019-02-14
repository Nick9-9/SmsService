using BAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<ApplicationUser> UserManagers { get; }
        GenericRepository<Message> Messages { get; }
        GenericRepository<MessageRecipient> MessageRecipients { get; }
        GenericRepository<Phone> Phones { get; }
        GenericRepository<AdditInform> AdditInforms { get; }
        void Save();
    }
}
