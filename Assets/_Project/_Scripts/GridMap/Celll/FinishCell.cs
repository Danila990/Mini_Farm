namespace MiniFarm
{
    public class FinishCell : CellBase
    {
        [Inject] private FruitController _fruitController;

        public override CellType CellType => CellType.Finish;

        public override void Event()
        {
            _fruitController.CheckWinGame();
        }
    }
}