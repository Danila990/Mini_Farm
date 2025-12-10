namespace MiniFarm
{
    public class RockCell : Cell
    {
        public override void Event()
        {
            ServiceLocator.Get<GameManager>().LossGame();
        }
    }

    public enum RockType
    {
        Rock_1 = 0,
        Rock_2 = 1,
        Rock_3 = 2,
    }
}