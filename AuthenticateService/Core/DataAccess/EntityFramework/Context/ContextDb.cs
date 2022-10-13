using Core.Entities.Concrete;
using Core.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework.Context
{
    //Veri tabanı ile programımız arasındaki bağlantıyı gerçekleştirdiğimiz alan
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-K97E4FR; Database=MglCore6DB;Integrated Security=true");
            optionsBuilder.UseSqlServer(@"Server=10.1.1.178,49172;Database=MglCore6DB; User=veysel; Password=Password12*");
            
        }

        //Oluşturduğumuz veri tablolarını tek tek tanımlıyoruz.

        public DbSet<EntryType> EntryTypes { get; set; }

        public DbSet<EmailParameter> EmailParameters { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEntryType> UserCompanies { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}