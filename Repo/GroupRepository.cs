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
    public class GroupRepository : GenericRepository<GROUP>
    {
        public GroupRepository(DbContext context) : base(context) { }
    }
}
