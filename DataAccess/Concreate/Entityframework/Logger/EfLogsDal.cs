using Core.DataAccess.EntityFramework;
using Core.Entities.Concreate.Logger;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Entityframework.Logger
{
    public class EfLogsDal : EfEntityRepositoryBase<Logs, MiaTeknoloji>, ILogsDal
    {
        public void Add(object name,string logType)
        {
            using (var context = new MiaTeknoloji())
            {
                Logs logs = new Logs();
                logs.Audit = logType;
                logs.Date = DateTime.Now;
                logs.Detail = name.ToString();
                var l = context.Entry(logs);
                l.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
