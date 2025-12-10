using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniFarm
{
    public interface IServiceContainer
    {
        public IEnumerable<object> Services { get; }
        public IServiceContainer Get<T>(out T service) where T : class;
        public T Get<T>(Type type) where T : class;
        public T Get<T>() where T : class;
        public IServiceContainer Set<T>(T service) where T : class;
        public IServiceContainer Set<T>(T service, Type type) where T : class;

    }

    public class ServiceContainer : IServiceContainer
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public IEnumerable<object> Services => _services.Values;

        public IServiceContainer Get<T>(out T service) where T : class
        {
            service = Get<T>();
            return this;
        }

        public T Get<T>(Type type) where T : class
        {
            if (_services.TryGetValue(type, out object obj))
                return obj as T;

            Debug.LogError($"ServiceContainer.Get: Register of type {type.FullName} not registered");
            return null;
        }

        public T Get<T>() where T : class
        {
            return Get<T>(typeof(T));
        }

        public IServiceContainer Set<T>(T service) where T : class
        {
            Set<T>(service, typeof(T));
            return this;
        }

        public IServiceContainer Set<T>(T service, Type type) where T : class
        {
            if (!_services.TryAdd(type, service))
                Debug.LogError($"ServiceContainer.Set: Register of type {type.FullName} already registered");

            return this;
        }
    }
}