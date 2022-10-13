using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Concrete
{
    /// <summary>
    /// Hatalı işlem sonrası veri ile ilgili dönebilecek sonuçları yapılandırdık.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult() : base(default, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
    }
}