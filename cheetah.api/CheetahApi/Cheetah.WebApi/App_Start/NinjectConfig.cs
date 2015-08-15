using System;
using System.Reflection;
using Cheetah.DataAccess;
using Cheetah.Security.Implementation;
using Ninject;

namespace Cheetah.WebApi
{
    public class NinjectConfig
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Load<DataAccessModule>();
            kernel.Load<SecurityModule>();
        }
    }
}