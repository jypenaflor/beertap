using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using iq.mnl.beertap.Repository;
using iq.mnl.beertap.Repository.Context;

namespace iq.mnl.beertap.WebApi.Infrastructure.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBeerTapContext>().ImplementedBy<BeerTapContext>().LifestyleSingleton());
            container.Register(Component.For<IOfficeRepository>().ImplementedBy<OfficeRepository>().LifestyleSingleton());
            container.Register(Component.For<IBeerTapRepository>().ImplementedBy<BeerTapRepository>().LifestyleSingleton());

        }

    }
}