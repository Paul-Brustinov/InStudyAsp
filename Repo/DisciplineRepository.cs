using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFOracle.Model;
using Repo.Common;

namespace Repo
{
    public class DisciplineRepository : GenericRepository<DISCIPLINE>
    {
        public DisciplineRepository(dbContext context) : base(context) {}
    }
}
