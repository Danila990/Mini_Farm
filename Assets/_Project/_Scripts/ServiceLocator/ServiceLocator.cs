using UnityEngine;

namespace MiniFarm
{
    public class ServiceLocator : MonoBehaviour
    {
        [SerializeField] private bool _isAutoBuild = true;

        private bool _isBuilded = false;
        private IInjector _injector;
        private IBuilder _builder;
        private static IContainer _container;

        public static IContainerResolver Resolver => _container;

        protected virtual void Awake()
        {
            if (_isAutoBuild)
                Build();
        }

        public void Build()
        {
            if (_isBuilded) return;

            _isBuilded = true;
            _container = new Container();
            _builder = new Builder(_container);
            _injector = new Injector(_container);
            Configurate(_builder);
            InjectContainer();
        }

        private void InjectContainer()
        {
            foreach (var service in _container.Services)
                _injector.InjectMono(service);
        }

        public virtual void Configurate(IBuilder builder) { }

        private void OnDestroy()
        {
            _injector = null;
            _builder = null;
            _container = null;
        }
    }
}