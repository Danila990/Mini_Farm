using UnityEngine;

namespace MiniFarm
{
    public class StartTap : MonoBehaviour
    {
        [SerializeField] private GameObject _nextPanel;

        public void Tap()
        {
            gameObject.SetActive(false);
            _nextPanel.SetActive(true);
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            ServiceLocator.Resolver.Resolve<GameManager>().StartGame();
        }
    }
}