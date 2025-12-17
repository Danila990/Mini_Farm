using UnityEngine;

namespace MiniFarm
{
    public class Window : MonoBehaviour
    {
        [field: SerializeField] public WindowType windowType { get; private set; }

        private AlphaAnimation _alphaAnimator;

        protected virtual void Awake()
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