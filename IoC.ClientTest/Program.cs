using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Company.BoundedContext.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IoC.ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // http://docs.castleproject.org/Default.aspx?Page=MainPage&NS=Windsor&AspxAutoDetectCookieSupport=1

            //application starts...
            var container = new WindsorContainer();

            // adds and configures all components using WindsorInstallers from executing assembly

            container.Register(
                Classes
                .FromAssemblyInDirectory(new AssemblyFilter(@"D:\visual studio 2013\Projects\IoC\IoC.BoundedContext.Impl1\bin\debug"))
                .InNamespace("IoC.BoundedContext.Impl1", true)
                .ConfigureFor<IDoSomething>(a=>a.Named("CICCIO"))
                .WithServiceAllInterfaces()
            );
            container.Register(
                Classes
                .FromAssemblyInDirectory(new AssemblyFilter(@"D:\visual studio 2013\Projects\IoC\IoC.BoundedContext.Impl2\bin\debug"))
                .InNamespace("IoC.BoundedContext.Impl2", true)
                .ConfigureFor<IDoSomething>(a => a.Named("PASTICCIO"))
                .WithServiceAllInterfaces()
            );
            container.Register(
                Classes
                .FromThisAssembly()
                .InNamespace("IoC.ClientTest")
                .WithServiceFromInterface()
            );

            var doElse = container.Resolve<IDoSomethingElse>();
            doElse.SomethingElse();

            // instantiate and configure root component and all its dependencies and their dependencies and...
            var doSomething = container.Resolve<IDoSomething>("PASTICCIO");
            doSomething.DoSomething();

            // clean up, application exits
            container.Dispose();
        }
    }
}
