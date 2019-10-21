using AutoMapper;
using Business_Layer.DI;
using Ninject;
using System;
using System.Collections.Generic;
using Web.Mappper;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace Web.DI
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public IKernel Kernel => _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            InitializeBindings(_kernel);
        }

        private static void InitializeBindings(IKernel kernel)
        {
            var mapperConfiguration = MapperModule.Configure();
            kernel.Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            kernel.Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));

            BLDependencyResolver.Initialize(kernel);
        }

        public object GetService(Type serviceType) => _kernel.TryGet(serviceType);
        public IEnumerable<object> GetServices(Type serviceType) => _kernel.GetAll(serviceType);
    }
}