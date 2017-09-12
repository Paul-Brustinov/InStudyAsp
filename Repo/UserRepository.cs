using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFOracle.Model;
using Repo.Common;

namespace Repo
{
    public class UserRepository : GenericRepository<USER>
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
