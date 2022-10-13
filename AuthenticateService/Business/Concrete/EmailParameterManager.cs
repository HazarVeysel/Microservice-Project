using Core.DataAccess.EntityFramework;

namespace Business.Concrete
{
    public interface IEmailParameterService
    {
    }
    public class EmailParameterManager : IEmailParameterService
    {
        private readonly IEmailParameterDal _mailParameterDal;

        public EmailParameterManager(IEmailParameterDal mailParameterDal)
        {
            _mailParameterDal = mailParameterDal;
        }
    }
}