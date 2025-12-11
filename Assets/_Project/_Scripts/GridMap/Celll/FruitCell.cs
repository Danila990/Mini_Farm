using UnityEngine;

namespace MiniFarm
{
    public class FruitCell : CellBase
    {
        [field: SerializeField] public Fruit fruit { get; private set; }

        public override CellType CellType => CellType.Fruit;

        public void SetFruit(Fruit fruit) => this.fruit = fruit;

        public override void Event()
        {
            if (!fruit.gameObject.activeInHierarchy) return;

            fruit.DisableFruit();
        }

        public override void Restart()
        {
            fruit.gameObject.SetActive(true);
        }
    }
}