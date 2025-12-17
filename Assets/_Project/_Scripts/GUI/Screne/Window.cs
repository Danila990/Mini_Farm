using UnityEngine;

namespace MiniFarm
{
    [RequireComponent(typeof(AlphaAnimation))]
    public class Window : MonoBehaviour
    {
        [field: SerializeField] public WindowType windowType { get; private set; }

        private AlphaAnimation _alphaAnimator;

        public virtual void Setup()
        {
            _alphaAnimator = GetComponent<AlphaAnimation>();
        }

        public virtual void Show()
        {
            _alphaAnimator.Show();
        }

        public virtual void Hide()
        {
            _alphaAnimator.Hide();
        }
    }
}