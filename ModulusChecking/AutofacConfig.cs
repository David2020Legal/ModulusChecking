using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Finance.ModulusChecking.Database;
using Finance.ModulusChecking.Domain;
using Finance.ModulusChecking.Dto;
using Finance.ModulusChecking.Service;
using Module = System.Reflection.Module;

namespace ModulusChecking
{
    public class AutofacConfig
    {
        public static IContainer Configure(ContainerBuilder builder = null, HttpConfiguration config = null,
            params Module[] modules)
        {
            builder = builder ?? new ContainerBuilder();

            config = config ?? GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(typeof(AutofacConfig).Assembly);

            builder
                .RegisterType<WeightingsRepositoryDb>()
                .WithParameter("connectionString", @"Data Source =.\SQLExpress; Initial Catalog = Modulus; Integrated Security = True;" )
                .As<IWeightingsRepository>();
            builder.RegisterType<ModulusWeightingFactory>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        public static IEnumerable<ModulusWeightingDetails> CreateSingleRangeWeightingTableModulusTenPass()
        {
            return new List<ModulusWeightingDetails>()
            {
                new ModulusWeightingDetails("089000", "089999", ModulusCheckingMethod.StandardTen,
                    new List<IndiviualModulusWeighting>()
                    {
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(1), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(2), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(3), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(4), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(5), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(6), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(7), 7 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(8), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(9), 3 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(10), 7 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(11), 1),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(12), 3 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(13), 7 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(14), 1 )
                    })
            };
        }
    }
}