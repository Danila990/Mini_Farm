using UnityEngine;

namespace MiniFarm
{
    public abstract class ServiceScore : MonoBehaviour
    {
        protected Transform _parrentScope;

        private void Awake()
        {
            _parrentScope = new GameObject("Scope Logick").transform;
            BuildServices(ServiceLocator.Container);
            ServiceLocator.InjectContainer();
        }

        protected abstract void BuildServices(IServiceContainer serviceContainer);

    }
}