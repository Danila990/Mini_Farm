using UnityEngine;

namespace MiniFarm
{
    public class TrapCell : CellBase
    {
        [field: SerializeField] public Trap trap { get; private set; }

        public override CellType CellType => CellType.Trap;

        public void SetTrap(Trap trap) => this.trap = trap;

        public override void Event()
        {
            if(trap.IsActive())
                ServiceLocator.Get<GameManager>().LossGame();
        }
    }
}