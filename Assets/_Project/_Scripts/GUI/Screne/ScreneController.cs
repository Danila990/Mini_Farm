using System.Linq;
using UnityEngine;

namespace MiniFarm
{
    public class ScreneController : MonoBehaviour
    {
        [SerializeField] private Window[] _windows;

        private Window _currentWindow;

        public void ShowWindow(WindowType pageType)
        {
            HideWindow();

            GetWindow(pageType).Show();
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
            if (returnWindow == null)
                Debug.LogError("Window find Error: " + windowType);

            return returnWindow;
        }
    }
}