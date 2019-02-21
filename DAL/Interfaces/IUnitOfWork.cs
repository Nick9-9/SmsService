using BAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork //: IDisposable
    {
        UserManager<ApplicationUser> UserManagers { get; }
        IGenericRepository<Message> Messages { get; }
        IGenericRepository<MessageRecipient> MessageRecipients { get; }
        IGenericRepository<Phone> Phones { get; }
        void SaveChanges();
    }
}
