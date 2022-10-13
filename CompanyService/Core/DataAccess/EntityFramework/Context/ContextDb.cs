using Core.DataAccess.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework.Context
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-K97E4FR; Database=MglCore6DB;Integrated Security=true");
            optionsBuilder.UseSqlServer(@"Server=10.1.1.178,49172;Database=MglCore6DB; User=veysel; Password=Password12*");

        }

        //Oluşturduğumuz veri tablolarını tek tek tanımlıyoruz.

        public DbSet<Company> Companies { get; set; }
        public DbSet<Tbl_AdresKart> Tbl_AdresKartlari { get; set; }




    }
}
