using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos
{
    public class EntryTypeDto : EntryType, IDto
    {
        public int UserId { get; set; }
    }
}
