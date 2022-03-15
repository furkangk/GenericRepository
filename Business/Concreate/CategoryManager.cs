using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAddMessage);
        }
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdateMessage);
        }
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleteMessage);
        }
        public IDataResult<int> GetCount(string filter=null)
        {
            return filter == null
                ? new SuccessDataResult<int>(_categoryDal.GetCount(default))
                : new SuccessDataResult<int>(_categoryDal.GetCount(c => c.Title.Contains(filter)));
        }
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == categoryId));
        }

        public IDataResult<List<Category>> GetList(string filter = null, int? page = null, int? count = null)
        {
            return filter != null ?
            new SuccessDataResult<List<Category>>(_categoryDal.GetList(c => c.Title.Contains(filter), page, count).ToList()) :
            new SuccessDataResult<List<Category>>(_categoryDal.GetList(default, page, count).ToList());
        }

        public IDataResult<List<Category>> GetFilter(List<string> filter, int? page = null, int? count = null)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetFilter(filter,page,count).ToList());
        }
    }
}
