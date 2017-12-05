using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data
{
    public class CGAContext : DbContext
    {
        public CGAContext():base("name=Alias")
        {


        }

    }
}
