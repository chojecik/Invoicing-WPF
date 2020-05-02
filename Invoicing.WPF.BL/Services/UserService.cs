using Invoicing.WPF.BL.Interfaces;
using Invoicing.WPF.Core.Database;
using Invoicing.WPF.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.WPF.BL.Services
{
    public class UserService : IUserService
    {
        private readonly InvoicingDbContext _context;

        public UserService(InvoicingDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public User Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contractor> GetUserContractors(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetUsersInvoicesByType(int userId, InvoiceType type)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
