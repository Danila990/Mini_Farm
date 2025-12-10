using UnityEngine;

namespace MiniFarm
{
    public abstract class ServiceScore : MonoBehaviour
    {
        private void Awake()
        {
            BuildServices(ServiceLocator.Container);
            ServiceLocator.InjectContainer();
        }

        protected abstract void BuildServices(IServiceContainer serviceContainer);

    }
}