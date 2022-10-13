using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.DataAccess.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public interface IUserDal : IGenericRepository<User>
    {
        List<OperationClaim> GetClaims(User user, int entrytypeId);
    }

    public class EFUserDal : GenericRepositoryBase<User, ContextDb>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user, int entrytypeId)
        {
            using (var context = new ContextDb())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name,
                             };
                return result.ToList();
            }
        }
    }
}