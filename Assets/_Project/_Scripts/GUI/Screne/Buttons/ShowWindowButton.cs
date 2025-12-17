using UnityEngine;

namespace MiniFarm
{
    public class ShowWindowButton : UIButton
    {
        [SerializeField] private WindowType _openWindow;

        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            ServiceLocator.Resolver.Resolve<WindowController>().ShowWindow(_openWindow);
        }
    }
}