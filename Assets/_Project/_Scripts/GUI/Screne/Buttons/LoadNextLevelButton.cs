using UnityEngine.UI;

namespace MiniFarm
{
    public class LoadNextLevelButton : UIButton
    {
        protected override void Start()
        {
            base.Start();

            int levelCount = ServiceLocator.Resolver.Resolve<LevelSettings>().LevelCount;
            if (levelCount == SceneLoader.СurrentLevel)
                GetComponent<Button>().interactable = false;
        }

        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            SceneLoader.LoadNextScene();
        }
    }
}