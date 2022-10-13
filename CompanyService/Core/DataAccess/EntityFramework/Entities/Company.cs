using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework.Entities
{
    public class Company : IEntity
    {
        public int ID { get; set; }
        public int CLIENTID { get; set; }
        public bool PENDING_DELETION { get; set; }
        public string DELETED_BY { get; set; }
        public DateTime? DELETED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime? UPDATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }

        public string COMPANYNAME { get; set; }
        public string COUNTRY { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string ZIPCODE { get; set; }
        public string ADDRESS { get; set; }
        public string ADDRESS_1 { get; set; }
        public string TAXOFFICE { get; set; }
        public string TELEPHONE { get; set; }
        public string TELEPHONE_2 { get; set; }
        public string FAX { get; set; }
        public string EMAIL { get; set; }
        public string WEB_URL { get; set; }
        public string NOTE { get; set; }

        public int COMPANY_TYPE { get; set; }
        public bool IS_ABROAD { get; set; }

        public int MATURITY_DAY { get; set; }

        public string SPCODE1 { get; set; }
        public string SPCODE2 { get; set; }
        public string SPCODE3 { get; set; }
        public string SPCODE4 { get; set; }
        public string SPCODE5 { get; set; }

        public bool IS_ACTIVE { get; set; }
        public int COMPANY_LEVEL { get; set; }
    }
}
