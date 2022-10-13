using Business.ValidationRules;
using Core.Aspect.Autofac.Validation;
using Core.Aspect.Caching;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using Core.Entities.Concrete;
using Core.Utilities.Concrete;

namespace Business.Concrete
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user, int entrytypeId);
        void Add(User user);
        void Update(User user);
        //IResult UpdateResult(UserForRegisterToSecondAccountDto userForRegister);
        //IResult UpdateOperationClaim(OperationClaimForUserListDto operationClaim);
        User GetById(int id);
        IDataResult<User> GetByIdToResult(int id);
        User GetByMail(string email);
        User GetByMailConfirmValue(string value);
        //IDataResult<List<UserEntryTypeDtoForList>> GetUserList(int entrytypeId);
        //IDataResult<List<OperationClaimForUserListDto>> GetOperationClaimListForUser(string value, int entrytypeId);
        //IResult UserEntryTypeDelete(int userId, int entrytypeId);
        //IDataResult<List<AdminCompaniesForUserDto>> GetAdminCompaniesForUser(int adminUserId, int userUserId);
        //IResult UserEntryTypeAdd(int userId, int entrytypeId);
        void UserDelete(User user);
        //IDataResult<List<EntryType>> GetUserEntryTypeList(string value);
    }


    public class UserManager : IUserService
    { private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {

            _userDal.Add(user);
        }

        [CacheAspect(60)]
        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        [CacheAspect(60)]
        public IDataResult<User> GetByIdToResult(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        [CacheAspect(60)]
        public User GetByMail(string email)
        {
            return _userDal.Get(p => p.Email == email);
        }

        [CacheAspect(60)]
        public User GetByMailConfirmValue(string value)
        {
            return _userDal.Get(p => p.MailConfirmValue == value);
        }

        public List<OperationClaim> GetClaims(User user, int entrytypeId)
        {
            return _userDal.GetClaims(user, entrytypeId);
        }

        //public IDataResult<List<EntryType>> GetUserEntryTypeList(string value)
        //{
        //    throw new NotImplementedException();
        //}

        [CacheRemoveAspect("IUserService.Get")]
        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public void UserDelete(User user)
        {
            user.IsActive=false;
            _userDal.Update(user);
        }

    }
}
