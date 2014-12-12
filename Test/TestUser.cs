using UserRatingService.Repository;

namespace UserRatingService.Test
{
   using NUnit.Framework;

    [TestFixture]
    public class TestUser
    {
        [Test]
        public void UserInit()
        {
            var c = new User(12, "Nick");
            Assert.AreEqual(0, c.Rating, "Начальное значения рейтинга не равно 0");
        }

        [Test]
        public void UserRating()
        {
            var msg = "Значения рейтинга не равоно среднему значению оценок всех постов";
            var c = new User(15, "Nick") { Rating = 200 };
            Assert.AreEqual(200, c.Rating, msg);
            c.Rating = 1000;
            Assert.AreEqual(600, c.Rating, msg);
            c.Rating = -400;
            Assert.AreEqual(266, c.Rating, msg);
        }
       
    }
}