﻿using Invoicing_WPF.Database;
using Invoicing_WPF.Enums;
using Invoicing_WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_WPF.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        //private readonly AppSettings _appSettings;

        public UserService(DataContext context/*, IOptions<AppSettings> appSettings*/)
        {
            _context = context;
            //_appSettings = appSettings.Value;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .AsNoTracking()
                .ToList();
        }

        public User GetById(int id)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.UserId == id);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _context.Users
                .AsNoTracking()
                .Where(predicate)
                .ToList();
        }

        public User CreateUser(User user, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                //throw new ApplicationException
            }

            if (_context.Users.Any(x => x.Email.Equals(user.Email)))
            {
                //throw new AppException("Username \"" + user.Username + "\" is already taken");
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User Authenticate(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email.Equals(email));

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            //// authentication successful so generate jwt token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.UserId.ToString())
            //    }),
            //    Expires = DateTime.Now.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);

            return user;
        }
        public void Delete(User entity)
        {
            if (entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            if (entity != null)
            {
                _context.Users.AddOrUpdate(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Invoice> GetUsersInvoicesByType(int userId, InvoiceType type)
        {
            return _context.Users
                .Include("Invoices")
                .Include("Contractors")
                .FirstOrDefault(user => user.UserId == userId)
                .Invoices
                .Where(invoice => invoice.Type == (int)type)
                .ToList();
        }

        public IEnumerable<Contractor> GetUserContractors(int userId)
        {
            if (userId > 0)
            {
                return _context.Users
                    .Include("Contractors")
                    .FirstOrDefault(user => user.UserId == userId)
                    .Contractors
                    .ToList();
            }
            return null;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or whitespace");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }
            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }
            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
