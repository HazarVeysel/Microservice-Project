using Business.Constans;
using Core.Entities.Concrate;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Hashing;
using Core.Utilities.JWT;
using Core.Utilities.Concrete;
using Business.ValidationRules;
using FluentValidation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegister userForRegister, string password);
        IDataResult<User> Login(UserForLogin userForLogin);
        IDataResult<User> GetByMailConfirmValue(string value);
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEmail(string email);
        IResult UserExists(string email);
        IResult Update(User user);
        IResult ChangePassword(User user);
        IResult EntryTypeExists(EntryType entrytype);
        IResult SendConfirmEmailAgain(User user);
        IDataResult<AccessToken> CreateAccessToken(User user, int entrytypeId);
        IDataResult<UserEntryType> GetEntryType(int userId);
        IResult SendForgotPasswordEmail(User user, string value);
    }

    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IResult ChangePassword(User user)
        {
            throw new NotImplementedException();
        }

        public IResult EntryTypeExists(EntryType entrytype)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user, int entrytypeId)
        {
            var claims = _userService.GetClaims(user, entrytypeId);
            //var entrytype = _entrytypeService.GetById(entrytypeId).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims, entrytypeId);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.SuccessfulLogin);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByMailConfirmValue(string value)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserEntryType> GetEntryType(int userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(UserForLogin userForLogin)
        {
            var userToCheck = _userService.GetByMail(userForLogin.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegister userForRegister, string password)
        {
            

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegister.Email,
                AddedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = userForRegister.Name
            };

            //ValidationTool.Validate(new UserValidator(), user);

            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult SendConfirmEmailAgain(User user)
        {
            throw new NotImplementedException();
        }

        public IResult SendForgotPasswordEmail(User user, string value)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
