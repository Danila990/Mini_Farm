using UnityEngine;

namespace MiniFarm
{
    public class LocalizationSystem
    {
        private static LocalizationContainer _container
        {
            get
            {
                if (_container == null)
                    _container = Resources.Load<LocalizationContainer>(nameof(LocalizationContainer));

                return _container;
            }
            set { _container = value; }
        }

        public void Init()
        {
            if (_container == null)
                _container = Resources.Load<LocalizationContainer>(nameof(LocalizationContainer));
        }

        public string GetText(int id)
        {
            var text = _container.GetText(id);
            return text.En;
        }
    }
}