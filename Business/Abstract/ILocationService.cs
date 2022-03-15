using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationService
    {
        IDataResult<Location> GetById(int locationId);
        IDataResult<List<Location>> GetList(string filter=null,int? page=null, int? count=null);
        IDataResult<List<Location>> GetFilter(List<string> filter = null, int? page = null, int? count = null);

        IDataResult<int> GetCount(string filter=null);
        IResult Add(Location location);
        IResult Delete(Location location);
        IResult Update(Location location);
    }
}
