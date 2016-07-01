using System;
using System.Collections.Generic;
using System.Reflection;

namespace LibraryManager.Shared.IoC
{
    public interface IServiceContainer
    {
        void RegisterInstance<TServcie>(TServcie instance);
        void RegisterPerRequest<TService, TImpl>() where TImpl : TService;
        void RegisterPerRequest<TService>();
        void RegisterPerRequest(Type servcieType);
        void RegisterSingleton<TService, TImpl>() where TImpl : TService;
        void RegisterSingleton<TServcie>();

        void RegisterAssembly(Assembly assembly);
        void RegisterAssemblyPerRequest(Assembly assembly);

        T GetInstance<T>();
        IEnumerable<T> GetAllInstances<T>();
    }
}