using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class PublisherManager : IPublisherService
    {
        private IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public IResult Add(Publisher publisher)
        {
            _publisherDal.Add(publisher);
            return new SuccessResult(Messages.PublisherAddMessage);
        }
        public IResult Update(Publisher publisher)
        {
            _publisherDal.Update(publisher);
            return new SuccessResult(Messages.PublisherUpdateMessage);
        }
        public IResult Delete(Publisher publisher)
        {
            _publisherDal.Delete(publisher);
            return new SuccessResult(Messages.PublisherDeleteMessage);
        }
        public IDataResult<int> GetCount(string filter=null)
        {
            return filter == null
                ? new SuccessDataResult<int>(_publisherDal.GetCount(default))
                : new SuccessDataResult<int>(_publisherDal.GetCount(p => p.Summary.Contains(filter) || p.Title.Contains(filter)));
        }
        public IDataResult<List<Publisher>> GetList(string filter = null, int? page = null, int? count = null)
        {
            return filter != null ?
                new SuccessDataResult<List<Publisher>>(_publisherDal.GetList(p => p.Summary.Contains(filter) || p.Title.Contains(filter), page, count).ToList()) :
                new SuccessDataResult<List<Publisher>>(_publisherDal.GetList(default, page, count).ToList());
        }
        public IDataResult<Publisher> GetById(int publisherId)
        {
            return new SuccessDataResult<Publisher>(_publisherDal.Get(p => p.Id == publisherId));
        }
        public IDataResult<List<Publisher>> GetFilter(List<string> filter = null, int? page = null, int? count = null)
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetFilter(filter, page, count).ToList());
        }
    }
}
