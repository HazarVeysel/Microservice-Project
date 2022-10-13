using Core.DataAccess.EntityFramework;
using Core.DataAccess.EntityFramework.Context;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;

namespace Core.DataAccess.EntityFramework
{
    public interface IEmailParameterDal : IGenericRepository<EmailParameter>
    {
    }

    public class EFEmailParameterDal : GenericRepositoryBase<EmailParameter, ContextDb>, IEmailParameterDal
    {
    }
}