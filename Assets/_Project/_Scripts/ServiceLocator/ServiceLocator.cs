using System;
using UnityEngine;

namespace MiniFarm
{
    public interface IServiceLocator
    {
        public IServiceLocator Get<T>(out T service) where T : class;
        public T Get<T>(Type type) where T : class;
        public T Get<T>() where T : class;
        public IServiceLocator Set<T>(T service) where T : class;
        public IServiceLocator Set<T>(T service, Type type) where T : class;
    }

    public static class ServiceLocator
    {
        private static IServiceContainer _container;
        private static IServiceInjector _injector;
        private static bool _isInjected = false;

        public static IServiceContainer Container
        {
            get
            {
                if (_container == null)
                    _container = new ServiceContainer();

                return _container;
            }
        }

        public static IServiceInjector Injector
        {
            get
            {
                if (_injector == null)
                    _injector = new ServiceInjector(Container);

                return _injector;
            }
        }

        public static void InjectContainer()
        {
            if(_isInjected) return;

            _isInjected = true;

            foreach (var service in _container.Services)
                Injector.InjectMono(service);
        }

        public static IServiceContainer Get<T>(out T service) where T : class => Container.Get<T>(out service);
        public static T Get<T>(Type type) where T : class => Container.Get<T>(type);
        public static T Get<T>() where T : class => Container.Get<T>();
        public static IServiceContainer Set<T>(T service) where T : class => Container.Set<T>(service);
        public static IServiceContainer Set<T>(T service, Type type) where T : class => Container.Set<T>(service, type);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void ResetContainer()
        {
            _container = null;
            _injector = null;
            _isInjected = false;
        }
    }
}