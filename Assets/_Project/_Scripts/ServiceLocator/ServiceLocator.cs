using System;
using System.Collections.Generic;
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
        private static IServiceContainer _container = new ServiceContainer();
        private static IServiceInjector _injector;
        private static bool _isInjected = false;

        public static IServiceContainer Container => _container;

        public static IServiceInjector Injector
        {
            get
            {
                if (_injector == null)
                    _injector = new ServiceInjector(_container);

                return _injector;
            }
        }

        public static void InjectContainer()
        {
            if(_isInjected) return;

            _isInjected = true;

            foreach (var service in _container.Services)
                _injector.Inject(service);
        }

        public static IServiceContainer Get<T>(out T service) where T : class => _container.Get<T>(out service);
        public static T Get<T>(Type type) where T : class => _container.Get<T>(type);
        public static T Get<T>() where T : class => _container.Get<T>();
        public static IServiceContainer Set<T>(T service) where T : class => _container.Set<T>(service);
        public static IServiceContainer Set<T>(T service, Type type) where T : class => _container.Set<T>(service, type);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void ResetContainer()
        {
            _container = null;
            _isInjected = false;
        }
    }
}