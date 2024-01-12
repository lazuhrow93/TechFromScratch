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

            var fooServiceSingleton = new FooService();

            services.RegisterSingleton<FooService>(fooServiceSingleton);
            //services.RegisterTransient<FooService>();

            //since its singleton, should be the same time
            var service = services.GetService<FooService>();
            var service2 = services.GetService<FooService>();

            Console.WriteLine("----------------Singleton-------------------");
            Console.WriteLine(service.RandomGuid);
            Console.WriteLine(service2.RandomGuid);

            Console.WriteLine("");
            Console.WriteLine("----------------Transient-------------------");

            //since transient, should be two differnet Guids
            services.RegisterTransient<GooService>();
            var gooServiceTransient1 = services.GetService<GooService>(); 
            var gooServiceTransient2 = services.GetService<GooService>();

            Console.WriteLine(gooServiceTransient1.RandomGuid);
            Console.WriteLine(gooServiceTransient2.RandomGuid);


            Console.WriteLine("");
            Console.WriteLine("------Singleton without implementation------");
            //singleton, without providing implemenation
            services.RegisterSingleton<HooService>();

            var hooService1 = services.GetService<HooService>();
            var hooService2 = services.GetService<HooService>();

            Console.WriteLine(hooService1.RandomGuid);
            Console.WriteLine(hooService2.RandomGuid);

            //Futher Singleton Things
            services.RegisterSingleton<IDummyService, DummyOneService>();


        }
    }
}