namespace MiniFarm
{
    public class LoadMainMenuButton : UIButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            SceneLoader.LoadMainMenu();
        }
    }
}