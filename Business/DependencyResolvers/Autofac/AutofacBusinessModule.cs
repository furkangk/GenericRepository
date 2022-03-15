using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concreate;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.jwt;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework;
using DataAccess.Concreate.Entityframework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<EfBookDal>().As<IBookDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<BookImageManager>().As<IBookImageService>();
            builder.RegisterType<EfBookImageDal>().As<IBookImageDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<PublisherManager>().As<IPublisherService>();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<LocationManager>().As<ILocationService>();
            builder.RegisterType<EfLocationDal>().As<ILocationDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<EfLogsDal>().As<ILogsDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
