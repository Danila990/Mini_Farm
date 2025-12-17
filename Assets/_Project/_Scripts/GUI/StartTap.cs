using UnityEngine;
using UnityEngine.UI;

namespace MiniFarm
{
    public class StartTap : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(Tap);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Tap);
        }

        public void Tap()
        {
            ServiceLocator.Resolver.Resolve<WindowController>().ShowWindow(WindowType.Game_GUI);
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            ServiceLocator.Resolver.Resolve<GameManager>().StartGame();
        }
    }
}