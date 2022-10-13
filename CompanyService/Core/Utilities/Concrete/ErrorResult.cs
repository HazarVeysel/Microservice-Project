using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Concrete
{
    public class ErrorResult : Result
    {
        /// <summary>
        /// İşlemin hatalı olması durumunda dönmesi gereken sonuçları yapılandırdık.
        /// </summary>
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}
