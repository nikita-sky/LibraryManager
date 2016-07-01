using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LightInject;

namespace LibraryManager.Shared.IoC
{
    public class LightInjectContainer: ServiceContainer, IServiceContainer
    {
        private readonly LightInject.ServiceContainer _container = new LightInject.ServiceContainer();

        public override void EnableMvc()
            => _container.EnableMvc();

        public void RegisterInstance<TServcie>(TServcie instance)
            => _container.RegisterInstance(instance);

        public void RegisterPerRequest<TService, TImpl>() where TImpl: TService
            => _container.Register<TService, TImpl>(PerRequestLifeTime);

        public void RegisterPerRequest<TServcie>()
            => _container.Register<TServcie>(PerRequestLifeTime);

        public void RegisterPerRequest(Type servcieType) => _container.Register(servcieType, PerRequestLifeTime);

        public void RegisterSingleton<TService, TImpl>() where TImpl : TService
            => _container.Register<TService, TImpl>();

        public void RegisterSingleton<TServcie>()
            => _container.Register<TServcie>();

        public void RegisterAssembly(Assembly assembly)
            => _container.RegisterAssembly(assembly);

        public void RegisterAssemblyPerRequest(Assembly assembly)
            => _container.RegisterAssembly(assembly, () => PerRequestLifeTime);

        public T GetInstance<T>()
            => _container.GetInstance<T>();

        public IEnumerable<T> GetAllInstances<T>()
            => _container.GetAllInstances<T>();

        private static ILifetime PerRequestLifeTime => new PerRequestLifeTime();
    }
}