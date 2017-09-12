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
    public class TeacherRepository : GenericRepository<TEACHER>
    {
        public TeacherRepository(DbContext context) : base(context) { }
    }
}
