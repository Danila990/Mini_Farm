using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniFarm
{
    public static class SceneLoader
    {
        public static int СurrentLevel
        {
            get
            {
                if (_currentLevel < 0)
                    _currentLevel = 1;

                return _currentLevel;
            }

            set
            {
                if(_currentLevel < 0)
                    _currentLevel = 1;
                else
                    _currentLevel = value;
            }
        }

        private static int _currentLevel = -1;

        public static void LoadLevel(int indexLoad)
        {
            _currentLevel = indexLoad;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(1);
        }

        public static void LoadMainMenu()
        {
            _currentLevel = 0;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        }

        public static void RestartScene()
        {
            LoadLevel(СurrentLevel);
        }

        public static void LoadNextScene()
        {
            LoadLevel(СurrentLevel + 1);
        }
    }
}