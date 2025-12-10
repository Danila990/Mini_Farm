using UnityEngine.SceneManagement;

namespace MiniFarm
{
    public static  class SceneLoader
    {
        public static void LoadScene(int indexLoad)
        {
            if(SceneManager.sceneCountInBuildSettings <= indexLoad) return;

            SceneManager.LoadScene(indexLoad);
        }

        public static void RestartScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void LoadNextScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}