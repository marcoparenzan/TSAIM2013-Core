using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ITS.IoC.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.IoC.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            // adds and configures all components using WindsorInstallers from executing assembly


            container.Register(
                Component
                .For<DirectoryInfo>()
                .Instance(new DirectoryInfo(@"C:\temp"))
            );
            container.Register(
                Classes
                .FromAssemblyInDirectory(
                    new AssemblyFilter(
                        System.Environment.CurrentDirectory))
                //.InNamespace("ITS.IoC.FileSystem")
                .InNamespace("ITS.IoT.Domain.EntityFramework")
                .WithServiceAllInterfaces()
            );

            var repository = container.Resolve<IMyEntityRepository>();
            var entity = repository.GetById("1");
        }
    }
}
