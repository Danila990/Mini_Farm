using System;
using System.Linq;

namespace MiniFarm
{
    public class FruitController
    {
        public event Action<int> OnFruit;

        private FruitCell[] _fruitCells;

        public int maxFruit { get; private set; }
        public int currentCountFruit { get; private set; }
        public FruitType currentFruitType { get; private set; }

        [Inject]
        public void Setup(IGridMap gridMap)
        {
            maxFruit = gridMap.FindCells<FruitCell>(CellType.Fruit).Length;
            currentCountFruit = maxFruit;
            _fruitCells = gridMap.FindCells<FruitCell>(CellType.Fruit);
            currentFruitType = GetActualFruitTypes()[0];
        }

        public void FruitUp(FruitType fruitType)
        {
            if (currentFruitType == fruitType)
            {
                currentCountFruit--;
                OnFruit?.Invoke(currentCountFruit);
            }
            else
                ServiceLocator.Resolver.Resolve<GameManager>().LossGame();
        }

        public void CheckWinGame()
        {
            if(currentCountFruit <= 0)
                ServiceLocator.Resolver.Resolve<GameManager>().WinGame();
        }

        public FruitType[] GetActualFruitTypes()
        {
            return _fruitCells
                    .Select(cell => cell.fruit.fruitType)
                    .Distinct()
                    .ToArray();
        }

        public void SetFruitType(FruitType type)
        {
            currentFruitType = type;
        }
    }
}