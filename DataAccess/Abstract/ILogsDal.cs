using Core.DataAccess;
using Core.Entities.Concreate.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILogsDal: IEntityRepository<Logs>
    {
        void Add(object name,string LogType);
    }
}
