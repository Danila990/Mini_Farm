using YG;

namespace MiniFarm
{
    public class LoadCurrentLevelButton : UIButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            SceneLoader.LoadLevel(YG2.saves.CurrentLevel);
        }
    }
}