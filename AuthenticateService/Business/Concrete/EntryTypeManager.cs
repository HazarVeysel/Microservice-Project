using Business.BusinessAcpects;
using Business.Constans;
using Business.ValidationRules;
using Core.Aspect.Autofac.Validation;
using Core.Aspect.Caching;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Concrete;

namespace Business.Concrete
{
    public interface IEntryTypeService
    {
        IResult Add(EntryType EntryType);
        IDataResult<List<EntryType>> GetAll();
        IResult Update(EntryType entryType);
        IDataResult<EntryType> GetById(int id);                    
        IResult EntryTypeExists(EntryType entryType); 
        
    }

    public class EntryTypeManager : IEntryTypeService
    {
        private readonly IEntryTypeDal _entrytypeDal;
        public EntryTypeManager(IEntryTypeDal entrytypeDal) //Bu Constractor sayesinde new'leme işlemini yapar.
        {
            _entrytypeDal = entrytypeDal;
        }

        [SecuredOperation("EntryType.Add")]
        [CacheRemoveAspect("IEntryTypeService.Get")]
        [ValidationAspect(typeof(EntryTypeValidator))]        
        public IResult Add(EntryType entrytype)
        {            
                _entrytypeDal.Add(entrytype);
                return new SuccessResult(Messages.AddedEntryType);
            
        }

        [CacheAspect(120)]
        public IDataResult<List<EntryType>> GetAll()
        {
            return new SuccessDataResult<List<EntryType>>(_entrytypeDal.GetAll(), Messages.AddedEntryType);
        }
        public IResult EntryTypeExists(EntryType entryType)
        {
            var result = _entrytypeDal.Get(c => c.Name == entryType.Name);
            if (result != null)
            {
                return new ErrorResult(Messages.EntryTypeAlreadyExists);
            }
            return new SuccessResult();
        }       
       

        [CacheAspect(60)]
        public IDataResult<EntryType> GetById(int id)
        {
            return new SuccessDataResult<EntryType>(_entrytypeDal.Get(p => p.Id == id));
        }

        [CacheRemoveAspect("IEntryTypeService.Get")]
        public IResult Update(EntryType entryType)
        {
            _entrytypeDal.Update(entryType);
            return new SuccessResult(Messages.UpdatedEntryType);
        }
    }
}