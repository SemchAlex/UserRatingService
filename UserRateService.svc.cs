using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using UserRatingService.Repository;

namespace UserRatingService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserRateService : IUserRateService, IDisposable
    {
        private readonly DataContext _context = new DataContext("dbUser");

        public void RegisteredUser(string nick, int userId)
        {
            try
            {
                _context.Users.Add(new User(userId, nick));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException s = ex.InnerException.InnerException as SqlException;
                if (s != null && (s.Number == 2627 || s.Number == 2601))
                {
                    throw new FaultException<ArgumentException>(new ArgumentException(),
                        "Пользователь с таким идентификатором уже существует");
                }
            }
        }

        public void PutPostEvaluation(int userId, int evaluation)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new FaultException<ArgumentException>(new ArgumentException(),
                    "Пользователя с таким идентификатором не существует");
            }
            user.Rating = evaluation;
            _context.SaveChanges();
        }

        public string GetMaxRatedUser()
        {
            var user = _context.Users.OrderBy(u => u.Rating).FirstOrDefault();
            return user == null ? string.Empty : user.Nick;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
