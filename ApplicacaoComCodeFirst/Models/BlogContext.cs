using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApplicacaoComCodeFirst.Models
{
    public class BlogContext: DbContext
    {
        public BlogContext() : base("name=BlogContext")
        {
            //Database.Connection.ConnectionString 
            //    = @"data source=Marlon-pc\SQLEXPRESS; initial catalog=BlogBDLivro; Integrated Security=SSPI";


            Database.Connection.ConnectionString
                = @"Data Source=MARLON-PC\SQLEXPRESS;Initial Catalog=BlogBDLivro;Persist Security Info=True;User ID=sa;Password=minokamo";
        }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}