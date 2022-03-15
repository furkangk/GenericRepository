using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IDataResult<List<Publisher>> GetList(string filter = null, int? page = null, int? count = null);
        IDataResult<List<Publisher>> GetFilter(List<string> filter = null, int? page = null, int? count = null);

        IDataResult<int> GetCount(string filter = null);
        IDataResult<Publisher> GetById(int publisherId);
        IResult Add(Publisher publisher);
        IResult Delete(Publisher publisher);
        IResult Update(Publisher publisher);
    }
}
