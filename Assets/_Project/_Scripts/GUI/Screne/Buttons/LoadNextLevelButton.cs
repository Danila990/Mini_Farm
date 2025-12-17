using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MiniFarm
{
    public class LoadNextLevelButton : UIButton
    {
        protected override void Start()
        {
            base.Start();

            if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
                GetComponent<Button>().interactable = false;
        }

        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            SceneLoader.LoadNextScene();
        }
    }
}