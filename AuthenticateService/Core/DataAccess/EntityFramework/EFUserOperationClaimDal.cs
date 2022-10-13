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
    public interface IUserOperationClaimDal : IGenericRepository<UserOperationClaim>
    {
    }
    public class EFUserOperationClaimDal : GenericRepositoryBase<UserOperationClaim, ContextDb>, IUserOperationClaimDal
    {
    }
}