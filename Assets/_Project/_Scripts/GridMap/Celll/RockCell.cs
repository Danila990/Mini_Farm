namespace MiniFarm
{
    public class RockCell : Cell
    {
        public override void Event()
        {
            ServiceLocator.Get<GameManager>().LossGame();
        }
    }
}