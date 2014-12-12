
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRatingService.Repository
{
    /// <summary>
    /// Пользователь соцсети
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(0, 1000000000)]
        public int Id { get; set; }

        [MinLength(1), MaxLength(20)]
        public string Nick { get; set; }

        private int _rating;

        /// <summary>
        /// Рейтинг пользователя(среднее значение всех оценко постов)
        /// </summary>
        [Index("Ix_Rating", 1)]
        [Range(-1000000000, 1000000000)]
        public int Rating
        {
            get { return _rating; }
            set { _rating = (_rating*_postCount + value)/++_postCount; }
        }

        private int _postCount;

        public int PostCount
        {
            get { return _postCount; }
            set { _postCount = value; }
        }

        public User(int userId, string nick, int rating = 0, int postCount = 0)
        {
            this.Id = userId;
            this.Nick = nick;
            this._rating = rating;
            this._postCount = postCount;
        }

        public User()
        {

        }
    }
}