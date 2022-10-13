using Core.DataAccess.EntityFramework;
using Core.DataAccess.EntityFramework.Context;
using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntryTypeDal : IGenericRepository<EntryType>
    {

    }
    public class EFEntryTypeDal : GenericRepositoryBase<EntryType, ContextDb>, IEntryTypeDal
    {
    }
}