using Core.DataAccess.EntityFramework.Context;
using Core.DataAccess.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public interface ICompanyDal : IGenericRepository<Company>
    {
    }

    public class EFCompanyDal : GenericRepositoryBase<Company, ContextDb>, ICompanyDal
    {
    }
    
}
