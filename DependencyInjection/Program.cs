using DependencyInjection.Tools;
using DependencyInjection.Services;
using System;
using DependencyInjection.Services.Interfaces;
using DependencyInjection.Services.Implementations;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new DIProvider();
            //ProveSingletonWithImplementation(services);
            //ProveTransient(services);
            //ProveSingletonWithoutImplemenation(services);
            ProveSingletonWithInterface(services);
            //Futher Singleton Things
        }

        public static void ProveSingletonWithImplementation(DIProvider services)
        {
            var fooServiceSingleton = new FooService();

            services.RegisterSingleton<FooService>(fooServiceSingleton);

            //since its singleton, should be the same time
            var service = services.GetService<FooService>();
            var service2 = services.GetService<FooService>();

            Console.WriteLine("----------------Singleton-------------------");
            Console.WriteLine(service.RandomGuid);
            Console.WriteLine(service2.RandomGuid);

            Console.WriteLine("");
        }

        public static void ProveTransient(DIProvider services)
        {
            Console.WriteLine("----------------Transient-------------------");

            //since transient, should be two differnet Guids
            services.RegisterTransient<GooService>();
            var gooServiceTransient1 = services.GetService<GooService>();
            var gooServiceTransient2 = services.GetService<GooService>();

            Console.WriteLine(gooServiceTransient1.RandomGuid);
            Console.WriteLine(gooServiceTransient2.RandomGuid);


            Console.WriteLine("");

        }

        public static void ProveSingletonWithoutImplemenation(DIProvider services)
        {
            Console.WriteLine("------Singleton without implementation------");
            //singleton, without providing implemenation
            services.RegisterSingleton<HooService>();

            var hooService1 = services.GetService<HooService>();
            var hooService2 = services.GetService<HooService>();

            Console.WriteLine(hooService1.RandomGuid);
            Console.WriteLine(hooService2.RandomGuid);
        }

        public static void ProveSingletonWithInterface(DIProvider services)
        {

            services.RegisterSingleton<IDummyService, DummyOneService>();
            var dummyService1 = services.GetService<IDummyService>();
            var dummyService2 = services.GetService<IDummyService>();

            dummyService1.PrintStoredNumber();
            dummyService2.PrintStoredNumber();

        }
    }
}