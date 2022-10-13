using Business.Constans;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.EntityFramework.Entities;
using Core.Utilities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public interface IAddressCardService
    {
        IResult Add(Tbl_AdresKart AdresKart);
        IDataResult<List<Tbl_AdresKart>> GetAll();
        IResult Update(Tbl_AdresKart AdresKart);
        IDataResult<Tbl_AdresKart> GetById(int id);
        IResult AddressCardExists(Tbl_AdresKart AdresKart);

    }
    public class AddressCardManager : IAddressCardService
    {
        private readonly IAddressCardDal _addressCardDal;
        public AddressCardManager(IAddressCardDal addressCardDal) //Bu Constractor sayesinde new'leme işlemini yapar.
        {
            _addressCardDal = addressCardDal;
        }
        public IResult Add(Tbl_AdresKart adresKart)
        {
            _addressCardDal.Add(adresKart);
            return new SuccessResult(Messages.AddedEntryType);
        }

        
        public IDataResult<List<Tbl_AdresKart>> GetAll()
        {
            return new SuccessDataResult<List<Tbl_AdresKart>>(_addressCardDal.GetAll(), Messages.AddedEntryType);
        }
        public IResult AddressCardExists(Tbl_AdresKart adresKart)
        {
            var result = _addressCardDal.Get(c => c.musteradi == adresKart.musteradi);
            if (result != null)
            {
                return new ErrorResult(Messages.EntryTypeAlreadyExists);
            }
            return new SuccessResult();
        }


        
        public IDataResult<Tbl_AdresKart> GetById(int id)
        {
            return new SuccessDataResult<Tbl_AdresKart>(_addressCardDal.Get(p => p.id == id));
        }

        
        public IResult Update(Tbl_AdresKart adresKart)
        {
            _addressCardDal.Update(adresKart);
            return new SuccessResult(Messages.UpdatedEntryType);
        }

        
    }
}
