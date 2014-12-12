using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserRatingService.Repository;

namespace UserRatingService.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class TestDBwork
    {
        private DataContext _context;
        [SetUp]
        public void InitDb()
        {
            _context = new DataContext("dbUserTest");
            _context.Users.RemoveRange(_context.Users.ToList());
            _context.SaveChanges();

        }

        [Test]
        public void AddUser()
        {
            _context.Users.Add(new User(3, "TestUser"));
            _context.Users.Add(new User(300, "TestUser2"));
            _context.SaveChanges();
        }

        [Test]
        public void GetUser()
        {
            _context.Users.Add(new User(34, "TestUser3"));
            _context.Users.Add(new User(3030, "TestUser5"));
            _context.SaveChanges();
            var result = _context.Users.Where(a => a.Rating == 0);
            Assert.AreNotEqual(0,result.Count(),"Должны бить пользователи");
        }
      
    }
}