using Business.Abstract;
using Business.BusinessAspect;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cache;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class LocationManager : ILocationService
    {
        private ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal,IHttpContextAccessor httpContextAccessor)
        {
            _locationDal = locationDal;
        }

        [CacheRemoveAspect("ILocationService.GetList")]
        [ValidationAspect(typeof(LocationValidator), Priority = 1)]
        public IResult Add(Location location)
        {
            _locationDal.Add(location);
            return new SuccessResult(Messages.LocationAddMessage);
        }
        
        [CacheRemoveAspect("ILocationService.GetList")]
        [ValidationAspect(typeof(LocationValidator), Priority = 1)]
        public IResult Update(Location location)
        {
            _locationDal.Update(location);
            return new SuccessResult(Messages.LocationUpdateMessage);
        }

        [CacheRemoveAspect("ILocationService.GetList")]
        public IResult Delete(Location location)
        {
            _locationDal.Delete(location);
            return new SuccessResult(Messages.LocationDeleteMessage);
        }
        [SecuredOperation("GetList")]
        //  [PerformanceAspect(5)]
        [LogAspect("INFO")]
        public IDataResult<Location> GetById(int locationId)
        {
            return new SuccessDataResult<Location>(_locationDal.Get(l => l.Id == locationId));
        }
        public IDataResult<int> GetCount(string filter=null)
        {
            return filter == null
                ? new SuccessDataResult<int>(_locationDal.GetCount(default))
                : new SuccessDataResult<int>(_locationDal.GetCount(l => l.Block.Contains(filter) || l.Floor.Contains(filter) || l.Shelf.Contains(filter)));
        }
        [CacheAspect(duration: 10)]
        public IDataResult<List<Location>> GetList(string filter=null, int? page=null, int? count=null)
        {
            return filter != null ?
                new SuccessDataResult<List<Location>>(_locationDal.GetList(l => l.Block.Contains(filter) || l.Floor.Contains(filter) || l.Shelf.Contains(filter) || l.Title.Contains(filter), page, count).ToList()) :
                new SuccessDataResult<List<Location>>(_locationDal.GetList(default, page, count).ToList());
        }
        public IDataResult<List<Location>> GetFilter(List<string> filter = null, int? page = null, int? count = null)
        {
            return new SuccessDataResult<List<Location>>(_locationDal.GetFilter(filter, page, count).ToList());
        }
    }
}
