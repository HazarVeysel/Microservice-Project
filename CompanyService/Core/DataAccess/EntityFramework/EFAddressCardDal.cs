using Core.DataAccess.EntityFramework.Context;
using Core.DataAccess.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
   
    public interface IAddressCardDal : IGenericRepository<Tbl_AdresKart>
    {

    }
    public class EFAddressCardDal : GenericRepositoryBase<Tbl_AdresKart, ContextDb>, IAddressCardDal
    {
    }
}
