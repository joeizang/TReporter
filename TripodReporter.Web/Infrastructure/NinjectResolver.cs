using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using TripodReporter.Domain.Repositories;
using TripodReporter.Domain.Entities;
using TripodReporter.Domain.Contexts;
using System.Data.Entity;

namespace TripodReporter.Web.Infrastructure
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            addBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void addBindings()
        {
            ////throw new NotImplementedException();
            //Mock<IRepository<Insurer>> mock = new Mock<IRepository<Insurer>>();
            //mock.Setup(m => m.GetAll()).Returns(new List<Insurer>{
            //    new Insurer { Name="FakeInsurer1"},
            //    new Insurer { Name="FakeInsurer1"},
            //    new Insurer { Name="FakeInsurer1"},
            //    new Insurer { Name="FakeInsurer1"},
            //    new Insurer { Name="FakeInsurer1"}
            //}.AsQueryable());

            //mock.Setup(n => n.GetById(It.Is<int>(o => o == 1 || o == 2 || o == 3 || o == 4 || o == 5))
            //                            ).Returns<int>(p => new Insurer { InsurerId = p, Name = string.Format("Fake Moqs", p) });
            ////var insurerrepo = mock.Object;

            kernel.Bind<ReporterContext>().ToSelf().InRequestScope<ReporterContext>();
            kernel.Bind<IRepository<Insurer>>().To<ReporterRepository<Insurer>>();
            kernel.Bind<IRepository<Client>>().To<ReporterRepository<Client>>();
            kernel.Bind<IRepository<Policy>>().To<ReporterRepository<Policy>>();
            
        }
    }
}