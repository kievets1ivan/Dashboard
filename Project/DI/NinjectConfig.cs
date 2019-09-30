using Business_Layer.Services;
using DAL.UoW;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.DI
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ITicketService>().To<TicketService>();
        }
    }
}