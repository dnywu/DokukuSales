using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs;
using Ncqrs.Config;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Dokuku.Sales.Commands.Invoices;
using StructureMap;
using StructureMap.Configuration.DSL;
using Dokuku.Sales.Services;
using Dokuku.Sales.Repositories;
using Dokuku.Sales.Fixture.Screnarios.Fake;
using Ncqrs.Eventing.ServiceModel.Bus;
using Dokuku.Sales.Denormalizers.Invoices;

namespace Dokuku.Sales.Fixture
{
    public class Configuration
    {
        public static void Configure()
        {
            if (!NcqrsEnvironment.IsConfigured)
            {
                var config = new StructureMapConfiguration(x =>
                {
                    x.For<ICommandService>().Use(BuildCommandService());
                    //x.For<IEventBus>().Use(BuildEventBus());
                });
                NcqrsEnvironment.Configure(config);
            }
        }

        private static ICommandService BuildCommandService()
        {
            var service = new CommandService();
            service.RegisterExecutorsInAssembly(typeof(CreateInvoice).Assembly);
            service.RegisterExecutor(new CreateInvoiceService());
            service.RegisterExecutor(new ChangeInvoiceDateService());
            return service;
        }

        private static IEventBus BuildEventBus()
        {
            var bus = new InProcessEventBus();
            bus.RegisterHandler(new InvoiceCreatedDenormalizer());
            return bus;
        }
    }

    public class StructureMapConfiguration : IEnvironmentConfiguration
    {
        public StructureMapConfiguration(Action<IInitializationExpression> initialization = null, Action<ConfigurationExpression> configuration = null)
        {
            if (initialization != null)
            {
                ObjectFactory.Initialize(initialization);
            }
            if (configuration != null)
            {
                ObjectFactory.Configure(configuration);
            }
        }

        public bool TryGet<T>(out T result) where T : class
        {
            result = default(T);


            var foundInstance = ObjectFactory.Container.TryGetInstance<T>();

            if (foundInstance != null)
            {
                result = foundInstance;
            }

            return result != null;
        }
    }
}
