
namespace MiniFarm
{
    public class RestartButton : UIButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            ServiceLocator.Resolver.Resolve<GameManager>().RestartGame();
        }
    }
}