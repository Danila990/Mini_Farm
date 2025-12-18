using UnityEngine;

namespace MiniFarm
{
    public class PauseWindow : Window
    {
        public override void Show()
        {
            ServiceLocator.Resolver.Resolve<GameManager>().PauseGame();
            base.Show();
        }

        public override void Hide()
        {
            ServiceLocator.Resolver.Resolve<GameManager>().PlayGame();
            base.Hide();
        }
    }
}