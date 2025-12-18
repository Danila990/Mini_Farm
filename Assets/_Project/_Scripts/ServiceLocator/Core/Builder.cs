using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MiniFarm
{
    public interface IBuilder
    {
        public void Instantiate<T>(T mono, Transform parrent = null) where T : MonoBehaviour;
        public void Instantiate<T>(Transform parrent = null) where T : MonoBehaviour;
        public void Instantiate<T, I>(Transform parrent = null) where T : MonoBehaviour, I where I : class;
        public void Register<T>(T registerClass) where T : class;
        public void Register<T>() where T : class, new();
    }

    public class Builder : IBuilder
    {
        private IContainerRegister _register;

        public Builder(IContainerRegister register)
        {
            _register = register;
        }

        public void Instantiate<T>(T mono, Transform parrent = null) where T : MonoBehaviour
        {
            T newMono = Object.Instantiate(mono, parrent);
            _register.Register<T>(newMono);
        }

        public void Instantiate<T>(Transform parrent = null) where T : MonoBehaviour
        {
            T newMono = new GameObject(typeof(T).Name).AddComponent<T>();
            newMono.transform.parent = parrent;
            _register.Register<T>(newMono);
        }

        public void Instantiate<T,I>(Transform parrent = null) where T : MonoBehaviour, I where I : class
        {
            T newMono = new GameObject(typeof(T).Name).AddComponent<T>();
            newMono.transform.parent = parrent;

            if (newMono is I)
                _register.Register<I>(newMono);
            else
                Debug.LogError($"{typeof(T).Name} does not implement interface {typeof(I).Name}");
        }

        public void Register<T>(T registerClass) where T : class
        {
            _register.Register<T>(registerClass);
        }

        public void Register<T>() where T: class, new()
        {
            T newClass = new T();
            _register.Register<T>(newClass);
        }
    }
}