using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface ICategoryService
    {
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<Category>> GetList(string filter = null, int? page = null, int? count = null);
        IDataResult<int> GetCount(string filter = null);
        IDataResult<List<Category>> GetFilter(List<string> filter = null, int? page = null, int? count = null);
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
