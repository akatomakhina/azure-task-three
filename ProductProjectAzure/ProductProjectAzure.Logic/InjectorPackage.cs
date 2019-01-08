using Castle.DynamicProxy;
using ProductProjectAzure.DataAccess.Common.Repositories;
using ProductProjectAzure.DataAccess.Context;
using ProductProjectAzure.DataAccess.Repositories;
using ProductProjectAzure.Logic.Common.Services;
using ProductProjectAzure.Logic.Logging;
using ProductProjectAzure.Logic.Services;
using ProductProjectAzure.Logic.Validator;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace ProductProjectAzure.Logic
{
    public class InjectorPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterProductServices(container);
        }

        private void RegisterProductServices(Container container)
        {
            container.Register(() =>
                new ProxyGenerator().CreateInterfaceProxyWithTargetInterface<IProductService>(
                    container.GetInstance<ProductService>(),
                    container.GetInstance<ValidatorInterceptor>(),
                    container.GetInstance<Log4netInterceptor>()
                ));
            container.Register<ProductProjectContext>();

            //container.Register<IProductService, ProductService>();
            container.Register<IProductRerository, ProductDbRepository>();
            container.Register<ITransactionHistoryRepository, TransactionHistoryRepository>();
        }
    }
}
