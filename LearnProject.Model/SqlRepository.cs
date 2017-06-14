using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace LearnProject.Model
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public LearnProjectDbDataContext Db { get; set; }
    
    }
}
