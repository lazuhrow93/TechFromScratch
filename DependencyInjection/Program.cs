using DependencyInjection.Tools;
using DependencyInjection.Services;
using System;
using MyClasses.Implementations;
using MyClasses.Interfaces;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new DIContainer();
            var services = container.GetProvider();

            //ProveSingletonWithImplementation(services);
            //ProveSingletonWithoutImplemenation(services);
            //ProveTransient(services);
            //ProveSingletonWithInterface(container);
            //ProveTransientWithInterface(container);
            ProveNestedSingletonsWithInterface(container);

        }

        public static void ProveSingletonWithImplementation(DIContainer container)
        {
            var fooServiceSingleton = new FooService();

            container.RegisterSingleton<FooService>(fooServiceSingleton);
            var services = container.GetProvider();

            //since its singleton, should be the same time
            var service = services.GetService<FooService>();
            var service2 = services.GetService<FooService>();

            Console.WriteLine("----------------Singleton-------------------");
            Console.WriteLine(service.RandomGuid);
            Console.WriteLine(service2.RandomGuid);

            Console.WriteLine("");
        }
        
        public static void ProveSingletonWithoutImplemenation(DIContainer container)
        {
            Console.WriteLine("------Singleton without implementation------");
            //singleton, without providing implemenation
            container.RegisterSingleton<HooService>();
            var services = container.GetProvider();

            var hooService1 = services.GetService<HooService>();
            var hooService2 = services.GetService<HooService>();

            Console.WriteLine(hooService1.RandomGuid);
            Console.WriteLine(hooService2.RandomGuid);
        }

        public static void ProveTransient(DIContainer container)
        {
            Console.WriteLine("----------------Transient-------------------");

            //since transient, should be two differnet Guids
            container.RegisterTransient<GooService>();
            var services = container.GetProvider();
            var gooServiceTransient1 = services.GetService<GooService>();
            var gooServiceTransient2 = services.GetService<GooService>();

            Console.WriteLine(gooServiceTransient1.RandomGuid);
            Console.WriteLine(gooServiceTransient2.RandomGuid);


            Console.WriteLine("");

        }

        public static void ProveSingletonWithInterface(DIContainer container)
        {
            container.RegisterSingleton<IDummyService, DummyOneService>();
            var services = container.GetProvider();
            var dummyService1 = services.GetService<IDummyService>();
            var dummyService2 = services.GetService<IDummyService>();

            Console.WriteLine("Before:");
            dummyService1.PrintStoredNumber();
            dummyService1.TotalRefreshes();


          
            dummyService2.Refresh(); //since it is a singleton, it should also affect dummyService1
            dummyService2.Refresh();


            Console.WriteLine("After:");
            dummyService1.PrintStoredNumber();
            dummyService1.TotalRefreshes();

        }

        public static void ProveTransientWithInterface(DIContainer container)
        {
            container.RegisterTransient<IDummyService, DummyOneService>();

            var provider = container.GetProvider();
            var instance1 = provider.GetService<IDummyService>();
            var instance2 = provider.GetService<IDummyService>();
            var instance3 = provider.GetService<IDummyService>();

            instance1.PrintStoredNumber();
            instance2.PrintStoredNumber();
            instance3.PrintStoredNumber();
        }

        public static void ProveNestedSingletonsWithInterface(DIContainer container)
        {
            container.RegisterSingleton<IDummyService, DummyTwoService>(); //DummyTwoService needs a IGuidProvider
            container.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>(); //DummyTwoService needs a IGuidProvider
            var provider = container.GetProvider();

            var instance1 = provider.GetService<IDummyService>();
            var instance2 = provider.GetService<IDummyService>();
            var instance3 = provider.GetService<IDummyService>();

            instance1.PrintStoredNumber();
            instance2.PrintStoredNumber();
            instance3.PrintStoredNumber();
        }
    }
}