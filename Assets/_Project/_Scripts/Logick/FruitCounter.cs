using System;
using UnityEngine;

namespace MiniFarm
{
    public class FruitCounter : MonoBehaviour
    {
        public event Action<int, int> OnFruit;

        public int maxFruit {  get; private set; }
        public int currentFruit { get; private set; }

        [Inject]
        public void Setup(IGridMap gridMap)
        {
            maxFruit = gridMap.FindCells<FruitCell>(CellType.Fruit).Length;
            currentFruit = maxFruit;
        }

        public void DecreaseFruit()
        {
            currentFruit--;
            OnFruit?.Invoke(currentFruit, maxFruit);
        }
    }
}