using YG;

namespace MiniFarm
{
    public class LoadCurrentLevelButton : UIButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            SceneLoader.LoadScene(YG2.saves.currentLevel);
        }
    }
}