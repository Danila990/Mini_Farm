
using UnityEngine;

namespace MiniFarm
{
    public class MenuScope : ServiceLocator
    {
        [Header("Scope")]
        [SerializeField] private WindowController _windowController;
        [SerializeField] private AudioSystem _audioSystem;


        public override void Configurate(IBuilder builder)
        {
            builder.Register(_windowController);
            builder.Instantiate(_audioSystem);
        }
    }
}