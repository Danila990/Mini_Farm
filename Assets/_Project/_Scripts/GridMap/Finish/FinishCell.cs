using UnityEngine;

namespace MiniFarm
{
    public class FinishCell : CellBase
    {
        [field: SerializeField] public Finish finish { get; private set; }

        [Inject] private FruitController _fruitController;

        public override CellType CellType => CellType.Finish;

        private void Start()
        {
            finish.DeactivateFlag();
            _fruitController.OnFruit += OnStateFlag;
        }

        private void OnDestroy()
        {
            _fruitController.OnFruit -= OnStateFlag;
        }

        public override void Event()
        {
            if(_fruitController.CheckWinGame())
                ServiceLocator.Resolver.Resolve<GameManager>().WinGame();
        }

        private void OnStateFlag(int counFruit)
        {
            if(counFruit <= 0)
                finish.ActivateFlag();
        }
    }
}