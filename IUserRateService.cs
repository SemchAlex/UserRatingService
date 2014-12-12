using System.ServiceModel;

namespace UserRatingService
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IUserRateService
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="nick">Ник </param>
        /// <param name="userId">идентифиактор </param>
        [OperationContract]
        void RegisteredUser(string nick, int userId);

        /// <summary>
        ///  Оценка поста пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="evaluation"></param>
        [OperationContract]
        void PutPostEvaluation(int userId, int evaluation);

        /// <summary>
        /// Получить ник юзера с максимальным рейтингом
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetMaxRatedUser();
    }
}
