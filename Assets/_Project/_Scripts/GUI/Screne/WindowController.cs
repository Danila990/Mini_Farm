using System.Linq;
using UnityEngine;

namespace MiniFarm
{
    public class WindowController : MonoBehaviour
    {
        [SerializeField] private WindowType _startWindow;
        [SerializeField] private Window[] _windows;

        private Window _currentWindow;

        private void Start()
        {
            ShowWindow(_startWindow);
        }

        public void ShowWindow(WindowType pageType)
        {
            HideWindow();

            _currentWindow = GetWindow(pageType);
            _currentWindow.Show();
        }

        public void HideWindow()
        {
            if (_currentWindow != null)
            {
                _currentWindow?.Hide();
                Destroy(_currentWindow.gameObject);
                _currentWindow = null;
            }
        }

        private Window GetWindow(WindowType windowType)
        {
            Window returnWindow = _windows.FirstOrDefault(page => page.windowType == windowType);
            returnWindow = Instantiate(returnWindow, transform);
            returnWindow.Setup();
            if (returnWindow == null)
                Debug.LogError("Window find Error: " + windowType);

            return returnWindow;
        }
    }
}