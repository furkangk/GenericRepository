
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect:MethodInterception
    {
        private ILogsDal logsDal;
        private string logType;
        public LogAspect(string name)
        {
            logsDal = new EfLogsDal();
            logType = name;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var detail = GetLogDetail(invocation);
            var Json = JsonConvert.SerializeObject(detail);
            logsDal.Add(Json,logType);
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
